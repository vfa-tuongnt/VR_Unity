using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Movement speed
    public float speed = 5.0f;

    // Direction of movement
    private Vector2 moveDir = Vector2.zero;

    // Set the movement direction
    public void SetDirection(Vector2 dir)
    {
        moveDir = dir;
    }

    void Update()
    {
        // Get input from the keyboard then call SetDirection
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        SetDirection(new Vector2(moveX, moveY));

        // Move object using Translate method according to moveDir
        transform.Translate(moveDir * speed * Time.deltaTime);
    }
}
