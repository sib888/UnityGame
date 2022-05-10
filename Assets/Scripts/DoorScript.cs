using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private BoxCollider2D col;
    public Sprite openSprite;
    public Sprite closeSprite;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (col.isTrigger) GetComponent<SpriteRenderer>().sprite = openSprite;
        else GetComponent<SpriteRenderer>().sprite = closeSprite;
    }
}
