using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	private void Start() {
		// Rotate the bullet to face the direction it is moving
		// transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
		// (not needed) since the bullet is already rotated 90 degrees

		// After 3 seconds, destroy the bullet
		Destroy(gameObject, 3f);
	}

	private void Update() {
		// Move the bullet forward
		transform.position += transform.right * (Time.deltaTime * speed);
	}

	private void OnCollisionEnter2D(Collision2D other) {
		// If other is tagged walls, destroy the bullet
		if (other.gameObject.CompareTag("Walls")) {
			Destroy(gameObject);
		}
	}
}