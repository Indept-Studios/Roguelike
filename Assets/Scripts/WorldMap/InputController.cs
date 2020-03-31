using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour, IMovementInput
{
    public float HorizontalInput { get; set; }
    public float VerticalInput { get; set; }



    void FixedUpdate()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vertical");
    }
}
