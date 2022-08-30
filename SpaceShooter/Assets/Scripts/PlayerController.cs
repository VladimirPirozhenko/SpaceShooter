using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float smoothTime;
    [SerializeField] private BackgroundScrolling scrolling;
    private IPlayerInput playerInput;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerInput = new KeyPlayerInput();
    }
    private void Update()
    {
       Move();
    }



    //INSERT HERE ALL TYPES OF MOVEMENT
    public void Move()
    {
        Vector2 movementDirection = playerInput.ReadMovement();
      
       // float horizontalMovement = movementDirection.x * Time.deltaTime;
       // float verticalMovement = movementDirection.y * Time.deltaTime;
       // transform.Translate(horizontalMovement,verticalMovement,0);
       Vector3 targetVelocity = movementDirection * speed;
       Vector3 velocity = Vector3.zero;
       rb.velocity = Vector3.SmoothDamp(rb.velocity,targetVelocity,ref velocity,smoothTime);
       if (velocity == Vector3.zero)
            scrolling.ResetToDefault();
       scrolling.IncreaseVelocity(movementDirection);
       
    }
}
