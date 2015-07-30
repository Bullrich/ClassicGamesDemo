using UnityEngine;
using System.Collections;

public class ElementScript : MonoBehaviour {
	public bool mine; //is is a mine?
	// Different Textures
	public Sprite[] emptyTextures;
	public Sprite mineTexture;

	public bool isCovered(){
		return GetComponent<SpriteRenderer> ().sprite.texture.name == "default";
	}
	
	void Start () {
		mine = Random.value < 0.15;

		//Register in the grid
		int xGrid = (int)transform.position.x;
		int yGrid = (int)transform.position.y;
		GridMineSweeperScript.elements [xGrid, yGrid] = this;
	}
	//Load a different texture
	public void loadTexture(int adjacentCount){
		if (mine)
			GetComponent<SpriteRenderer> ().sprite = mineTexture;
		else
			GetComponent<SpriteRenderer> ().sprite = emptyTextures [adjacentCount];
	}
	void OnMouseUpAsButton(){
		if (mine) {
			//Uncover all the mines
			GridMineSweeperScript.uncoverMines ();
			print ("you lose");
		} else { //Not a mine
			//show numbers
			int xElement = (int)transform.position.x;
			int yElement = (int)transform.position.y;
			loadTexture (GridMineSweeperScript.adjacentMines (xElement, yElement));

			//uncover are without mines
			GridMineSweeperScript.FFuncover (xElement, yElement, new bool[GridMineSweeperScript.wGrid, GridMineSweeperScript.hGrid]);

			//find if game was won
			if (GridMineSweeperScript.isFinished ())
				print ("you win!");

		}
	}
}
