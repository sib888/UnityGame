using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform player;
    private Vector3 pos;
    [Range (0, 30f)] public float vol = 0.25f;
    float yLimit = 0;

    public float yCoff = 0f;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        transform.position = player.position;
    }

    void Update()
    {
        pos = player.position;
        pos.y += yCoff;
        pos.z = -10f;
        transform.position = Vector3.Lerp(transform.position, pos, vol * Time.deltaTime);
        if (transform.position.y < yLimit) transform.position = new Vector3(transform.position.x, yLimit, transform.position.z);
    }
}
