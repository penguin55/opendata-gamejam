using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPC : ContextClue
{
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;

    public GameObject tutorialBox;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && status)
        {
            if (dialogBox.activeInHierarchy)
            {
                dialogBox.SetActive(false);
                contextClue.SetActive(true);
                tutorialBox.SetActive(true);
            }
            else
            {
                dialogBox.SetActive(true);
                dialogText.text = dialog;
                contextClue.SetActive(false);
                tutorialBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            contextClue.GetComponent<SpriteRenderer>().sprite = sprite;
            status = true;
            contextClue.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            contextClue.GetComponent<SpriteRenderer>().sprite = null;
            status = false;
            contextClue.SetActive(false);
            dialogBox.SetActive(false);
        }
    }    
}
