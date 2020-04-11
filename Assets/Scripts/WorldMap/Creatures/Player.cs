using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature, IMovement, IShootable
{
    private Vector2 movementInput;
    private Vector2 shootDirection;

    [SerializeField] private float moveSpeed = 2f;

    public GameObject firePoint;
    public GameObject bulletPrefab;

    //both variabels must be deleted after removing Shoot()
    public float destroyAfterSeconds = 2f;
    public float goBulletSpeed = 100f;


    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }
    public float MoveSpeed { get => moveSpeed; set { moveSpeed = value; } }

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
        movementInput = new Vector2(HorizontalInput, VerticalInput);
        rb2d.velocity = movementInput.normalized * MoveSpeed;
    }

    public void Shoot()
    {
        GameObject goBullet;
        Rigidbody2D rbBullet;

        goBullet = Instantiate(bulletPrefab, transform.position, firePoint.transform.rotation);
        rbBullet = goBullet.GetComponent<Rigidbody2D>();
        shootDirection = new Vector2((firePoint.transform.rotation.x), (firePoint.transform.rotation.y)).normalized;
        rbBullet.AddForce((shootDirection * goBulletSpeed), ForceMode2D.Impulse);
        Destroy(goBullet, destroyAfterSeconds);
    }

    void IMovement.Move()
    {
        throw new System.NotImplementedException();
    }
}
