using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	//TODO: Make the clamp work with the size of the generated map
	
	// Player to follow
	public Transform player;
	
	void Start() { }

	void Update() {
		// Huge number basically unclamps the camera
		var screenEdge = 5000000;
		
		// Move the camera to the player's position, but clamp it to the active scene
		transform.position = new Vector3(
			Mathf.Clamp(player.position.x, -screenEdge, screenEdge),
			Mathf.Clamp(player.position.y, -screenEdge, screenEdge),
			transform.position.z
		);
	}
}