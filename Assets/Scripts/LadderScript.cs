using UnityEngine;

public class LadderScript : MonoBehaviour
{
    [SerializeField]

    float speed = 5;
    Collider2D col;

    void Update()
    {
        if (col != null)
        {
            if (Input.GetKey(KeyCode.W)) col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);

            else if (Input.GetKey(KeyCode.S)) col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);

            else col.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0;

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerMove>().onStairs = true;
            col = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 2.5f;
        if (other.gameObject.tag == "Player") other.gameObject.GetComponent<PlayerMove>().onStairs = false;
        col = null;
    }
}
