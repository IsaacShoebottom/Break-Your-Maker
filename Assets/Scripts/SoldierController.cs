using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class SoldierController : MonoBehaviour {
	private bool isLeft;
	private bool playerLeft;
	private Vector3 lastPosition;
	private Vector3 localScale;

	public GameObject player;
	private Animator anim;
	
	public float weaponOffset;
	public GameObject bullet;

	private float timer;
	private float lastShot;

	private int health = 3;

	// Start is called before the first frame update
	void Start() {
		isLeft = false;
		playerLeft = false;
		lastPosition = transform.position;
		anim = GetComponent<Animator>();
		timer = 0;
		lastShot = 0;

		player = GameObject.FindWithTag("Player");
	}

	// Update is called once per frame
	void Update() {
		timer += Time.deltaTime;
		//Check if the player is left or right of the soldier
		if (player.transform.position.x < transform.position.x) {
			playerLeft = true;
		}
		else {
			playerLeft = false;
		}

		//Check if the soldier is looking at the player
		if (playerLeft && !isLeft) {
			Flip(); //flip the soldier to face the player
			isLeft = true;
		}
		else if (!playerLeft && isLeft) {
			Flip(); //flip the soldier to face the player
			isLeft = false;
		}

		if (lastPosition == transform.position) {
			anim.Play("Idle");
		}
		else {
			anim.Play("Run");
		}

		if (Vector3.Distance(player.transform.position, transform.position) < 35 && timer - lastShot > 3) {
			// Get transform of player
			var playerPosition = GameObject.FindWithTag("Player").transform.position;
			// Get the position of the soldier
			var position = transform.position;

			// Get angle between player and soldier
			var angle = Mathf.Atan2(playerPosition.y - position.y, playerPosition.x - position.x) * Mathf.Rad2Deg;

			
			
			// Get a vector from the soldier to the player
			var distance = playerPosition - position;
			// Normalize the vector
			var direction = distance.normalized;
			
			// Create a distance vector that has the magnitude of the weapon offset
			var offsetVector = direction * weaponOffset;
			
			// Create new vector3 with the position of the player + the offset
			var newPosition = position + offsetVector;
			
			var rotation = Quaternion.Euler(0, 0, angle);
			
			
			//Instantiate a bullet at the player's position
			Instantiate(bullet, newPosition, rotation);

			lastShot = timer;
		}

		lastPosition = transform.position;
	}

	void Flip() {
		localScale = transform.localScale;
		transform.localScale = new Vector3(-localScale.x, localScale.y, localScale.z);
	}


	private void OnTriggerEnter2D(Collider2D other) {
		Debug.Log(other.gameObject.tag);
		if (other.gameObject.tag == "Bullet") {
			Destroy(other.gameObject);
			health--;
		}

		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}