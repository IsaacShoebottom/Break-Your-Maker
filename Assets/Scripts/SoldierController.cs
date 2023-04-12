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
	
	public Vector3 weaponOffset;
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

		if (Vector3.Distance(player.transform.position, transform.position) < 35 && (timer - lastShot) > 3) {
			
			// Get angle between player and soldier
			var rotation = Mathf.Atan2(player.transform.position.y - transform.position.y, player.transform.position.x - transform.position.x) * Mathf.Rad2Deg;

			// Get the position of the player
			var position = transform.position;
			// Create new vector3 with the position of the player + the offset
			var newPosition = new Vector3(position.x + weaponOffset.x, position.y + weaponOffset.y, position.z + weaponOffset.z);
			
			//Instantiate a bullet at the player's position
			Instantiate(bullet, newPosition, rotation: Quaternion.Euler(0, 0, rotation));

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