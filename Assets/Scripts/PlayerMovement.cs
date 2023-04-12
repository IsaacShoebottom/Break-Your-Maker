using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private Camera mainCamera;
	public float moveSpeed = 5f;
	public bool NorthTeleported;
	public bool EastTeleported;
	public bool SouthTeleported;
	public bool WestTeleported;
	public float teleportDist =40f;
	private Vector3 oldPosition;

	private Animator anim;

	private void Start() {
		mainCamera = Camera.main;
		anim = GetComponent<Animator>();
		NorthTeleported =false;
		EastTeleported =false;
		SouthTeleported =false;
		WestTeleported =false;
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
			
			// If the player was idle, play the walk animation
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle")) {
				anim.Play("Walk");
			}
		}
		else {
			// If the player was walking, play the idle animation
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")) {
				anim.Play("Idle");
			}
		}
		// Rotate to always face the mouse
		var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		var lookDirection = mousePosition - transform.position;
		var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

		if (Vector3.Distance(oldPosition, transform.position) > 10){
			NorthTeleported =false;
			EastTeleported =false;
			SouthTeleported =false;
			WestTeleported =false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "NorthEntrance" && !SouthTeleported){
			NorthTeleported = true;
			transform.position = transform.position + new Vector3(0f, 1f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.tag == "EastEntrance" && !WestTeleported){
			EastTeleported = true;
			transform.position = transform.position + new Vector3(1f, 0f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.tag == "SouthEntrance" && !NorthTeleported){
			SouthTeleported = true;
			transform.position = transform.position + new Vector3(0f, -1f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.tag == "WestEntrance" && !EastTeleported){
			WestTeleported = true;
			transform.position = transform.position + new Vector3(-1f, 0f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

	}

}