using UnityEngine;

public class Sun : MonoBehaviour
{
   
    public float stopPos { get; set; }
    public bool isTouch {  get; set; }
    public Transform target;
    [SerializeField] private float speed;
    private Animator animator;
    // Update is called once per frame
    private void Start()
    {
        target = GameObject.Find("target").transform;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (isTouch)
        {
            transform.position = Vector2.MoveTowards(transform.position , target.position, 5f  * Time.deltaTime);
        }

        if(transform.position.y >= stopPos && !isTouch)
        {
            transform.position -= new Vector3(0,speed * Time.deltaTime, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("target"))
        {
            GamePlay.instance.sunScore += 25;
            animator.Play("SunMove");
            Destroy(gameObject, 1f);
        }
    }
}
