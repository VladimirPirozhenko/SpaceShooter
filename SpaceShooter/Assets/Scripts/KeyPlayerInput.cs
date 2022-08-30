using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlayerInput : IPlayerInput
{
     public Vector2 ReadMovement()
     {
         return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
     }

}
