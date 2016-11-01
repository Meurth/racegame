using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Autocontrol : MonoBehaviour {

    float speedForce = 5f;
    float torqueForce = -200f;
    float driftFactor = 0.8f;
    float speedboostfactor = 1f;
    public float gas = 1000f;
    public int pitstops;
    
    

    // Use this for initialization
    void Start() {
    }

    void update()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Debug.Log(pitstops);


        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;


        if (Input.GetButton("accelerate")) {
            rb.AddForce(transform.right * speedForce * speedboostfactor);
        }

        if (Input.GetButton("brake"))
        {
            rb.AddForce(transform.right * (-speedForce * speedboostfactor));
        }
        if (Input.GetButton("brake") || Input.GetButton("accelerate"))
        {
            if (gas > 0)
            {
                gas = gas - 1;
            }
        }


        if (gas > 0)
        {
            speedForce = 5f;
        }
        else
        {
            speedForce = 2f;
        }





            //Niet sturen als er geen snelheid is, werkt nog niet
           // float tf = Mathf.Lerp(0, torqueForce, rb.velocity.magnitude / 5);

 

            rb.angularVelocity = ((Input.GetAxis("Horizontal") * torqueForce) * (rb.velocity.magnitude / 5) );


    } //Einde FixedUpdate loop


	Vector2 ForwardVelocity() {
		return transform.right * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.right);
	}

	Vector2 RightVelocity() {
		return transform.up * Vector2.Dot (GetComponent<Rigidbody2D>().velocity, transform.up);
	}




    //speedboost
    void OnTriggerStay2D(Collider2D other)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (other.gameObject.tag == "PickUp")
        {
            StartCoroutine(speedBoost());
        }
        if (other.gameObject.tag == "PitStop" && rb.velocity.magnitude < 1 && rb.velocity.magnitude > -1)
        {
            StartCoroutine(PitStop());
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PitStop")
        {
            pitstops++;
        }
    }







    IEnumerator speedBoost()
    {
        speedboostfactor = 2f;
        yield return new WaitForSeconds(3f);
        speedboostfactor = 1f;
    }


    IEnumerator PitStop()
    {

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        {
            while (gas < 1000)
            {
                yield return new WaitForSeconds(.1f);
                gas = gas + 1f;
            }


            yield return new WaitForSeconds(.1f);
        }
    }


}
