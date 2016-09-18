using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
public RectTransform LoadTexture;
public RectTransform menu;
public RectTransform settings;
public int           levelSelest;

void Awake()
	{
if(PlayerPrefs.GetInt("StartGame") == 0)
		{
			PlayerPrefs.SetInt("sound",10);
			PlayerPrefs.SetInt("music",5);
			PlayerPrefs.SetInt("StartGame",1);
		}
	}

void Start()
	{

		MenuMove(0);
		SettingsMove(-1000);
	}

public void MenuMove(int posY)
	{
		menu.localPosition=new Vector3(0,posY,0);
	}

public void SettingsMove(int posY)
	{
		settings.localPosition=new Vector3(0,posY,0);
	}

public void StartGame()
	{
		LoadTexture.localPosition = new Vector3 (0,0,0);
		Application.LoadLevel(levelSelest);
	}

public void ExitGame()
	{
		Application.Quit();
	}

}
