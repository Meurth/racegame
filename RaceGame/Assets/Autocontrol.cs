using UnityEngine;
using System.Collections;

public class Autocontrol : MonoBehaviour {

    float speedForce = 10f;
    float torqueForce = -200f;
    float driftFactor = 0.8f;
    int gas = 100;

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


        if (Input.GetButton("accelerate")) {
            rb.AddForce(transform.right * speedForce);
        }

        if (Input.GetButton("brake"))
        {
            rb.AddForce(transform.right * (-speedForce));   
        }


            //Niet sturen als er geen snelheid is, werkt nog niet
            float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 5);

 

            rb.angularVelocity = (Input.GetAxis("Horizontal") * torqueForce * (rb.velocity.magnitude/5));


    }


	Vector2 ForwardVelocity() {
		return transform.right * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.right);
	}

	Vector2 RightVelocity() {
		return transform.up * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.up);
	}

    //speedboost
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            StartCoroutine(speedBoost());
        }
        if (other.gameObject.tag == "PitStop")
        {
            StartCoroutine(PitStop());
        }



    }

    IEnumerator speedBoost()
    {
       speedForce = 40f;
       torqueForce = -200f;
       driftFactor = 0.8f;
        yield return new WaitForSeconds(3f);
        speedForce = 10f;
        torqueForce = -200f;
        driftFactor = 0.8f;
    }

    IEnumerator PitStop()
    {
        gas = gas + 1000000;
        yield return new WaitForSeconds(3f);
        Debug.Log(gas);
    }

}
