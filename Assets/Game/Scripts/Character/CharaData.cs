﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaData : MonoBehaviour
{
   private bool isDashing;
   [SerializeField]private float speed, dashSpeed,hp=3, maxhp=3;

    public bool IsDashing { get => isDashing; set => isDashing = value; }
    public float DashSpeed { get => dashSpeed; set => dashSpeed = value; }
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
