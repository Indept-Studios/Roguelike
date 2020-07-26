using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float destroyAfterSeconds = .5f;
    [SerializeField] private float go_Bulle_Speed = 10f;
    [SerializeField] private bool isPlayerControlled = false;
    [SerializeField] private float damagePerHit = -10f;

    private Vector3 mousePosition;
    private Vector2 shootDirection;

    private GameObject firePoint;
    private GameObject bulletPrrefab;
    private GameObject bullet;
    private Rigidbody2D bullet_rb2d;

    public float DamagePerHit { get => damagePerHit; set => damagePerHit = value; }

    void Start()
    {
        FirePointInstantiation();
    }

    void Update()
    {
        LookAtShootPoint();
        if (!isPlayerControlled)
        {
            NPCShoot();
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                PlayerShoot();
            }
        }
    }

    void FirePointInstantiation()
    {
        firePoint = new GameObject();
        firePoint.transform.parent = gameObject.transform;
        firePoint.transform.position = gameObject.transform.position;
        firePoint.name = "FirePoint";

        bulletPrrefab = Resources.Load<GameObject>("Prefabs/BulletPrefab");
    }

    void LookAtShootPoint()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDirection = mousePosition - firePoint.transform.position;
        firePoint.transform.rotation = Quaternion.Euler(new Vector3(shootDirection.x, shootDirection.y));
    }

    void PlayerShoot()
    {
        bullet = Instantiate(bulletPrrefab, firePoint.transform.position, firePoint.transform.rotation, firePoint.transform);
        bullet.name = "Bullet";
        bullet_rb2d = bullet.GetComponent<Rigidbody2D>();
        shootDirection = new Vector2((firePoint.transform.rotation.x), (firePoint.transform.rotation.y)).normalized;
        bullet_rb2d.AddForce((shootDirection * go_Bulle_Speed), ForceMode2D.Impulse);
        Destroy(bullet, destroyAfterSeconds);
    }

    void NPCShoot()
    {
        //some code here
    }
}
