using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int BuyLife(int cointRequirement)
    {
         PlayerInventory playerInventory = playerhp.instance.GetPlayerInventory();
        if (playerInventory.coin >= cointRequirement)
        {
            if (playerhp.instance.isMaxLife())
            {
                return 0;
            }
            playerhp.instance.AddLife();
            playerhp.instance.UpdateLive();
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public int BuySpeed(int cointRequirement)
    {
        PlayerInventory playerInventory = playerhp.instance.GetPlayerInventory();
        if (playerInventory.coin >= cointRequirement)
        {
            Debug.Log(movement.instance);
            if (movement.instance.isMaxspeed())
            {
                return 0;
            }
            movement.instance.Upgradespeed();
            movement.instance.UpdateSpeed();
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
