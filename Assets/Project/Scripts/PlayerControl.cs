using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    // Movement speed
    public float speed = 5.0f;

    // Direction of movement
    private Vector2 moveDir = Vector2.zero;

    void Update()
    {
        // Get input from the keyboard then call SetDirection
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Move object using Translate method according to moveDir
        transform.Translate(new Vector3(moveX, 0, moveY) * speed * Time.deltaTime);
    }
}
