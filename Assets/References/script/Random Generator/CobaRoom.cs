using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CobaRoom : MonoBehaviour
{

    public GameObject batasKiri;
    public GameObject batasKanan;

    void Start()
    {
        //Debug.Log(GetBatasKanan());
        //Debug.Log(GetBatasKiri());
    }

    public Vector2 GetBatasKiri()
    {
        return batasKiri.transform.position;
    }

    public Vector2 GetBatasKanan()
    {
        return batasKanan.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Player"))
        {
            //CameraController.instance.room = this;
            //CameraController.instance.setBatas(transform.position, transform.position);
        }
    }
}
