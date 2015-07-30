using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public float speed = 100.0f;

	void Start () {
		GetComponent<Rigidbody2D> ().velocity = Vector2.up * speed;
	}
	float hitFactor(Vector2 ballPos, Vector2 racketPos,
	                float racketWidth) {
		return (ballPos.x - racketPos.x) / racketWidth;
	}
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.name == "racket") {
			float x=hitFactor(transform.position,
			                  col.transform.position,
			                  ((BoxCollider2D)col.collider).size.x);

			Vector2 dir = new Vector2(x, 1).normalized;

			GetComponent<Rigidbody2D>().velocity = dir * speed;
		}
	}
}
