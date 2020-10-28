using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    private float waitTime = 4f;

    void Start()
    {
        Destroy(this.gameObject, waitTime);
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Closed")
        {
            Destroy(other.gameObject);
        }
	}
}
