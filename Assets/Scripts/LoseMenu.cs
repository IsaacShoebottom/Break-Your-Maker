using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour {
	
	public void restartGame() {
		SceneManager.LoadScene("Level-1");
	}
	
	public void loadMainMenu() {
		SceneManager.LoadScene("TitleScreen");
	}
}