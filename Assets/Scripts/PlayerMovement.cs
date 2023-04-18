using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float moveSpeed = 5f;
	public bool NorthTeleported;
	public bool EastTeleported;
	public bool SouthTeleported;
	public bool WestTeleported;
	public bool keyObtained;
	public float teleportDist =40f;
	private Vector3 oldPosition;

	private Animator anim;

	private void Start() {
		anim = GetComponent<Animator>();
		NorthTeleported =false;
		EastTeleported =false;
		SouthTeleported =false;
		WestTeleported =false;
		keyObtained =false;
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
		/* Don't rotate the player to face the mouse
		var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
		var lookDirection = mousePosition - transform.position;
		var angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		*/

		if (Vector3.Distance(oldPosition, transform.position) > 10){
			NorthTeleported =false;
			EastTeleported =false;
			SouthTeleported =false;
			WestTeleported =false;
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.CompareTag("NorthEntrance") && !SouthTeleported){
			NorthTeleported = true;
			transform.position += new Vector3(0f, 1f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.CompareTag("EastEntrance") && !WestTeleported){
			EastTeleported = true;
			transform.position += new Vector3(1f, 0f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.CompareTag("SouthEntrance") && !NorthTeleported){
			SouthTeleported = true;
			transform.position += new Vector3(0f, -1f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.CompareTag("WestEntrance") && !EastTeleported){
			WestTeleported = true;
			transform.position += new Vector3(-1f, 0f, 0f) * teleportDist;
			oldPosition = transform.position;
		}

		if(other.CompareTag("BossEntrance") && keyObtained){
			transform.position += new Vector3(0f, 1f, 0f) * (float)1.5 * teleportDist;
		}

	}

	void OnCollisionEnter2D(Collision2D other){

		//checks if other is a chest
		if(other.gameObject.CompareTag("Chest")){
			var chest = other.gameObject.GetComponent<ChestControl>();
			
			if(!keyObtained){
				chest.SpawnKey(); //spawns key for player
			}
			else{
				chest.SpawnItem(); //spawns item for player
			}
		}
	}

	public void gotKey(){
		keyObtained = true;
	}

}