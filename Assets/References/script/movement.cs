using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour
{
    public ParticleSystem dust;
    // Start is called before the first frame update
    private Vector2 arah;
    public Animator animator;
    GameObject[] npc;
    public GameObject player;
    public PlayerInventory playerInventory;
    public float debugSpeed;
    public static movement instance;
    public bool loading, loaddone,move;

    public PlayerInfo info;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateSpeed();
        loading = true;
        move = false;
        loaddone = false;
        npc = GameObject.FindGameObjectsWithTag("NPC");
        info.UpdatePlayer();
    }

    public IEnumerator spawn()
    {
        loading = false;
        yield return new WaitForSeconds(0.3f);
        animator.SetBool("start", true);
        FindObjectOfType<AudioManager>().Play("Spawning");
        yield return new WaitForSeconds(0.8f);
        animator.SetBool("start", false);
        yield return new WaitForSeconds(1f);
        loaddone = true;
    }
    void Update()
    {
        if (!LevelLoader.instance.isLoading && loading)
        {
            StartCoroutine(spawn());
        }

        
        if (PauseMenu.GameIsPaused)
        {
            return;
        }
        if(move) movementplayer();
    }

    void movementplayer()
    {
        arah = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
        {
            arah += Vector2.up;
            createDust();
            FindObjectOfType<AudioManager>().Play("Steps_Pig");
        }
        if (Input.GetKey(KeyCode.S))
        {
            arah += Vector2.down;
            createDust();
            FindObjectOfType<AudioManager>().Play("Steps_Pig");
        }
        if (Input.GetKey(KeyCode.D))
        {
            arah += Vector2.right;
            createDust();
            FindObjectOfType<AudioManager>().Play("Steps_Pig");
        }
        if (Input.GetKey(KeyCode.A))
        {
            arah += Vector2.left;
            createDust();
            FindObjectOfType<AudioManager>().Play("Steps_Pig");
        }
        float walk = arah.x;
        float jalan = arah.y;
        transform.Translate(arah * playerData.speed * Time.deltaTime);
        animator.SetFloat("speed", Mathf.Abs(walk*playerData.speed));
        animator.SetFloat("kecepatan", Mathf.Abs(jalan * playerData.speed));
    }
    void createDust()
    {
        dust.Play();
    }
    void orderLayer()
    {
        foreach (GameObject n in npc)
        { 
            if(player.transform.position.y < n.transform.position.y)
            {
                Debug.Log("depan");
                player.GetComponent<SpriteRenderer>().sortingOrder = 1;
            }
            if (player.transform.position.y  > n.transform.position.y)
            {
                Debug.Log("belakang");
                player.GetComponent<SpriteRenderer>().sortingOrder = -1;
            }
        }
    }

    public void UpdateSpeed()
    {
        playerData.speed = playerData.baseSpeed + (playerData.upgradeSpeed*0.25f*playerData.baseSpeed);
        debugSpeed = playerData.speed;
        info.UpdatePlayer();
    }

    public void DisUpdateSpeed()
    {
        playerData.speed = playerData.baseSpeed - (playerData.upgradeSpeed * 0.25f * playerData.baseSpeed);
        debugSpeed = playerData.speed;
        playerData.upgradeSpeed = 0;
        playerData.isUpgrade = false;
        info.UpdatePlayer();
    }

    public void Upgradespeed()
    {
        if (playerData.upgradeSpeed < 1)
        {
            playerData.upgradeSpeed++;
            playerData.isUpgrade = true;
        }
    }

    public bool isMaxspeed()
    {
        return playerData.upgradeSpeed == playerData.maxUpgradeSpeed;
    }
   

}
