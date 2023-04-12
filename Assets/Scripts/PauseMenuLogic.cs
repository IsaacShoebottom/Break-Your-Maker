using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviour {
	private void Update() {
		// If the player presses the escape key, load main menu
		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadScene("TitleScreen");
		}
	}
}