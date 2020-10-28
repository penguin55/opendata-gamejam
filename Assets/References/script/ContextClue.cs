using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContextClue : MonoBehaviour
{
    [SerializeField] protected GameObject contextClue;
    [SerializeField] protected Sprite sprite;

    public bool status;

    void Start()
    {
        status = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        }
    }
}
