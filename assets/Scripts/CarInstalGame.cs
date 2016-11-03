using UnityEngine;
using System.Collections;

public class CarInstalGame : MonoBehaviour {
	public GameObject[] car;
	public CamPositions camPositionController;
	public GameMenu GameMenuController;

	void Awake () 
	{
		CreateNewCar ();
		//Instantiate (car [PlayerPrefs.GetInt ("carPlayer")], transform.position, transform.rotation);
	}
	
	public void CreateNewCar(){
		Vector3 pos = (HpPlayer.lastposition == null)? transform.position : HpPlayer.lastposition;
		if (HpPlayer.destroyedCar != null)
			Destroy (HpPlayer.destroyedCar);
		Object o = Instantiate (car [PlayerPrefs.GetInt ("carPlayer")], pos, transform.rotation);
		if (camPositionController != null)
		camPositionController.playerPosinion = (o as GameObject).transform;
		GameMenuController.FindPlayer ();
		GameMenuController.GameOverUI.localPosition = new Vector3 (-1200, 0, 0);
	}
}
