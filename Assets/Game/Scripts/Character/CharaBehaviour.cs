using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaBehaviour : MonoBehaviour
{
    [SerializeField] protected CharaData data;
    [SerializeField] protected Vector2 direction, lastDirection;
    [SerializeField] protected float startDashTime, dashTime;

    protected bool isDashed, canDash;
    [SerializeField] protected float dashDelay;
    [SerializeField] protected Rigidbody2D rb;

    [SerializeField] protected float timeMoveElapsed;
    [SerializeField] protected bool isAccelerating;
    [SerializeField] protected float timeToStop;

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

    public void Stun()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("Enemy Hit!");
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
