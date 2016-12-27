using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class GameMenu : MonoBehaviour {

	public  RectTransform menuUI;
	public  RectTransform settingsUI;
	public  RectTransform GameOverUI;
	public  RectTransform modalWindowUI;

	public  Text          modalWindowTextUI;

	private GameObject    player;

	private string        selestAction;


	void Start () 
	{
		//FindPlayer ();
		MenuOF ();
		ModalOF ();
	}

	public void FindPlayer ()
	{
		player=GameObject.FindWithTag("Player");
	}

	void Update()
	{
		if (!player && GameOverUI.localPosition.x != 0.0f) {
			menuUI.localPosition = new Vector3 (0, 720, 0);
			settingsUI.localPosition = new Vector3 (1280, 0, 0);
			modalWindowUI.localPosition = new Vector3 (0, -720, 0);
			GameOverUI.FindChild ("MENU Button More").GetComponent<Button> ().enabled = Advertisement.IsReady ("ololo");
			Invoke ("GMUI", 2.0f);
		} else {
			//GameOverUI.localPosition = new Vector3 (-1200, 0, 0);
		}
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			MenuON();
		}
	}

void GMUI()
	{
		player=GameObject.FindWithTag("Player");
		if (player) {
			GameOverUI.localPosition = new Vector3 (-1200, 0, 0);
			return;
		}
		GameOverUI.localPosition = new Vector3 (0,0,0);
		menuUI.localPosition = new Vector3 (0,720,0);
		settingsUI.localPosition = new Vector3 (1280,0,0);
		modalWindowUI.localPosition = new Vector3 (0,720,0);
	}

public void PausedGame(int selest)
{
		Time.timeScale = selest;
}
	

public	void MenuON () 
	{
		if (menuUI.localPosition.y != 0 && settingsUI.localPosition.x != 0 && modalWindowUI.localPosition.y != 0) 
		{
			menuUI.localPosition = new Vector3 (0, 0, 0);
			PausedGame (0);
		} 
		else 
	    {
			MenuOF () ;
			settingsUI.localPosition = new Vector3 (1280,0,0);
			modalWindowUI.localPosition = new Vector3 (0,-720,0);
	    }
	}

public	void MenuOF () 
	{
		menuUI.localPosition = new Vector3 (0,720,0);
		PausedGame (1);
	}


public	void Settings (int settings) 
	{

		settingsUI.localPosition = new Vector3 (settings,0,0);

	}




public void Modal(string selest)
	{

		menuUI.localPosition = new Vector3 (0,720,0);
		settingsUI.localPosition = new Vector3 (1280,0,0);

		modalWindowUI.localPosition = new Vector3 (0,0,0);

		selestAction = selest;

	}

public void SelestAction()
	{
		if (selestAction == "restart") 
		{
			RestartGame ();
		} 
		else 
		{ 
			HpPlayer.lastposition = null;
			ExitLevel();
		}
	}

public void ModalOF()
	{
		modalWindowUI.localPosition = new Vector3 (0,-720,0);
	}

public void RestartGame()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

public void ExitLevel()
	{
		Application.LoadLevel ("GameMenu");
	}
}
