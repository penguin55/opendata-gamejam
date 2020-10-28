using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsEnded = false;
    public GameObject gameOverUI;
    public GameObject gameFinishUI;

    public UIManager instance;

    public GameObject[] Deactive;

    public GameObject GuardMessage;

    private void Start()
    {
        
    }
    private void Update()
    {
        gameFinish();
    }

    public void gameEnd()
    {
        if(!gameIsEnded)
        {
            if (leveldone.isTutorialScene())
            {
                for (int i = 0; i < Deactive.Length; i++)
                {
                    Deactive[i].SetActive(false);
                }
            }
            gameIsEnded = true;
            FindObjectOfType<AudioManager>().Play("Death");
            instance.FinalCoin();
            gameOverUI.SetActive(true);
            Debug.Log("Game Over");
            foreach (Collider2D satpam in leveldone.enemy)
            {
                satpam.GetComponent<detect>().pursuit = false;
                satpam.GetComponent<detect>().normal = false;
                satpam.GetComponent<detect>().enemy.GetComponent<AIDestinationSetter>().enabled = false;
            }
            
            
        }
    }
    public void gameFinish()
    {
        if(!leveldone.asd)
        {
            instance.FinalCoin();
            gameFinishUI.SetActive(true);
        }
    }

    public void bribe(int coin)
    {
        if(GameData.instance.getTempGold() < coin)
        {
            StartCoroutine(bribe());
        }
        else
        {
            GameData.instance.setTempGold(GameData.instance.getTempGold() - coin);
            playerhp.instance.AddLife();
            playerhp.instance.uilive();
            playerhp.dead = false;
            gameIsEnded = false;
            leveldone.stop = true;
            leveldone.asd = true;
            gameOverUI.SetActive(false);
            Time.timeScale = 1f;
            
        }
    }

    public IEnumerator bribe()
    {
        GuardMessage.SetActive(true);
        Time.timeScale = 1f;
        yield return new WaitForSeconds(2f);
        GuardMessage.SetActive(false);
        Time.timeScale = 0f;
    }

    public void backToHUB()
    {
        if(playerData.hp < 1)
        {
            playerData.hp = 3;
            playerData.maxhp = 3;
        }
        FindObjectOfType<AudioManager>().Play("Click");
        playerhp.dead = false;
        gameIsEnded = false;
        gameOverUI.SetActive(false);
        gameFinishUI.SetActive(false);
        TransitionManager.Instance.FadeIn(balikHub);
        movement.instance.DisUpdateSpeed();
    }

    public void balikHub()
    {
        SceneManager.LoadScene(1);
    }

    public void MasukMenu()
    {
        playerData.hp = 3;
        playerData.maxhp = 3;
        playerhp.instance.uilive();
        FindObjectOfType<AudioManager>().Play("Click");
        playerhp.dead = false;
        gameIsEnded = false;
        gameOverUI.SetActive(false);
        gameFinishUI.SetActive(false);
        TransitionManager.Instance.FadeIn(EnterMenu);
        movement.instance.DisUpdateSpeed();
    }

    public void EnterMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void quitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }
}
