using UnityEngine;

public class CloudMove : MonoBehaviour
{
    private Vector2 offset;
    public float Distance = 5f;
    public float speed = 3f;
    public bool MoveRight = false;
    public bool AxisX = true;
    

    void Start()
    {
        offset = transform.position;
    }

    void Update()
    {
        if (AxisX) {
            if (transform.position.x > offset.x) MoveRight = false;
            else if (transform.position.x < offset.x - Distance) MoveRight = true;

            if (MoveRight) transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
            else transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        
        else {
            if (transform.position.y > offset.y) MoveRight = false;
            else if (transform.position.y < offset.y - Distance) MoveRight = true;

            if (MoveRight) transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            else transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
    }
}
