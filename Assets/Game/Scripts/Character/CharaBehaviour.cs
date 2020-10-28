using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBehaviour : MonoBehaviour
{
    [SerializeField] protected CharaData data;
    [SerializeField] protected Vector2 direction;

    public void Init()
    {
        data.Hp = 100;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
