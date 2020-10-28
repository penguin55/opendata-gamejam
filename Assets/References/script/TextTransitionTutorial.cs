using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTransitionTutorial : MonoBehaviour
{

    public GameObject[] Active;
    public GameObject[] Deactive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            ActiveGameObject();
            DeactiveGameObject();
        }
    }

    void ActiveGameObject()
    { 
        for (int i = 0; i < Active.Length; i++)
        {
            Active[i].SetActive(true);
        }
    }

    void DeactiveGameObject()
    {
        for (int i = 0; i < Deactive.Length; i++)
        {
            Deactive[i].SetActive(false);
        }
    }
}
