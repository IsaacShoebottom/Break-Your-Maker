using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed;
	private void Start() {
		// After 3 seconds, destroy the bullet
		Destroy(gameObject, 3f);
	}

	private void Update() {
		// Move the bullet forward
		transform.position -= transform.up * (Time.deltaTime * speed);
	}
}