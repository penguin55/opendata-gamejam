using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HUBMenu : MonoBehaviour
{
    public Text scoreText;


    void Start()
    {
        Time.timeScale = 1f;
        LevelLoader.instance.LoadDone();
        movement.instance.loading = false;
        Debug.Log("ini debug");
        TransitionManager.Instance.FadeOut(null);
        playerData.upgradeSpeed = 0;
        playerData.isUpgrade = false;
        GameVariables.WAS_COMPLETE = false;
    }

    void Update()
    {
        movement.instance.move = true;
        Debug.Log("Gold : " + GameData.instance.getPlayerGold());
        scoreText.text = "Score : "+ GameData.instance.getPlayerGold();
    }
}
