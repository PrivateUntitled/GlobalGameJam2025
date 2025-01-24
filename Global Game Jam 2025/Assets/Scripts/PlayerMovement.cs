using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool jumped;

    [SerializeField] private GameObject bubble;
    [SerializeField, Min(2)] private float maxBubbleSize = 4.0f;
    private float minBubbleSize = 2.0f;
    private float bubbleSpeed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            jumped = true;
        }

        if (Input.GetKey(KeyCode.Q) && bubble.transform.localScale.x >= minBubbleSize)
        {
            bubble.transform.localScale = new Vector3(Mathf.Lerp(bubble.transform.localScale.x, minBubbleSize, bubbleSpeed), Mathf.Lerp(bubble.transform.localScale.y, minBubbleSize, bubbleSpeed), 2);
        }

        if (Input.GetKey(KeyCode.E) && bubble.transform.localScale.x <= maxBubbleSize)
        {
            bubble.transform.localScale = new Vector3(Mathf.Lerp(bubble.transform.localScale.x, maxBubbleSize, bubbleSpeed), Mathf.Lerp(bubble.transform.localScale.y, maxBubbleSize, bubbleSpeed), 2);
        }
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontal * 5, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumped = false;
    }
}
