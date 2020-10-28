using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;

    [Header("Player Gold")]
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private int targetGold;
    [SerializeField] private int tempGold;
    [SerializeField] private int[] TargetGold;

    void Start()
    {
        instance = this;
        tempGold = 0;
        GameVariables.WAS_COMPLETE = false;
    }

    void Update()
    {
        checkTarget();
    }

    public float getPlayerGold()
    {
        return playerInventory.coin;
    }

    public void checkTarget()
    {
        Debug.Log(getTempGold()+ " " + targetGold + " " + GameVariables.WAS_COMPLETE);
        if (getTempGold() >= targetGold)
        {
            GameVariables.WAS_COMPLETE = true;
        }
        else
        {
            GameVariables.WAS_COMPLETE = false;
        }
    }

    public void setPlayeGold(int gold)
    {
        playerInventory.coin = gold;
    }

    public void addPlayerGold(int gold)
    {
        playerInventory.coin += gold;
    }

    public int getTargetGold()
    {
        return targetGold;
    }

    public void setTargetGold(int _targetGold)
    {
        targetGold = _targetGold;
    }

    public void addTargetGold(int _targetGold)
    {
        targetGold += _targetGold;
    }

    public int getTempGold()
    {
        return tempGold;
    }

    public void setTempGold(int _tempGold)
    {
        tempGold = _tempGold;
    }

    public void addTempGold(int _tempGold)
    {
        tempGold += _tempGold;
    }

    public int GetTargetGold(int index)
    {
        return TargetGold[index];
    }

    public int GetLenTargetGold()
    {
        return TargetGold.Length;
    }

}
