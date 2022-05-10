using UnityEngine;

public class ParallaxMove : MonoBehaviour
{
    private Rigidbody2D rb, camera_rb;
    public float parX = 0.1f, parY = 0.1f;
    public float speedX, speedY;
    float dist = 16.6f;
    Vector3 cam_pos, cam_velocity, neighbour_pos;
    public GameObject neighbour;
    
    void Start()
    {
        cam_pos = GameObject.Find("Main Camera").transform.position;
        camera_rb = GameObject.Find("Main Camera").GetComponent<Rigidbody2D>();
        if (neighbour != null) neighbour_pos = neighbour.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        cam_velocity = (GameObject.Find("Main Camera").transform.position - cam_pos) / Time.deltaTime;

        if (transform.position.x > cam_pos.x + dist) 
        {
            if (neighbour != null) transform.position = new Vector2(neighbour_pos.x - dist, transform.position.y);
            else transform.position = new Vector2(cam_pos.x - dist, transform.position.y);
            
        }

        else if (transform.position.x < cam_pos.x - dist)
        {
            if (neighbour != null) transform.position = new Vector2(neighbour_pos.x + dist, transform.position.y);
            else transform.position = new Vector2(cam_pos.x + dist, transform.position.y);
        }

        speedX = cam_velocity.x * parX * -1;
        speedY = cam_velocity.y * parY * -1;
        rb.velocity = new Vector2(speedX, speedY);
        
        cam_pos = GameObject.Find("Main Camera").transform.position;
        if (neighbour != null) neighbour_pos = neighbour.transform.position;
    }
}
