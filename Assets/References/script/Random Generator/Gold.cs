using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public IntValue amount;
    public ParticleSystem partikel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            if (!partikel.isPlaying)
            {
                partikel.Play();
            }
            GameData.instance.addTempGold(amount.initialValue);
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitDestroy());
        }
    }

    public IEnumerator waitDestroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
