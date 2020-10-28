using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonFX : MonoBehaviour
{

    public void clickFX()
    {
        FindObjectOfType<AudioManager>().Play("Click");
    }
}
