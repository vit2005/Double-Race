using UnityEngine;
using UnityEngine.UI;
using System.Collections;

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
		player=GameObject.FindWithTag("Player");
		MenuOF ();
		ModalOF ();
	}


	void Update()
	{
		if(!player && GameOverUI.localPosition.x != 0.0f)
		{
			menuUI.localPosition = new Vector3 (0,720,0);
			settingsUI.localPosition = new Vector3 (1280,0,0);
			modalWindowUI.localPosition = new Vector3 (0,-720,0);
			Invoke ("GMUI",2.0f);
		}
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			MenuON();
		}
	}

void GMUI()
	{
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
