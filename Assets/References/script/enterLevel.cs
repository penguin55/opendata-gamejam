using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enterLevel : MonoBehaviour
{
    private bool status;

    private void Start()
    {
        status = false;
    }
    private void Update()
    {
        if(status && Input.GetKeyDown(KeyCode.E))
        {
            leveldone.asd = true;
            LevelLoader.instance.LoadLevel(3);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            status = true;
        }
    }

}
