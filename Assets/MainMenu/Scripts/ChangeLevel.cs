using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	public void ChangeToScene(string SceneToChangeTo){
		Application.LoadLevel (SceneToChangeTo);
	}
}
