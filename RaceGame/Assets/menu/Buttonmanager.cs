using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Buttonmanager : MonoBehaviour {

	public void NewGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
