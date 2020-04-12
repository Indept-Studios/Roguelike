using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 lookDirection;

    private Rigidbody2D go_rb2d;
    private BoxCollider2D go_BoxCollider;

    [SerializeField] private bool isPlayerControlled = false;

    void Start()
    {
        go_rb2d = new Rigidbody2D();
        go_BoxCollider = new BoxCollider2D();
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
