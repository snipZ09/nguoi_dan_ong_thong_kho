using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public static Sphere instance;
    public float moveSpeed;
    public Rigidbody theRB;
    [Header("Patrolling")]
    public bool shouldPatrol;
    public Transform[] patrolPoint;
    int currentPatrolPoint;

    Vector3 moveDirection;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = Vector3.zero;

        if (shouldPatrol)
        {
            moveDirection = patrolPoint[currentPatrolPoint].position - transform.position;
            if (Vector3.Distance(transform.position, patrolPoint[currentPatrolPoint].position) < 0.8f)
            {
                currentPatrolPoint++;
                if (currentPatrolPoint >= patrolPoint.Length)
                {
                    currentPatrolPoint = 0;
                }
            }
        }
        moveDirection.Normalize();
        theRB.velocity = moveDirection * moveSpeed;

    }
}
