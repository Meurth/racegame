using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdowntimerscript : MonoBehaviour {

    public bool startcountdown = false;
    public bool startcountdown2 = false;
    // Use this for initialization
    void Start () {


        if (startcountdown)
        {
            StartCoroutine(timertje());
            AudioSource muziek = GetComponent<AudioSource>();
            muziek.Play();
        }


    }

    // Update is called once per frame
    void Update() {
      







    }


        IEnumerator timertje()
            {
        Text textcountdown = GetComponent<Text>();


       

        textcountdown.text = "Ready.";

        yield return new WaitForSeconds(1.5f);

        textcountdown.text = "Set.";

        yield return new WaitForSeconds(1.5f);

        textcountdown.text = "Go!";

        yield return new WaitForSeconds(1.5f);

        textcountdown.text = "";

    }



}
