using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
	public void mainMenu(){
		SceneManager.LoadScene("TitleScreen");
	}
	
	public void credits(){
		SceneManager.LoadScene("Credits");
	}
}
