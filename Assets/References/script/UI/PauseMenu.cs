using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;

    public GameObject pauseMenuUI;

  

    private void Start()
    {
        GameIsPaused = false;
    }

   
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void masukMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        TransitionManager.Instance.FadeIn(inGame);
    }

    public void inGame()
    {
        SceneManager.LoadScene(0);
    }
    public void keluarGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        TransitionManager.Instance.FadeIn(balikHub);
    }
    public void balikHub()
    {
        Application.Quit();
    }
}
