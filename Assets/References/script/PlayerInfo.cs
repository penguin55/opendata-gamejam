using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator anim;
    public RuntimeAnimatorController babiBiasa;
    public RuntimeAnimatorController babiBerdasi;

    public Sprite idleBiasa;
    public Sprite idleBerdasi;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePlayer()
    {
        if (playerData.isUpgrade)
        {
            sprite.sprite = idleBerdasi;
            anim.runtimeAnimatorController = babiBerdasi;
        }
        else
        {
            sprite.sprite = idleBiasa;
            anim.runtimeAnimatorController = babiBiasa;
        }
    }
}
