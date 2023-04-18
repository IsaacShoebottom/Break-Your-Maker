using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour {
	private Vector3 localScale;
	private Vector3 flipped;

	private void Start() {
		// Get starting local scale
		localScale = transform.localScale;
		flipped = new Vector3(-localScale.x, localScale.y, localScale.z);
	}

	private void Update() {
		// If the mouse is to the left of the player, flip the sprite'
		transform.localScale = Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x ? flipped : localScale;
	}
}