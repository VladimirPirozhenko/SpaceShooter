using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPlayerInput : IPlayerInput
{

    bool isShootButtonDown = false;

    public Vector2 ReadMovement()
    {
        return new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
    }

    public bool ReadShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShootButtonDown = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isShootButtonDown = false;
        }
        return isShootButtonDown;
    }

}
