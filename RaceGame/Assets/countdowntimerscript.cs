using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class countdowntimerscript : MonoBehaviour {
    public float timercount = 0f;

    // Use this for initialization
    void Start () {


        StartCoroutine(timertje());
        


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
