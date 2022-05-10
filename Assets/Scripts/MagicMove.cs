using UnityEngine;

public class MagicMove : MonoBehaviour
{
    public float speed = 0.5f;
    public float dist = 15f;
    private Vector2 pos;
    
    void Update()
    {
        pos = GameObject.Find("Main Camera").transform.position;
        transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);

        if (transform.position.x < pos.x - dist) transform.position = new Vector2(pos.x + dist, transform.position.y);
    }
}
