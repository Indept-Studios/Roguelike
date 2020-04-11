using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMovement 
{
    float HorizontalInput { get; set; }
    float VerticalInput { get; set; }
    float MoveSpeed { get;  set; }

    void Move();

   }
