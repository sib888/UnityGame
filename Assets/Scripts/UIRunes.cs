using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRunes : MonoBehaviour
{
    int runes;
    public GameObject rune1, rune2, rune3;

    void Update()
    {
        runes = GameObject.Find("Player").GetComponent<PlayerMove>().runes;

        if (runes == 1)
        {
            rune1.SetActive(true);
        }

        else if (runes == 2)
        {
            rune2.SetActive(true);
        }

        else if (runes == 3)
        {
            rune3.SetActive(true);
        }
    }
}
