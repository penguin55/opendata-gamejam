using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerhp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] hearts;
    public Sprite newsprite;
    public Sprite oldsprite;
    public static bool dead = false;
    public PlayerInventory inventory;
    [SerializeField] private Animator animator;


    public static playerhp instance;

    void Start()
    {
        instance = this;
        leveldone.stop = true;
        
        uilive();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HP : " + playerData.hp);   
        if (dead)
        {
            leveldone.stop = false;
        }
    }

    public void uilive()
    {
        int i = 0;
        while (i < playerData.maxhp)
        {
            hearts[i].SetActive(true);
            if (i < playerData.hp)
            {
                hearts[i].GetComponent<Image>().overrideSprite = oldsprite;
            }
            else
            {
                hearts[i].GetComponent<Image>().overrideSprite = newsprite;
            }
            i++;
        }
    }

    public void takedamage()
    {
        if (playerData.hp >= 1)
        {
            FindObjectOfType<AudioManager>().Play("Hurt");
            playerData.hp-= 1;
            uilive();
            
            if (playerData.hp < 1)
            {
                StartCoroutine(animation());
                FindObjectOfType<GameManager>().gameEnd();
                FindObjectOfType<AudioManager>().Play("Death");
                dead = true;
            }
        }
    }

    public void AddLife()
    {
        if(playerData.maxhp < 5 && playerData.hp >=3) {
            playerData.maxhp++;
        }
        playerData.hp++;
        if (playerData.hp > playerData.maxhp)
        {

            if (playerData.hp < 3)
            {
                hearts[playerData.hp].GetComponent<Image>().overrideSprite = oldsprite;
            }
            else
            {
                playerData.hp = playerData.maxhp;
                hearts[playerData.hp].GetComponent<Image>().overrideSprite = oldsprite;
            }
            
            
        }
    }

    public bool isMaxLife()
    {
        return playerData.hp == 5;
    }

    public PlayerInventory GetPlayerInventory()
    {
        return inventory;
    }

    public void UpdateLive()
    {
        uilive();
    }

    IEnumerator animation()
    {
        Debug.Log("mati jalan");
        animator.SetBool("dead", true);
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0f;
        animator.SetBool("dead", false);
    }

}
