
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GlassSkill : MonoBehaviour
{
    [Header("CoolDown")]
    public float CoolDown;
    public float CoolDownTimer;
    public float EffectDuration;
    public bool isOnSkill;
    private int curentIndex;

    [Header("Colision info")]
    public Vector2 SizeBox;
    public LayerMask whatIsLayerMask;

    [Header("UI")]
    public Button ActiveSkill;
    public TextMeshProUGUI CoolDownText;
    private SpriteRenderer sr;
    private void Start()
    {
        ActiveSkill = GameObject.Find("GrassSkillBtn").GetComponent<Button>();
        ActiveSkill.onClick.AddListener(() => onButton());
        CoolDownText.text = CoolDownTimer.ToString("n0");
        sr = GetComponent<SpriteRenderer>();
        curentIndex = PlayerPrefs.GetInt("slowlyLevel");

        EffectDuration = GameManager.Instance.Slowly.infor[curentIndex].TimeStopMove;
        
    }


    private void Update()
    {
        CoolDownTimer -= Time.deltaTime;
        if(CoolDownTimer < 0)
        {
            ActiveSkill.interactable = true;
            CoolDownText.gameObject.SetActive(false);
        }
        else
        {
            CoolDownText.gameObject.SetActive(true);
            CoolDownText.text = CoolDownTimer.ToString("n0");
            ActiveSkill.interactable = false;
        }
    }

    private void onButton()
    {
        Debug.Log("is CoolDown");
        CoolDownTimer = GameManager.Instance.Slowly.infor[curentIndex].coolDown;
        isOnSkill = true;
    }

    private void FixedUpdate()
    {
        if (isOnSkill)
        {
            checkEnemy();
        }
    }


    void checkEnemy()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position, SizeBox, 0, Vector2.down, whatIsLayerMask);
        foreach (var colision in hit)
        {
            if (colision.collider != null)
            {
                StartCoroutine(FreezeEnemy(colision.collider.gameObject));
            }
            else
            {
                return;
            }
        }
    }

    IEnumerator FreezeEnemy(GameObject target)
    {
        ZombieBase Enemy = target.GetComponent<ZombieBase>();
        if (Enemy != null)
        {
            Debug.Log("Enemy no movement");
            Enemy.canMove = false;
            yield return new WaitForSeconds(EffectDuration);
            Debug.Log("Enemy movement");
            Enemy.canMove = true;
            isOnSkill = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(SizeBox.x, SizeBox.y, 0));
    }
}
