using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLogic : MonoBehaviour {
	public TextMeshProUGUI healthText;
	public int health = 3;
	private bool keyObtained = false;

	private void OnCollisionEnter2D(Collision2D other) {
		// If other is tagged bullets, take damage
		if (other.gameObject.CompareTag("Bullet")) {
			Destroy(other.gameObject);
			Damage();
		}

		//checks if other is a chest
		if(other.gameObject.CompareTag("Chest")){
			var chest = other.gameObject.GetComponent<ChestControl>();
			
			if(!keyObtained){
				chest.SpawnKey(); //spawns key for player
				keyObtained = true;
			}
			else{
				chest.SpawnItem(); //spawns item for player
			}
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