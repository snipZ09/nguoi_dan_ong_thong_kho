using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [Header("Wandering")]
    public bool shouldWander;
    public float wanderLength, pauseLength;
    float wanderCounter, pauseCounter;
    Vector3 wanderDirection;
    Vector3 moveDirection;
    public float moveSpeed;

    private void Start()
    {
        if (shouldWander)
        {
            pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
        }
    }

    private void Update()
    {
        if (shouldWander)
        {
            if (wanderCounter > 0)
            {
                wanderCounter -= Time.deltaTime;

                //move the enemy
                moveDirection = wanderDirection;

                if (wanderCounter <= 0)
                {
                    pauseCounter = Random.Range(pauseLength * 0.75f, pauseLength * 1.25f);
                }
            }

            if (pauseCounter > 0)
            {
                pauseCounter -= Time.deltaTime;

                if (pauseCounter <= 0)
                {
                    wanderCounter = Random.Range(wanderLength * 0.75f, wanderLength * 1.25f);
                    wanderDirection = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
                }
            }
        }

        moveDirection.Normalize();
        transform.position += new Vector3(moveDirection.x * Time.deltaTime * moveSpeed, 0f, moveDirection.z * Time.deltaTime * moveSpeed);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.haveKey = true;
            Destroy(gameObject);
        }
    }
}
