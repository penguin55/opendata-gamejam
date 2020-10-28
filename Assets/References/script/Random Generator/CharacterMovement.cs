using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;

    Vector2 arah;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
    }

    void MoveCharacter()
    {
        arah = Vector2.zero;

        if (Input.GetKeyDown(KeyCode.D))
        {
            arah.x = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            arah.x = -1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            arah.y = 1;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            arah.y = -1;
        }

        //arah.Normalize();
        //rb.MovePosition(transform.position + arah * speed * Time.deltaTime);

        transform.Translate(arah * speed * Time.deltaTime);
    }
}
