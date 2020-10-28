using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : CharaBehaviour
{
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveRight;
    public KeyCode moveLeft;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controller();
    }

    public void Controller()
    {
        direction = Vector2.zero;

        if (Input.GetKey(moveUp))
        {
            direction = Vector2.up;
        }
        if (Input.GetKey(moveDown))
        {
            direction = Vector2.down;
        }
        if (Input.GetKey(moveLeft))
        {
            direction = Vector2.left;
        }
        if (Input.GetKey(moveRight))
        {
            direction = Vector2.right;
        }

        transform.Translate(direction * speed * Time.deltaTime);
    }
}
