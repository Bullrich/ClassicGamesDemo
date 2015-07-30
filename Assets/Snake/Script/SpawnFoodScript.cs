using UnityEngine;
using System.Collections;

public class SpawnFoodScript : MonoBehaviour {
	// Food Prefab
	public GameObject foodPrefab;
	
	// Borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;
	void Start () {
		InvokeRepeating ("Spawn", 3, 4);
	}
	void Spawn(){ 	
		int xPosition = (int)Random.Range (borderLeft.position.x,
		                                   borderRight.position.x);
		int yPosition = (int)Random.Range (borderBottom.position.y,
		                                   borderTop.position.y);
		
		Instantiate (foodPrefab,
		             new Vector2 (xPosition, yPosition),
		             Quaternion.identity);
	}
}
