using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    string sceneToLoad; //The name of the scene you want to load

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LoadLevel();
        }
	}

    public void LoadLevel() {
        if (sceneToLoad != null) {
            SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        }
    }
}
