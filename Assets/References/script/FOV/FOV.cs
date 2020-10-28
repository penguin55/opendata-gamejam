using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    [SerializeField] private float viewAngle;
    [SerializeField] private float viewRadius;
    Collider2D[] playerInRadius;
    [SerializeField] public LayerMask obstcaleMask, playerMask;
    public List<Transform> visiblePlayer = new List<Transform>();

    void FixedUpdate()
    {
        FindVisiblePlayer();
    }

    void FindVisiblePlayer()
    {
        playerInRadius = Physics2D.OverlapCircleAll(transform.position, viewRadius);

        for (int i = 0; i < playerInRadius.Length; i++)
        {
            Transform player = playerInRadius[i].transform;
            Vector2 dirPlayer = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);

            if (Vector2.Angle(dirPlayer, transform.right) < viewAngle / 2)
            {
                float distancePlayer = Vector2.Distance(transform.position, player.position);

                if (!Physics2D.Raycast(transform.position, dirPlayer, obstcaleMask))
                {
                    visiblePlayer.Add(player);
                }
            }
        }

    }

    public Vector2 dirFromAngle(float angleDeg, bool global)
    {
        if (!global)
        {
            angleDeg += transform.eulerAngles.z;
        }

        return new Vector2(Mathf.Sin(angleDeg * Mathf.Deg2Rad), Mathf.Cos(angleDeg * Mathf.Deg2Rad));
    }

    public float getViewRadius()
    {
        return viewRadius;
    }

    public float getViewAngle()
    {
        return viewAngle;
    }

}
