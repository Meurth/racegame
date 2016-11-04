using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pitstopsteller : MonoBehaviour {

    public Autocontrol auto;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Text pitstopst = GetComponent<Text>();
        pitstopst.text = ("PitStops: " + auto.pitstops);
    }
}
