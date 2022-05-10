using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject player;
    public GameObject DeadMenu;
    private bool isAlive = true;
    public float yLimit = 0f;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (player.transform.position.y < yLimit) player.GetComponent<Health>().health = 0;

        if (player.GetComponent<Health>().health <= 0 && isAlive)    
        {
            Time.timeScale = 0f;
            isAlive = false;
            DeadMenu.SetActive(true);
        }
    }
}
