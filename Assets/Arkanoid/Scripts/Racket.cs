using UnityEngine;
using System.Collections;

public class Racket : MonoBehaviour {
	public float speed = 150;

	void FixedUpdate (){
		float h = Input.GetAxisRaw("Horizontal");
		GetComponent<Rigidbody2D>().velocity = Vector2.right * h * speed ;
	}
}
