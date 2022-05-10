using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Vector2 offset;
    public float Distance = 5f;
    public float speed = 3f;
    private bool MoveRight = false;
    public bool isHitting = false;
    public float attackDur = 0;

    public Animator anim;


    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        if (isHitting && attackDur > 2)
        {
            isHitting = false;
            anim.SetBool("isHitting", false);
            attackDur = 0;
        }

        if (attackDur < 2 && isHitting) attackDur += Time.deltaTime;
    }

    void FixedUpdate()
    {
        if (transform.position.x > offset.x)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            MoveRight = false;
        }
        
        else if (transform.position.x < offset.x - Distance)
        {
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            MoveRight = true;
        }

        if (MoveRight && !isHitting) transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        else if (!MoveRight && !isHitting) transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isHitting = true;
            anim.SetBool("isHitting", true);
            if (attackDur == 0) other.gameObject.GetComponent<Health>().TakeHit(1);
        }
    }
}
