using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
        // To check if player1 press the button (w/s)i.e. input set for Vertical and save that input 
        float directionY = Input.GetAxisRaw("Vertical");
        
        racketDirection = new Vector2(0,directionY).normalized;
    }

    // FixedUpdate is called once per physics frame and have components that must be applied on rigid object
    private void FixedUpdate()
    {
        rb.velocity = racketDirection * racketSpeed;
    }
}
