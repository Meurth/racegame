using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AutocontrolLambo : MonoBehaviour {

    public float speedForce = 5f;
    float torqueForce = -200f;
    float driftFactor = 0.9f;
    float speedboostfactor = 1f;
    public float gas = 2000f;
    public int pitstops;


    public bool checkpoint1 = false;
    public bool checkpoint2 = false;
    public bool checkpoint3 = false;
    public bool checkpoint4 = false;

    public int laps = 0;
    public int playernumber = 2;
    public int checkpteller = 0;
    public float speed = 0;
    public bool lambostart = false;


    // Use this for initialization
    void Start() {

    }

    void update()
    {
    
    }

    // Update is called once per frame
    void FixedUpdate() {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        AudioSource audio = GetComponent<AudioSource>();
        
        StartCoroutine(countdowntimer());

        audio.pitch = rb.velocity.magnitude / 6f + .6f;

        rb.velocity = ForwardVelocity() + RightVelocity() * driftFactor;


        if (Input.GetButton("accelerate2") && lambostart) {
            rb.AddForce(transform.right * speedForce * speedboostfactor);
            if (speed < 4)
            {
                speed++;
            }
        }

        if (Input.GetButton("brake2") && lambostart)
        {
            rb.AddForce(transform.right * (-speedForce * speedboostfactor));
            if (speed > -4)
            {
                speed--;
            }
        }






        if (Input.GetButton("brake2") || Input.GetButton("accelerate2"))
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




        if (speed > 0)
        {
            rb.angularVelocity = ((Input.GetAxis("Horizontal2") * torqueForce) * (rb.velocity.magnitude / 5));
        }
        else if (speed < 0)
        {
            rb.angularVelocity = ((-Input.GetAxis("Horizontal2") * torqueForce) * (rb.velocity.magnitude / 5));
        }




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



        if (other.gameObject.name == "CheckPoint1")
        {
            checkpoint1 = true;

        }
        if (other.gameObject.name == "CheckPoint2")
        {
            checkpoint2 = true;

        }
        if (other.gameObject.name == "CheckPoint3")
        {
            checkpoint3 = true;

        }
        if (other.gameObject.name == "CheckPoint4")
        {
            checkpoint4 = true;
            StartCoroutine(lapschecker());

        }


    }


    void OnTriggerEnter2D(Collider2D other)
    {

    }












    IEnumerator lapschecker()
    {
        if (checkpoint1 && checkpoint2 && checkpoint3 && checkpoint4)
        {
            laps++;


            checkpoint1 = false;
            checkpoint2 = false;
            checkpoint3 = false;
            checkpoint4 = false;
            yield return new WaitForSeconds(1f);



        }

    }



    IEnumerator speedBoost()
    {
        speedboostfactor = 1.3f;
        driftFactor = .92f;
        yield return new WaitForSeconds(3f);
        speedboostfactor = 1f;
        driftFactor = 0.9f;
    }


    IEnumerator PitStop()
    {
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            while (rb.velocity.magnitude < 1 && rb.velocity.magnitude > -1 && gas < 2000)
            {
                if (gas < 2000f)
                {
                    yield return new WaitForSeconds(.1f);
                    gas = gas + 1f;
                }
            }


            yield return new WaitForSeconds(.1f);
        }
    }



    IEnumerator countdowntimer()
    {
        yield return new WaitForSeconds(4.5f);
        lambostart = true;
    }


}
