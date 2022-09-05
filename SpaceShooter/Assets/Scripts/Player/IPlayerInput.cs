using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerInput 
{
    public Vector2 ReadMovement();

    public bool ReadShootInput();
}
