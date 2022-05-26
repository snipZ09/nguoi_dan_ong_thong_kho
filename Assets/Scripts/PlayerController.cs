using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    public float moveSpeed;
    float activeMoveSpeed;
    public Rigidbody rb;
    Vector2 moveInput;
    public bool isAI = false;
    public bool canMove;
    Vector3 moveDirection;
    public GameObject trigTrap;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        activeMoveSpeed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAI)
        {
            moveInput.x = Input.GetAxisRaw("Horizontal");
            moveInput.y = Input.GetAxisRaw("Vertical");
            moveInput.Normalize();

            transform.position += new Vector3(moveInput.x * Time.deltaTime * moveSpeed, 0f, moveInput.y * Time.deltaTime * moveSpeed);
        }
        else
        {
            if (PlayerController.instance.gameObject.activeInHierarchy && canMove)
            {
                moveDirection = Vector3.zero;
                if (!LevelManager.instance.haveKey)
                {
                    if (Vector3.Distance(transform.position, LevelManager.instance.key.transform.position) > 1f)
                    {
                        moveDirection = LevelManager.instance.key.transform.position - transform.position;
                        transform.LookAt(LevelManager.instance.key.transform);
                    }
                }
                else
                {
                    if (Vector3.Distance(transform.position, LevelManager.instance.exitLevel.transform.position) > 1f)
                    {
                        moveDirection = LevelManager.instance.exitLevel.transform.position - transform.position;
                        transform.LookAt(LevelManager.instance.exitLevel.transform);
                    }
                }
                   
            }
            //float angle = Mathf.Atan2(moveDirection.z, moveDirection.x) * Mathf.Rad2Deg - 90;
            //Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.up);
            //transform.rotation = Quaternion.Slerp(transform.rotation, angleAxis, Time.deltaTime * 50);
            moveDirection.Normalize();
            //rb.velocity = moveDirection * moveSpeed;
            if (!canMove)
            {
                moveDirection = Vector3.zero;
            }
            transform.position += new Vector3(moveDirection.x * Time.deltaTime * moveSpeed, 0f, moveDirection.z * Time.deltaTime * moveSpeed);

        }
    }

    public void isHit()
    {
        Destroy(gameObject);
    }
    
}
