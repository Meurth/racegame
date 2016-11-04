using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class lapstellerLambo : MonoBehaviour {

    public AutocontrolLambo auto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text lapstext = GetComponent<Text>();
        lapstext.text = ("Laps: " + auto.laps);
	}
}
