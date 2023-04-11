using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour {
	private Vector3 localScale;
	private Vector3 flipped;

	private void Start() {
		// Get starting local scale
		localScale = transform.localScale;
		flipped = new Vector3(localScale.x, -localScale.y, localScale.z);
	}

	private void Update() {
		// If the object's angle is greater than 90 degrees and greater than 270 degrees, flip the sprite
		transform.localScale = transform.rotation.eulerAngles.z is > 90 and < 270 ? flipped : localScale;
	}
}