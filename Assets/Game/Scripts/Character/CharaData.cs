using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaData : MonoBehaviour
{
    [SerializeField] private float speed, hp;

    public float Speed { get => speed; set => speed = value; }
    public float Hp { get => hp; set => hp = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
