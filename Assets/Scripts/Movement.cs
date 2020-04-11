using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    
    [SerializeField] private Vector2 movementInput;
    
    private Rigidbody2D attached_rb2d;

    [SerializeField] private float moveSpeed =2f;
    [SerializeField] private bool isPlayerControlled = false;

    // Start is called before the first frame update
    void Start()
    {
        attached_rb2d = GetComponent<Rigidbody2D>();
        attached_rb2d.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        if (!isPlayerControlled)
        {
            InvokeRepeating("Test", 1f, 4f);
        }
        else
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");
            movementInput = new Vector2(horizontalInput, verticalInput);
            attached_rb2d.velocity = movementInput.normalized * moveSpeed;
        }
    }

    public void Test()
    {
        horizontalInput = Random.Range(-1, 2);
        verticalInput = Random.Range(-1, 2);
        movementInput = new Vector2(horizontalInput, verticalInput);
        attached_rb2d.velocity = movementInput.normalized * moveSpeed;
    }
}
