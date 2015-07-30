using UnityEngine;
using System.Collections;

public class GridMineSweeperScript {
	//The grid
	public static int wGrid = 10; //width of the grid
	public static int hGrid = 10; //height of the grid
	public static ElementScript[,] elements = new ElementScript[wGrid, hGrid];
	//find if mine is at the coordinates
	public static bool mineAt(int xGrid, int yGrid) {
		//Check the coords
		if (xGrid >= 0 && yGrid >= 0 && xGrid < wGrid && yGrid < hGrid)
			return elements [xGrid, yGrid].mine;
		return false;
	}
	public static bool isFinished(){
		//try to fin covered element that is no mine
		foreach (ElementScript elem in elements)
			if (elem.isCovered () && !elem.mine)
				return false;
		//there are none +> all are mines => game won
		return true;
	}
	//count adjacent mines
	public static int adjacentMines(int xGrid, int yGrid){
		int count = 0;

		if (mineAt(xGrid,   yGrid+1)) ++count; // top
		if (mineAt(xGrid+1, yGrid+1)) ++count; // top-right
		if (mineAt(xGrid+1, yGrid  )) ++count; // right
		if (mineAt(xGrid+1, yGrid-1)) ++count; // bottom-right
		if (mineAt(xGrid,   yGrid-1)) ++count; // bottom
		if (mineAt(xGrid-1, yGrid-1)) ++count; // bottom-left
		if (mineAt(xGrid-1, yGrid  )) ++count; // left
		if (mineAt(xGrid-1, yGrid+1)) ++count; // top-left

		return count;
	}
	//uncover mines
	public static void uncoverMines(){
		foreach (ElementScript elem in elements)
			if (elem.mine)
				elem.loadTexture (0);
	}
	//Flood Fill empty elements
	public static void FFuncover(int xFlood, int yFlood, bool[,] visited){
		if (xFlood >= 0 && yFlood >= 0 && xFlood < wGrid && yFlood < hGrid) {
			//was visited?
			if (visited [xFlood, yFlood])
				return;

			//uncover element
			elements [xFlood, yFlood].loadTexture (adjacentMines (xFlood, yFlood));
			//close to a mine? Then stop
			if (adjacentMines (xFlood, yFlood) > 0) {
				return;

				//set visited
				visited [xFlood, yFlood] = true;

				//recursion
				FFuncover (xFlood - 1, yFlood, visited);
				FFuncover (xFlood + 1, yFlood, visited);
				FFuncover (xFlood, yFlood - 1, visited);
				FFuncover (xFlood, yFlood + 1, visited);
			}
		}
	}
}