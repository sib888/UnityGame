using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHPScript : MonoBehaviour
{
    int health;
    public GameObject hp1, hp2, hp3;

    void Update()
    {
        health = GameObject.Find("Player").GetComponent<Health>().health;

        if (health == 3)
        {
            hp3.SetActive(true);
            hp2.SetActive(true);
            hp1.SetActive(true);
        }

        else if (health == 2)
        {
            hp3.SetActive(false);
            hp2.SetActive(true);
            hp1.SetActive(true);
        }

        else if (health == 1)
        {
            hp3.SetActive(false);
            hp2.SetActive(false);
            hp1.SetActive(true);
        }

        else if (health == 0)
        {
            hp3.SetActive(false);
            hp2.SetActive(false);
            hp1.SetActive(false);
        }
    }
}
