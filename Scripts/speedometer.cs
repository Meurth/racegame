using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class speedometer : MonoBehaviour {

    public Rigidbody2D objectToMeasure;
    public float maxVelocity = 10f;

    private Image image;

    // Use this for initialization
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        image.fillAmount = objectToMeasure.velocity.magnitude / maxVelocity;
    }
}
