using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeapons : MonoBehaviour {
	public Vector3 weaponOffset;
	public GameObject bullet;
	private void Start() { }

	private void Update() {
		//When the player presses mouse1 (left click) shoot a bullet
		//(and the player is not dead/game paused) (Not yet implemented)
		if (Input.GetMouseButtonDown(0)) {
			// Get the rotation of the player
			var rotation = transform.rotation;
			// Create new quaternion with the rotation of 90 degrees in the z axis (this is because the default capsule is the wrong way around)
			var newRotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, rotation.eulerAngles.z + 90);
			
			// Get the position of the player
			var position = transform.position;
			// Create new vector3 with the position of the player + the offset
			var newPosition = new Vector3(position.x + weaponOffset.x, position.y + weaponOffset.y, position.z + weaponOffset.z);
			
			//Instantiate a bullet at the player's position
			Instantiate(bullet, newPosition, newRotation);
		}
	}
}