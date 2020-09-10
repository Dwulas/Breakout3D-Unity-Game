using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle2 : MonoBehaviour
{
    public float paddleSpeed = 5f;
    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);     // Restricting xPos to not go over -8,+8
        transform.position = playerPos;
    }
}
