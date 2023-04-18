using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour {
	public TextMeshProUGUI healthText;
	public int health = 3;

	private void OnCollisionEnter2D(Collision2D other) {
		// If other is tagged bullets, take damage
		if (other.gameObject.CompareTag("Bullet")) {
			Destroy(other.gameObject);
			Damage();
		}
		
	}

	public void Damage(){
		health--;
		healthText.text = "Health: " + health;
		if (health <= 0) {
			print("You lose!");
			SceneManager.LoadScene("Lose");
		}
	}
	
	public void Powerup(){
		health++;
		healthText.text = "Health: " + health;
	}
}