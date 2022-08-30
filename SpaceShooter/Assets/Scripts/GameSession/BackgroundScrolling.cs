using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 defaultVelocity; 
    [SerializeField] private Vector2 startingOffset; 
    private Vector2 velocity;
    private Renderer bgTexRenderer;
    void Start()
    {
        bgTexRenderer = GetComponent<Renderer>();
        velocity = defaultVelocity;
    }

    void Update()
    {
        Vector2 textureOffset = startingOffset + new Vector2(Time.time*velocity.x,Time.time*velocity.y);
        bgTexRenderer.material.mainTextureOffset = textureOffset;
    }

    public void ResetToDefault()
    {
        velocity = defaultVelocity;
    }
}
