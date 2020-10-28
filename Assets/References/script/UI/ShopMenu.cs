using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{
    public GameObject shopMenu, checkbox;
    public Text [] shopText;
    [TextArea] public string[] dialog;
    bool openMenu = false;
    public ShopSystem shop;

    public GameObject tutorialBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (openMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                shopMenu.SetActive(true);
                Time.timeScale = 0f;
                PauseMenu.GameIsPaused = true;
                tutorialBox.SetActive(false);
            }
                
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("buka shop menu");
        if (collision.gameObject.CompareTag("player"))
        {
            openMenu = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        openMenu = false;
    }

    public void DetailText()
    {
        shopText[0].text = dialog[0];
    }

    public void nullDetail()
    {
        shopText[0].text = "";
    }

    public void BuyText()
    {
        shopText[1].text = dialog[1];
    }

    public void nullBuy()
    {
        shopText[1].text = "";
    }

    public void back()
    {
        shopMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
        tutorialBox.SetActive(true);
    }

    public void buyLife(int cointrequirement)
    {
        PlayerInventory playerInventory = playerhp.instance.GetPlayerInventory();
        int codeMessage = shop.BuyLife(cointrequirement);
        if (codeMessage == 0)
        {
            Debug.Log("harusnya masuk");
            shopText[2].text = dialog[3];
            checkbox.SetActive(true);
        }
        else if (codeMessage == -1)
        {
            shopText[2].text = dialog[2];
            checkbox.SetActive(true);
        }
        else
        {
            playerInventory.coin -= cointrequirement;
        }
    }

    public void buySpeed(int cointrequirement)
    {

        PlayerInventory playerInventory = playerhp.instance.GetPlayerInventory();
        int codeMessage = shop.BuySpeed(cointrequirement);
        if (codeMessage == 0)
        {
            shopText[2].text = dialog[4];
            checkbox.SetActive(true);
        }
        else if (codeMessage == -1)
        {
            shopText[2].text = dialog[2];
            checkbox.SetActive(true);
        }
        else
        {
            playerInventory.coin -= cointrequirement;
        }
    }

}
