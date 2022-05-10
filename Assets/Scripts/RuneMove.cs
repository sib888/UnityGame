using UnityEngine;

public class RuneMove : MonoBehaviour
{
    public Vector3 toPosUp;
    public Vector3 toPosDown;
    private Vector3 offset;
    public bool up = true;
    [Range (0, 2f)] public float amplitude = 1f;
    public float speed = 1;

    void Start()
    {
        offset = transform.position;
        toPosUp = new Vector3(offset.x, offset.y + amplitude, offset.z);
        toPosDown = new Vector3(offset.x, offset.y - amplitude, offset.z);
    }

    void Update()
    {
        toPosUp.y = offset.y + amplitude;
        toPosDown.y = offset.y - amplitude;

        if (up) transform.position = Vector3.Lerp(transform.position, toPosUp, Time.deltaTime * speed);
        else transform.position = Vector3.Lerp(transform.position, toPosDown, Time.deltaTime * speed);

        if (transform.position.y <= toPosDown.y + 0.1f) up = true;
        else if (transform.position.y >= toPosUp.y - 0.1f) up = false;

    }
}
