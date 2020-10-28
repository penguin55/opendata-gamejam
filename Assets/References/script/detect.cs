using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class detect : MonoBehaviour
{
    public GameObject player;
    private bool  insight = false;
    [SerializeField] private Animator animator;
    public GameObject enemy;
    float waktu;
    float lastpos,lastposy;
    public SpriteRenderer sprite;

    public bool pursuit, normal;

    [Header("Context Clue")]
    [SerializeField] private Animator contextClue;
    //[SerializeField] private Sprite excMark;
    //[SerializeField] private Sprite questMark;
    

    public static detect instance;

    private void Start()
    {
        instance = this;
        lastpos = this.transform.position.x;
        contextClue.gameObject.SetActive(false);
    }

    private void Update()
    {
        flip();
        takeDamage(insight);
        if(pursuit) FindObjectOfType<AudioManager>().Play("Pursuit");
        if (normal) FindObjectOfType<AudioManager>().Play("BackToNormal");
    }

    private IEnumerator stopchasing()
    {
        //contextClue.GetComponent<SpriteRenderer>().sprite = excMark;
        pursuit = true;
        yield return new WaitForSeconds(5f);
        pursuit = false;
        enemy.GetComponent<AIDestinationSetter>().enabled = false;
        enemy.GetComponent<AIDestinationSetter2>().enabled = true;
        contextClue.SetBool("context_clue", false);
        //contextClue.GetComponent<SpriteRenderer>().sprite = questMark;
        yield return new WaitForSeconds(1f);
        enemy.GetComponent<AIDestinationSetter2>().enabled = false;
        normal = true;
        yield return new WaitForSeconds(0.2f);
        normal = false;
        //contextClue.GetComponent<SpriteRenderer>().sprite = null;
        contextClue.gameObject.SetActive(false);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            contextClue.gameObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play("InitiatePursuit");
            contextClue.SetBool("context_clue", true);
            player = collision.gameObject;          
            enemy.GetComponent<AIDestinationSetter>().enabled = true;
            insight = true;
            //Debug.Log(player.transform.position);
            //Debug.Log("player is on Sight");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            //Debug.Log("player is out of sight");
            insight = false;
            StartCoroutine(stopchasing());
        }
    }

    private void flip()
    {
        float arah = this.transform.position.x - lastpos;
        lastpos = this.transform.position.x;
        float arahy = this.transform.position.y - lastposy;
        lastposy = this.transform.position.y;
        if (arah > 0)
        {
            sprite.flipX = false;
            animator.SetFloat("speed", Mathf.Abs(arah));
        }
        if (arah < 0)
        {
            sprite.flipX = true;
            animator.SetFloat("speed", Mathf.Abs(arah));
        }
        animator.SetFloat("kecepatan", Mathf.Abs(arahy));
    }

    private void takeDamage(Boolean insight)
    {
        double distance = Math.Sqrt(Math.Pow(player.transform.position.x - enemy.transform.position.x, 2)
            + Math.Pow(player.transform.position.y - enemy.transform.position.y, 2));
        
        if (distance <2 && insight)
        {
            player.GetComponent<playerhp>().takedamage();
            StartCoroutine(stopattack());
        }
    }

    

    private IEnumerator stopattack()
    {
        insight = false;
        StartCoroutine(Fade());
        yield return new WaitForSeconds(3f);
        insight = true;
    }

    private IEnumerator Fade()
    {
        while (!insight)
        {
            player.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.5f);
            player.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }

    public void stun (bool stun)
    {
        Debug.Log("stun : " + stun);
        animator.SetBool("stun", stun);
    }

}
