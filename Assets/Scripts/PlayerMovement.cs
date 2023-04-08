using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Camera mainCamera;
	public float moveSpeed = 5f;

	private void Start() {
		mainCamera = Camera.main;
	}

	private void Update() {
		/* Using the Unity Input System to handle player movement in 2D */
		
		
		// Get the horizontal and vertical movement from the player
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		
		// Create a vector from the horizontal and vertical movement
		var movement = new Vector3(horizontal, vertical, 0);
		
		// Normalize the movement vector and make it proportional to the moveSpeed per second
		movement = movement.normalized * (moveSpeed * Time.deltaTime);
	
		// Move the player to it's current position plus the movement
		transform.position += movement;

		// Get the mouse position from the main camera
		var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		
		// Rotate the player to face the mouse
		transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePosition - transform.position);
	}
}