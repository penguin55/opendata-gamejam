using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBehaviour : MonoBehaviour
{
    [SerializeField] protected CharaData data;
    [SerializeField] protected Vector2 direction, lastDirection;
    [SerializeField] protected float startDashTime, dashTime;

    protected bool isDashed, canDash, dead, insight = false;
    [SerializeField] protected float dashDelay;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float timeMoveElapsed;
    [SerializeField] protected bool isAccelerating;
    [SerializeField] protected float timeToStop;

    private GameObject enemy;

    public void Init()
    {
        data.Hp = 100;
        canDash = true;
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
    }


    protected void MoveAccelerate()
    {
        if (isAccelerating)
        {
            Movement(1);
        }
        else
        {
            Stop();
            Movement(timeMoveElapsed / timeToStop);
        }
    }

    protected void Movement(float accelerate)
    {
        transform.Translate(direction * data.Speed * Time.deltaTime * accelerate);
    }


    private void Stop()
    {
        timeMoveElapsed -= Time.deltaTime;

        if (timeMoveElapsed <= 0) timeMoveElapsed = 0;
    }

    protected void Dash()
    {
        if (lastDirection != Vector2.zero && isDashed)
        {
            if (dashTime <= 0)
            {
                rb.velocity = Vector2.zero;
                isDashed = false;
                data.IsDashing = false;
                StartCoroutine(Delay());
            }
            else
            {
                dashTime -= Time.deltaTime;
                rb.velocity = lastDirection * data.DashSpeed;
            }
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(this.dashDelay);
        canDash = true;
    }

    public void TakeDamage()
    {
        if (playerData.hp >= 1)
        {
            
            playerData.hp -= 1;
            InGameUIManager.instance.uilive();

            if (playerData.hp < 1)
            {
                dead = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemy = collision.gameObject;
            insight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enemy = null;
        insight = false;
    }

    public void Detect(bool insight)
    {
        if (insight)
        {
            double distance = Math.Sqrt(Math.Pow(this.transform.position.x - enemy.transform.position.x, 2)
            + Math.Pow(this.transform.position.y - enemy.transform.position.y, 2));

            Debug.Log("distance : " + distance);
            if (distance < 3)
            {
                StartCoroutine(Damage());
            }
        }
    }

    IEnumerator Damage()
    {
        TakeDamage();
        yield return new WaitForSeconds(3f);
    }

}
