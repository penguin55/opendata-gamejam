using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Text cautionText;

    private void Start()
    {
        TransitionManager.Instance.FadeOut(null);
        playButton.interactable = false;
    }

    private void Update()
    {
        if (playerData.isTutorial)
        {
            playButton.interactable = true;
            cautionText.gameObject.SetActive(false);
        }
        else
        {
            cautionText.gameObject.SetActive(true);
        }
    }

    public void masukGame()
    {
        TransitionManager.Instance.FadeIn(enterGame);
    }

    public void enterGame()
    {
        LevelLoader.instance.LoadLevel(1);
    }
    public void keluarGame()
    {
        TransitionManager.Instance.FadeIn(exitgame);
    }

    public void exitgame()
    {
        Debug.Log("keluar");
        Application.Quit();
    }
    public void masukOption()
    {
        SceneManager.LoadScene(2);
    }
    public void masukMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void masukTutorial()
    {
        leveldone.asd = true;
        TransitionManager.Instance.FadeIn(enterTutorial);
    }

    public void enterTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
