using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D doorCol = null;
    private float HorizontalMove = 0f;
    private bool nextToTheDoor = false;
    public bool onStairs = false;
    private bool climbing = false;


    private bool FaceRight = true;

    [Range (0, 50f)] public float speed = 1f;
    [Range (0, 15f)] public float jumpForce = 1f;
    [Range (0, 3)] public int runes = 0;

    public bool takeKey = false;

    public GameObject RuneEffect, KeyEffect, AppleEffect;
    public GameObject hint, noKeyText;
    Vector3 homepos, spawnpos;

    [Space]
    public Animator animator;

    [Space]
    bool isGrounded = false;
    [Range (-25f, 25f)] public float checkOffsetY = -1.8f;
    [Range (0, 5f)] public float checkGroundRadius = 0.3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        homepos = GameObject.Find("Home").transform.position;
        spawnpos = new Vector3(homepos.x, homepos.y - 3f, homepos.z);

        transform.position = spawnpos; // Спавн игрока

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); // Прыжок
        }

        if (Input.GetKeyDown(KeyCode.E) && nextToTheDoor && takeKey) 
        {
            if (doorCol == null) Debug.Log("Технические Неполатки");
            else doorCol.isTrigger = !doorCol.isTrigger;
        }

        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove)); // Анимация гордости нации

        climbing = onStairs && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S));
        animator.SetBool("onStairs", climbing);

        if (isGrounded == false) animator.SetBool("Jumping", true); // Анимация прыжка
        else animator.SetBool("Jumping", false);

        if (HorizontalMove < 0 && FaceRight || HorizontalMove > 0 && !FaceRight) flip();
    }

    private void FixedUpdate()
    {
        Vector2 targetVel = new Vector2(HorizontalMove, rb.velocity.y);
        rb.velocity = targetVel;
        CheckGround();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Door")
        {
            doorCol = other.gameObject.GetComponent<BoxCollider2D>();
            if (hint != null && noKeyText != null) 
            {
                if (takeKey) hint.SetActive(true);
                else noKeyText.SetActive(true);
            }
            nextToTheDoor = true;
        }

        if (other.gameObject.tag == "Rune") // Проверка сбора рун
        {
            runes += 1;
            Instantiate(RuneEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Key") // Проверка сбора ключа
        {
            takeKey = true;
            Instantiate(KeyEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.tag == "Apple")
        {
            GetComponent<Health>().Heal(1);
            Instantiate(AppleEffect, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Portal" && runes == 3) // Перемещение между уровнями
        {
            if (SceneManager.sceneCountInBuildSettings - 1 == SceneManager.GetActiveScene().buildIndex) Debug.Log("Игра всё ещё в бете");

            else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.gameObject.tag == "Door" && !(other is BoxCollider2D)) 
        {
            if (hint != null && noKeyText != null)
            {
                hint.SetActive(false);
                noKeyText.SetActive(false);
            }
            doorCol = null;
            nextToTheDoor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud") this.transform.parent = collision.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cloud") this.transform.parent = null;
    }

    private void flip() // Разворот персонажа
    {
        FaceRight = !FaceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void CheckGround() // Проверка нахождения на земле
    {
        Collider2D[] colls = Physics2D.OverlapCircleAll(new Vector2(transform.position.x, transform.position.y + checkOffsetY), checkGroundRadius);

        if (colls.Length > 1) isGrounded = true;
        else isGrounded = false;
    }
}
