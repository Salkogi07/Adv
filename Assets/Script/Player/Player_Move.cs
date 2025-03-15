using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    float inputX;
    float inputY;

    public float moveSpeed = 5f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveX();
        MoveY();
    }

    private void MoveY()
    {
        inputY = 0;
        if (Input.GetKey(KeyCode.W))
            inputY = 1;
        if (Input.GetKey(KeyCode.S))
            inputY = -1;
    }

    private void MoveX()
    {
        inputX = 0;
        if (Input.GetKey(KeyCode.A))
            inputX = -1;
        if (Input.GetKey(KeyCode.D))
            inputX = 1;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(inputX, inputY) * moveSpeed;
    }
}
