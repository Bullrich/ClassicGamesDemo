using UnityEngine;
using System.Collections;

public class GroupScript : MonoBehaviour {
	bool isValidGridPos() {        
		foreach (Transform child in transform) {
			Vector2 v = GridScript.roundVec2(child.position);

			if (!GridScript.insideBorder(v))
				return false;

			if (GridScript.grid[(int)v.x, (int)v.y] != null &&
			    GridScript.grid[(int)v.x, (int)v.y].parent != transform)
				return false;
		}
		return true;
	}
	float lastFall = 0;

	void Start() {
		if (!isValidGridPos()) {
			Debug.Log("GAME OVER");
			Destroy(gameObject);
		}
	}

	void updateGrid() {
		for (int y = 0; y < GridScript.h; ++y)
			for (int x = 0; x < GridScript.w; ++x)
				if (GridScript.grid [x, y] != null)
				if (GridScript.grid [x, y].parent == transform)
					GridScript.grid [x, y] = null;

		foreach (Transform child in transform) {
			Vector2 v = GridScript.roundVec2(child.position);
			GridScript.grid[(int)v.x, (int)v.y] = child;
		}        
	}
	void Update() {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.position += new Vector3 (-1, 0, 0);

			if (isValidGridPos ())
				updateGrid ();
			else
				transform.position += new Vector3 (1, 0, 0);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.position += new Vector3 (1, 0, 0);

			if (isValidGridPos ())
				updateGrid ();
			else
				transform.position += new Vector3 (-1, 0, 0);
		} else if (Input.GetKeyDown(KeyCode.DownArrow) ||
		           Time.time - lastFall >= 1) {
			transform.position += new Vector3(0, -1, 0);

			if (isValidGridPos()) {
				updateGrid();
			} else {
				transform.position += new Vector3(0, 1, 0);

				GridScript.deleteFullRows();

				FindObjectOfType<SpawnerScript>().spawnNext();

				enabled = false;
			}
			
			lastFall = Time.time;
		} else if (Input.GetKeyDown(KeyCode.UpArrow)) {
			transform.Rotate(0, 0, -90);

			if (isValidGridPos())
				updateGrid();
			else
				transform.Rotate(0, 0, 90);
		}
	}
}
