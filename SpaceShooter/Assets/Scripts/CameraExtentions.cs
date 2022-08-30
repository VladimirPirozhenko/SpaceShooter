using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraExtentions 
{
    public static Vector2 GetScreenBounds2D(this Camera camera)
    {
        return camera.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,camera.transform.position.z));
    }
}
