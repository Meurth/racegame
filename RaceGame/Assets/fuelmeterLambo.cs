using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fuelmeterLambo : MonoBehaviour {

    public AutocontrolLambo objectToMeasure;
    public float maxgass = 1000.0f;

    private Image image;


	// Use this for initialization
	void Start () {
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        image.fillAmount = objectToMeasure.gas/maxgass;
	}
}
