using UnityEngine;
using System.Collections;

public class CarInstalGame : MonoBehaviour {
	public GameObject[] car;
	public CamPositions camPositionController;
	public GameMenu GameMenuController;
	public FinishResult FinishResultController;

	void Awake () 
	{
		//CreateNewCar ();
		Instantiating();
		//Instantiate (car [PlayerPrefs.GetInt ("carPlayer")], transform.position, transform.rotation);
	}

	public void CreateNewCar(){

		GameObject player = GameObject.FindWithTag("Player");
		if (player != null)
			Destroy (player);
		if (HpPlayer.destroyedCar != null)
			Destroy (HpPlayer.destroyedCar);

		GameMenuController.GameOverUI.localPosition = new Vector3 (-1200, 0, 0);
		StartCoroutine (AfterDestroy ());

	}

	IEnumerator AfterDestroy(){
		yield return new WaitForSeconds (1);
		Instantiating ();
	}

	IEnumerator AfterCreate(){
		yield return new WaitForSeconds (1);
		GameMenuController.FindPlayer ();
		FinishResultController.FindPlayer ();
	}

	void Instantiating(){
		Vector3 pos = (HpPlayer.lastposition == null)? transform.position : HpPlayer.lastposition;
		Object o = Instantiate (car [PlayerPrefs.GetInt ("carPlayer")], pos, transform.rotation);
		camPositionController.playerPosinion = (o as GameObject).transform;
		StartCoroutine (AfterCreate ());
	}
}
