using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]

public abstract class Creature : MonoBehaviour
{
    protected Vector2 lookDirection;
    protected Rigidbody2D rb2d;

    
}
