using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb;
    private Vector2 racketDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // To check if player2 press the button (up/down)i.e. input set for Vertical2 and save that input 
        float directionY = Input.GetAxisRaw("Vertical2");
       
        racketDirection = new Vector2(0,directionY).normalized;
    }

    // FixedUpdate is called once per physics frame and have components that must be applied on rigid object
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
