using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public GameObject player;
    public Animator animator;
    public int runes;

    void Start()
    {
        player = GameObject.Find("Player");
    }


    void Update()
    {
        runes = player.GetComponent<PlayerMove>().runes;
        animator.SetInteger("runes", runes);
    }
}
