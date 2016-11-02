using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class opennainvoer : MonoBehaviour {

    public void NewGame(string newGameLevel)
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
