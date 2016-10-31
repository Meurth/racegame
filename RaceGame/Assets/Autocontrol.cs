using UnityEngine;
using System.Collections;

public class Autocontrol : MonoBehaviour {

    float speedForce = 10f;
    float torqueForce = -200f;
    float driftFactor = 0.8f;
    int gas = 1000;

    // Use this for initialization
    void Start() {
 
    }

    void update()
    {

    }

    // Update is called once per frame
    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();


        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;



        if (Input.GetButton("accelerate"))
            {
                rb.AddForce(transform.right * speedForce);
            }

        if (Input.GetButton("brake"))
        {
            rb.AddForce(transform.right * (-speedForce));
        }


        if (gas == 0)
        {
            speedForce = 2f;
        }

        if (Input.GetButton("accelerate") || Input.GetButton("brake"))
        {
            if (gas > 0)
            gas = gas - 1;
        }


        //niet sturen als snelheid == 0
    
       
        if (rb.velocity.magnitude < 0)
        {
            rb.angularVelocity = ((Input.GetAxis("Horizontal") * torqueForce * (rb.velocity.magnitude / 5)));
        }


        if (rb.velocity.magnitude > 0)
            {
            rb.angularVelocity = (Input.GetAxis("Horizontal") * torqueForce * (rb.velocity.magnitude / 5));
        }


 
     
        }






    //pitstop

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "PickUp")
        {
            gas = gas + 100;
        }
    }







    Vector2 ForwardVelocity() {
		return transform.right * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.right);
	}

	Vector2 RightVelocity() {
		return transform.up * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.up);
	}





}
