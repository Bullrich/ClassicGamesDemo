using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextInfo : MonoBehaviour {
	Text information;
	
	void Start()
	{
		information = GetComponent<Text>();
		information.text = "Demo de juegos clasicos por Javier Bullrich";
	}
	public void ChangeTextInformation (string game){
		string gameInfo;
		switch (game) {
		case "tetris":
			gameInfo = "Juego Tetris basico\n\rse controla con las flechas.";
			information.text = gameInfo;
			break;
		case "arkanoid":
			gameInfo = "Juego Arkanoid\n\rse controla con A/D o flechas.";
			information.text = gameInfo;
			break;
		case "minesweeper":
			gameInfo = "Juego Buscaminas\n\rbastante bugeado.\n\rHay mucho que corregir";
			information.text = gameInfo;
			break;
		case "pacman":
			gameInfo = "Juego Pac-Man\n\rEn desarrollo.\n\rSe juega con las flechas";
			information.text = gameInfo;
			break;
		case "snake":
			gameInfo = "Juego Snake\n\rTodavia no se genero un metodo de perder.";
			information.text = gameInfo;
			break;
		}
	}
}