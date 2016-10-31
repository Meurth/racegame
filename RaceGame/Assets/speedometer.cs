using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class speedometer : MonoBehaviour {

    private Rigidbody2D objectToMeasure;
    public float maxVelocity = 10.0f;

    private Image image;
	void Start () {
        image = GetComponent<Image>();
	}


    void Update()
    {

        {
            image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity;


        }
    }
}
