using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class winscript : MonoBehaviour {


    public Autocontrol auto;
    public AutocontrolLambo lambo;
    public namesaverscript names;


    public bool autowins = false;
    public bool lambowins = false;
    string newGameLevel = "level1";

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if ((auto.laps == 3) && (lambowins == false))
        {
            Text wintext = GetComponent<Text>();
            wintext.text = (names.player1name + " wins!");
            autowins = true;
        }

        if ((lambo.laps == 3) && (autowins == false))
        {
            Text wintext = GetComponent<Text>();
            wintext.text = (names.player2name + " wins!");
            lambowins = true;
        }

        if (lambowins || autowins)
        {
            auto.speedForce = 0f;
            lambo.speedForce = 0f;
            backtomenu();
        }

    }

    void backtomenu()
    {

        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(newGameLevel);
        }
    }


}
