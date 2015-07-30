using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collisionInfo) {
		Destroy(gameObject);
	}
}
