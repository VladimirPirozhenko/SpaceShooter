using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BackgroundScrolling : MonoBehaviour
{
    [SerializeField] private Vector2 defaultVelocity;
    private Vector2 velocity;
    [SerializeField] private Vector2 startingOffset;
    private Renderer bgTexRenderer;
    private bool canIncreaseVelocity = true;
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

    public void IncreaseVelocity(Vector2 velocity)
    {
        if (!canIncreaseVelocity)
            return;
        this.velocity += velocity*0.1f;
        canIncreaseVelocity = false;
    }
    public void ResetToDefault()
    {
        velocity = defaultVelocity;
        canIncreaseVelocity = true;
    }
}
