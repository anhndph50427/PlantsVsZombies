using System.Collections;
using UnityEngine;

public class PushWaterSkill : MonoBehaviour
{
    [SerializeField] private Vector2 dir;

    private void Start()
    {
        dir = GameManager.Instance.PushWater.infor[PlayerPrefs.GetInt("indexLevel")].force;
    }
    private void Update()
    {
        StartCoroutine(PushEnemy(dir));
    }

    IEnumerator PushEnemy( Vector3 dir)
    {
        transform.position += dir * Time.deltaTime;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
