using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
    public float baseSpeed = 0.3f;
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime * 1000;
        rigidBody.velocity = new Vector2(baseSpeed, 0) * delta;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EndScroll")
        {
            baseSpeed = 0;
        }
    }
}

