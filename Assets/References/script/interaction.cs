using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour
{
    private bool pickItemAllowed;
    public int[] itemScore;
    private int totalscore = 0;
    public Text scoreText;
    public static GameObject Item;
    void Start()
    {
        scoreText.text = totalscore.ToString();
    }
    void Update()
    {
        if (pickItemAllowed && Input.GetKeyDown(KeyCode.E))
        {
            pickUp();
            if (Item.tag == "Item")
            {
                totalscore += 100;
            }
            else if (Item.tag == "Item 2")
            {
                totalscore += 20;
            }
            Debug.Log("Total score: " + totalscore);
            scoreText.text = totalscore.ToString();
            if (totalscore >= 100)
            {
                Debug.Log("finish");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            Debug.Log("in range");
            pickItemAllowed = true;
        }
        if (collision.gameObject.tag == "Item 2")
        {
            Debug.Log("in range");
            pickItemAllowed = true;
        }
        Item = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
            pickItemAllowed = false;
    }
    private void pickUp()
    {
        Destroy(Item);
    }
}
