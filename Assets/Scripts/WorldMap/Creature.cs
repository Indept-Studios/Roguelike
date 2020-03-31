using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(InputController))]

public abstract class Creature : MonoBehaviour
{
    [SerializeField] protected InputController inputController;

    protected float angel;

    protected int lifePoints = 100;
    protected int actionsPoints = 100;
    protected int experiencePoints = 0;

    protected Vector2 lookDirection;
    protected Rigidbody2D rb2d;

    protected float MoveSpeed { get; set; } = 5f;
    protected virtual void Move() { }
    public virtual void Shoot() { }
}
