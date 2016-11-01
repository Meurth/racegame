using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class winscript : MonoBehaviour {


    public Autocontrol auto;
    public AutocontrolLambo lambo;

    public bool autowins = false;
    public bool lambowins = false;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if ((auto.laps == 3) && (lambowins == false))
        {
            Text wintext = GetComponent<Text>();
            wintext.text = ("Player: " + auto.playernumber + " wins!");
            autowins = true;
        }

        if ((lambo.laps == 3) && (autowins == false))
        {
            Text wintext = GetComponent<Text>();
            wintext.text = ("Player: " + lambo.playernumber + " wins!");
            lambowins = true;
        }

    }
}
