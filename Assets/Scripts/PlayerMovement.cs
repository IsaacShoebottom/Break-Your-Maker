using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Camera mainCamera;
	public float moveSpeed = 5f;

	private void Start() {
		mainCamera = Camera.main;
	}

	private void Update() {
		/* Using the Unity Input System to handle player movement in 2D */
		
		
		// Only if the movement keys are pressed
		if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0) {
			// Get the horizontal and vertical movement from the player
			var horizontal = Input.GetAxis("Horizontal");
			var vertical = Input.GetAxis("Vertical");
		
			// Create a vector from the horizontal and vertical movement
			var movement = new Vector3(horizontal, vertical, 0);
		
			// Normalize the movement vector and make it proportional to the moveSpeed per second
			movement = movement.normalized * (moveSpeed * Time.deltaTime);
	
			// Move the player
			transform.position += movement;
		}
		// Rotate to always face the mouse
		var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		var lookDirection = mousePosition - transform.position;
		var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}