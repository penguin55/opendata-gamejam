using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stun : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    bool allow = true;
    bool isStunning;
    [SerializeField] private Animator animator;
    float currenttime=0;
    [SerializeField] private Slider slider;
    [SerializeField] private GameObject sliderObject;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        leveldone.enemy = hitEnemies;
        if (Input.GetKeyDown(KeyCode.Space) && allow && !playerData.isUpgrade)
        {
            stunEnemy(hitEnemies);
        }
        if(isStunning) stunslider();
    }


    void stunEnemy(Collider2D [] hitEnemies)
    {
        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.tag == "Enemy")
            {
                isStunning = true;
                Debug.Log("we hit " + enemy.name);
                FindObjectOfType<AudioManager>().Play("Stun");
                StartCoroutine(animation());
                StartCoroutine(stunwhile(enemy));
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    IEnumerator stunwhile(Collider2D enemy)
    {
        
        enemy.GetComponent<detect>().enabled = false;
        enemy.GetComponent<AIPath>().enabled = false;
        enemy.GetComponent<detect>().stun(true);
        enemy.GetComponent<detect>().pursuit = false;
        enemy.GetComponent<detect>().normal = false;
        yield return new WaitForSeconds(5f);
        enemy.GetComponent<detect>().enabled = true;
        enemy.GetComponent<AIPath>().enabled = true;
        enemy.GetComponent<detect>().stun(false);
    }

    IEnumerator animation()
    {
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(0.9f);
        animator.SetBool("attack", false);
    }




    public void stunslider()
    {
        if (currenttime <= 5)
        {
            allow = false;
            sliderObject.SetActive(true);
            float progress = currenttime / 5f;
            slider.value = progress;
            currenttime += Time.deltaTime;
        }
        else
        {
            sliderObject.SetActive(false);
            currenttime = 0;
            allow = true;
            isStunning = false;
        }
    }
}
