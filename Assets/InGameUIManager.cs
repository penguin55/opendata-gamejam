using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TomWill;
using UnityEngine.SceneManagement;

public class InGameUIManager : MonoBehaviour
{
    private bool isPaused;
    [SerializeField] private GameObject pauseMenuUI;
    // Start is called before the first frame update
    void Start()
    {
        TWTransition.FadeOut();
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        OpenPauseMenu();
    }

    public void OpenPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
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
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Restart()
    {
        TWTransition.FadeIn(() => TWLoading.LoadScene("SampleScene"));
    }

    public void BackToMenu()
    {
        TWTransition.FadeIn(() => TWLoading.LoadScene("MainMenu"));
    }
}
