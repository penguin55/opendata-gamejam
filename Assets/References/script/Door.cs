using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : ContextClue
{
    private void Update()
    {
        if (status && Input.GetKey(KeyCode.E))
        {
            leveldone.asd = true;
            TransitionManager.Instance.FadeIn(masukGame);
        }
    }

    public void masukGame()
    {
        LevelLoader.instance.LoadLevel(3);
    }
}
