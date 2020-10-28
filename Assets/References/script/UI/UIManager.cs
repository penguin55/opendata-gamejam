using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    //public PlayerInventory playerInventory;

    public Text time;
    public Text coin;
    public Text coinwin, coinlose;
    public Text countmundur;
    public GameObject countMundur;

    public static int index;
    public float currenttime;
    public float theTime;

    // Start is called before the first frame update
    void Start()
    {
        coin.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        DecreaseTime();
        UpdateCoin();
        UpdateTargetGold();
        if (movement.instance.loaddone) countdown();
    }

    public void countdown()
    {
        countMundur.SetActive(true);
        if (currenttime <0.5)
        {
            countMundur.SetActive(false);
            Debug.Log("count habis");
            movement.instance.move = true;
        }
        else if (currenttime > 0.5)
        {
            currenttime -= Time.deltaTime*1;
            Debug.Log("count lagi ngurang");
        }
        string time = Mathf.Floor((currenttime % 60)).ToString("0");
        countmundur.text = time.ToString();

    }

    void UpdateTargetGold()
    {
        if (index < GameData.instance.GetLenTargetGold())
            GameData.instance.setTargetGold(GameData.instance.GetTargetGold(index));
    }

    void UpdateCoin()
    {
        coin.text = GameData.instance.getTempGold() + "/" + GameData.instance.GetTargetGold(index);        
    }

    public void FinalCoin()
    {
        if (!leveldone.asd)
        {
            coinwin.text = GameData.instance.getTempGold() + "";
        }
        else if (!playerhp.dead)
        {
            if (GameVariables.WAS_COMPLETE)
            {
                int temp = (int) GameData.instance.getTempGold() / 4;
                GameData.instance.setTempGold(temp);
                if (!leveldone.isTutorialScene()) GameData.instance.addPlayerGold(temp);
            }
            else
            {
                int temp = (int)GameData.instance.getTempGold() / 2;
                GameData.instance.setTempGold(temp);
                if (!leveldone.isTutorialScene()) GameData.instance.addPlayerGold(temp);
            }

            coinlose.text = GameData.instance.getTempGold() + "";
        }
    }

    void DecreaseTime()
    {
        if (theTime >= 0.5)
        {
            theTime -= Time.deltaTime * 1;
        }
        string second = Mathf.Floor((theTime % 60)).ToString("00");
        string minute = Mathf.Floor((theTime / 60) % 60).ToString("00");
        time.text = minute + " : " + second;

        if (theTime <= 0.5)
        {
            leveldone.stop = false;
            Time.timeScale = 0;
            FindObjectOfType<GameManager>().gameEnd();
        }
    }
}
