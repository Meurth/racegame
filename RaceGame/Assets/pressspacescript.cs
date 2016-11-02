using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class pressspacescript : MonoBehaviour {


    public winscript winscc;


    // Use this for initialization

    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	       if (winscc.autowins || winscc.lambowins)
        {
            Text spacetext = GetComponent<Text>();
            spacetext.text = "Press space to continue..";
        }
	}
}
