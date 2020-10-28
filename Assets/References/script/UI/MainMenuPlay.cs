using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Main Menu");
    }
    
}
