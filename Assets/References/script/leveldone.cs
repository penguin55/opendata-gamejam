using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;

public class leveldone : MonoBehaviour
{
    public static Boolean stop = true;
    public static bool asd = true;
    public static Collider2D []enemy;
    public GameObject[] Deactive;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && GameVariables.WAS_COMPLETE)
        {
            Debug.Log("level is complete");
            StartCoroutine(spawn());
            stop = false;
            asd = false;
            foreach(Collider2D satpam in enemy)
            {
                satpam.GetComponent<detect>().pursuit = false;
                satpam.GetComponent<detect>().normal = false;
            }
            if (UIManager.index < GameData.instance.GetLenTargetGold()-1)
                UIManager.index++;
            if (isTutorialScene())
            {
                playerData.isTutorial = true;
                playerData.hp = 3;
                playerData.maxhp = 3;
                for (int i = 0; i < Deactive.Length; i++)
                {
                    Deactive[i].SetActive(false);
                }
            }
            else
            {
                GameData.instance.addPlayerGold(GameData.instance.getTempGold());
            }
        }
    }

    public IEnumerator spawn()
    {
        movement.instance.animator.SetBool("start", true);
        FindObjectOfType<AudioManager>().Play("Spawning");
        yield return new WaitForSeconds(0.8f);
        Time.timeScale = 0f;
        
    }

    public static bool isTutorialScene()
    {
        return SceneManager.GetActiveScene().name == "Tutorial" ? true : false;
    }
    
        
    
}
