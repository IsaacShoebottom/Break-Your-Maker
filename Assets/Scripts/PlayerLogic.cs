using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerLogic : MonoBehaviour {
	public TextMeshProUGUI healthText;
	int health = 3;
	// Start is called before the first frame update
	void Start() { }

	// Update is called once per frame
	void Update() { }

	private void OnCollisionEnter2D(Collision2D other) {
		// If other is tagged bullets, take damage
		if (other.gameObject.CompareTag("Bullet")) {
			Destroy(other.gameObject);
			health--;
			healthText.text = "Health: " + health;
			if (health <= 0) {
				// Load the game over scene here
				// (Not yet implemented)
				print("You lose!");
			}
		}
		
	}
}