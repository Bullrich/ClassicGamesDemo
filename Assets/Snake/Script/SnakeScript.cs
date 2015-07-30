using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SnakeScript : MonoBehaviour {
	Vector2 dir = Vector2.right;
	List<Transform> tail = new List<Transform>();
	bool ate = false;
	public GameObject tailPrefab;

	void Start () {
		InvokeRepeating ("Move", 0.3f, 0.3f);
	}
	
	void Update () {
		if (Input.GetKey(KeyCode.RightArrow))
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.DownArrow))
			dir = -Vector2.up;
		else if (Input.GetKey(KeyCode.LeftArrow))
			dir = -Vector2.right;
		else if (Input.GetKey(KeyCode.UpArrow))
			dir = Vector2.up;
	}
	void Move(){
		//guarda la posicion
		Vector2 vec = transform.position;
		transform.Translate (dir);

		if (ate) {
			//alargar la cola
			GameObject gObj = (GameObject)Instantiate(tailPrefab,
			                                       vec,
			                                       Quaternion.identity);
			//guardar la informacion de la cola
			tail.Insert(0, gObj.transform);
			//reiniciar el bool
			ate = false;
		} else 
		if (tail.Count > 0) { //chequea que haya cola
		//mueve el elemento a donde estaba la cabeza
			tail.Last().position = vec;

			//agrega al frente de la lista y borra del final
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		//tengo que cambiarlo por tag
		if (col.name.StartsWith ("FoodPrefab")) {
			ate = true;
			Destroy (col.gameObject);
		} else {
			//Perdiste!
		}
	}
}
