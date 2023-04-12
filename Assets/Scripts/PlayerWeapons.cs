using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeapons : MonoBehaviour {
	public int weaponOffset;
	public GameObject bullet;

	private Animator anim;

	private void Start() {
		anim = GetComponent<Animator>();
	}

	private void Update() {
		//When the player presses mouse1 (left click) shoot a bullet
		//(and the player is not dead/game paused) (Not yet implemented)
		if (Input.GetMouseButtonDown(0)) {
			// Get the rotation of the player
			var rotation = transform.rotation;
			
			// Get the position of the player
			var position = transform.position;
			
			
			
			// Create a vector of distance one from the player's position to the mouse position
			var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			var lookDirection = mousePosition - position;
			var direction = lookDirection.normalized;
			print(direction.magnitude);
			
			// Create a distance vector that has the magnitude of the weapon offset
			var distance = direction * weaponOffset;

			print(distance.magnitude);
			
			// Create new vector3 with the position of the player + the offset

			var newPosition = position + distance;
			
			//Instantiate a bullet at the player's position
			Instantiate(bullet, newPosition, rotation);
			
			anim.Play("Shoot");
		}
	}
}