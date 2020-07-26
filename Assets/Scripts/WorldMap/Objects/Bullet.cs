using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    float dmg;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        dmg = gameObject.GetComponentInParent<Shooting>().DamagePerHit;
        collision.transform.GetComponent<LifePoints>()?.ChangeLifeValue(dmg);
    }
}
