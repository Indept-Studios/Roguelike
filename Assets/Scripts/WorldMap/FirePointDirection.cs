using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointDirection : MonoBehaviour, ILooktoPoint
{
    private Rigidbody2D attachedGameobject;

    private Vector3 mousePosition;
    public Vector2 lookDirection;

    private void Start()
    {
        attachedGameobject = GetComponentInParent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        LookAt();
    }

    public void LookAt()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = mousePosition - gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(lookDirection.x, lookDirection.y));
    }
}
