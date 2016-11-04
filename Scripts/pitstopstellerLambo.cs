using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pitstopstellerLambo : MonoBehaviour {

    public AutocontrolLambo auto;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text pitstopst = GetComponent<Text>();
        pitstopst.text = ("PitStops: " + auto.pitstops);
    }
}
