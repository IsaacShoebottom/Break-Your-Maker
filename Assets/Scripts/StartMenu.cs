using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
	public void quitGame() {
		Application.Quit();
	}

	public void startGame() {
		SceneManager.LoadScene("Level-1");
	}
}