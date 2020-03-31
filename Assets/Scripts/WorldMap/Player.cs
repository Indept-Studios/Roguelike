using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Creature
{
    private Vector2 movementInput;
    public GameObject firePoint;
    public GameObject bulletPrefab;

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

    protected override void Move()
    {
        movementInput = new Vector2(inputController.HorizontalInput, inputController.VerticalInput);
        rb2d.velocity = movementInput.normalized * MoveSpeed;
    }
    public override void Shoot()
    {
        GameObject goBullet;
        Rigidbody2D rbBullet;

        goBullet = Instantiate(bulletPrefab, transform.position, firePoint.transform.rotation);
        rbBullet = goBullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(firePoint.transform.up * 40f, ForceMode2D.Impulse);
        Destroy(goBullet, 5f);
    }
}
