using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float paddleSpeed=5f;
    private Vector3 playerPos = new Vector3(0, -9.5f,0);
    private float extendShrinkDuration = 10;
    public float paddleWidth = 2;
    private SpriteRenderer sr;
    public float paddleHeight = 0.28f;

    private BoxCollider boxCol;
    private static Paddle _instance;
    public static Paddle Instance => _instance;
    public bool PaddleIsTransforming { get; set; }

    private void Start()
    {
        boxCol = GetComponent<BoxCollider>();
    }
    void Update()
    {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);     // Restricting xPos to not go over -8,+8
        transform.position = playerPos;
    }

    public void StartWidthAnimation(float newWidth)
    {
        StartCoroutine(AnimatePaddleWidth(newWidth));
    }
    public IEnumerator AnimatePaddleWidth(float width)
    {
        this.PaddleIsTransforming = true;
        this.StartCoroutine(ResetPaddleWidthAfterTime(this.extendShrinkDuration));

        if(width > this.sr.size.x)
        {
            float currentWidth = this.sr.size.x;
            while(currentWidth< width)
            {
                currentWidth += Time.deltaTime * 2;
                this.sr.size = new Vector3(currentWidth, paddleHeight, 0);
                boxCol.size = new Vector3(currentWidth, paddleHeight, 0);
                yield return null;
            }
        }
        else
        {
            float currentWidth = this.sr.size.x;
            while(currentWidth > width)
            {
                currentWidth -= Time.deltaTime * 2;
                this.sr.size = new Vector3(currentWidth, paddleHeight, 0);
                boxCol.size = new Vector3(currentWidth, paddleHeight, 0);
                yield return null;
            }
        }
        this.PaddleIsTransforming = false;
    }
    private IEnumerator ResetPaddleWidthAfterTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.StartWidthAnimation(this.paddleWidth);
    }
}
