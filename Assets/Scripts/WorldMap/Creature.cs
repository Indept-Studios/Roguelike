using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class Creature : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 lookDirection;

    private Rigidbody2D go_rb2d;
    private BoxCollider2D go_BoxCollider;

    [SerializeField] private bool isPlayerControlled = false;


    private void Awake()
    {
        go_rb2d = GetComponent<Rigidbody2D>();
        go_BoxCollider = GetComponent<BoxCollider2D>();
        go_rb2d.gravityScale = 0;
        go_rb2d.freezeRotation = true;
    }

    void Start()
    {
        if (isPlayerControlled)
        {
            go_BoxCollider.isTrigger = true;
        }
    }
    void Update()
    {
        if (!isPlayerControlled)
        {
            NPCLookAt();
        }
        else
        {
            PlayerLookAt();
        }
    }

    void PlayerLookAt()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - transform.position;
        transform.rotation = Quaternion.Euler(new Vector3(lookDirection.x, lookDirection.y));
    }
    void NPCLookAt()
    {
        //some LookAt code
    }
}
