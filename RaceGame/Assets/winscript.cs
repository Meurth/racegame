using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class winscript : MonoBehaviour {


    public Autocontrol auto;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (auto.laps == 3)
        {
            Text wintext = GetComponent<Text>();
            wintext.text = ("Player: " + auto.playernumber + " wins!");
        }
    }
}
