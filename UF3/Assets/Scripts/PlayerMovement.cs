using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };

    public Direction playerDirection = Direction.NONE;

    public float baseSpeed = 0.3f;
    private float currentSpeedV = 0.0f;
    private float currentSpeedH = 0.0f;
    private Rigidbody2D rigidBody;

    public static PlayerMovement Instance { get; private set; }

    public float jump;
    public bool grounded;

    private bool faceR = true;

    private KeyCode jumpButton = KeyCode.Space;
    private KeyCode leftButton = KeyCode.A;
    private KeyCode rightButton = KeyCode.D;

    private KeyCode quitButton = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(leftButton))
        {
            if (grounded)
            {
                rigidBody.AddForce(transform.up * jump, ForceMode2D.Impulse);
            }
        }
        
        if (Input.GetKey(leftButton))
        {

            playerDirection = Direction.LEFT;
        }
        else if (Input.GetKey(rightButton))
        {

            playerDirection = Direction.RIGHT;
        }

        if (Input.GetKey(quitButton))
        {
            Application.Quit();
        }
    }

    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;

        currentSpeedV = 0;
        currentSpeedH = 0;

        switch (playerDirection)
        {
            default: 
                break;
            case Direction.LEFT:
                currentSpeedH = -baseSpeed;
                break;
            case Direction.RIGHT:
                currentSpeedH = baseSpeed;
                break;
        }
        rigidBody.velocity = new Vector2(currentSpeedH, currentSpeedV) * delta;

        if (faceR == false && currentSpeedH == baseSpeed)
        {
            Face();
        }
        else if (faceR == true && currentSpeedH == -baseSpeed)
        {
            Face();
        }
    }
    void Face()
    {
        faceR = !faceR;
        Vector3 Flip = transform.localScale;
        Flip.x = -Flip.x;
        transform.localScale = Flip;
    }

    void OnCollisionEnter2D()
    {
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Ground"))
        //{

        //}
    }
}
