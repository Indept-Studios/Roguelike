using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    [SerializeField] private Vector2 movementInput;

    private Rigidbody2D go_rb2d;

    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool isPlayerControlled = false;

    void Start()
    {
        go_rb2d = GetComponent<Rigidbody2D>();
        go_rb2d.gravityScale = 0;
    }

    void FixedUpdate()
    {
        if (!isPlayerControlled)
        {
            InvokeRepeating("NPCMovement", 1f, 4f);
        }
        else
        {
            PlayerMovement();
        }
    }

    void PlayerMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(horizontalInput, verticalInput);
        go_rb2d.velocity = movementInput.normalized * moveSpeed;
    }
    void NPCMovement()
    {
        horizontalInput = Random.Range(-1, 2);
        verticalInput = Random.Range(-1, 2);
        movementInput = new Vector2(horizontalInput, verticalInput);
        go_rb2d.velocity = movementInput.normalized * moveSpeed;
    }
}
