using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HangarMenu : MonoBehaviour {
	  
	public RectTransform LoadTexture;

	void Start()
	{
		PlayerPrefs.SetString ("missions","Race1");
		if (PlayerPrefs.GetString ("missions") == "") 
		{
			PlayerPrefs.SetString ("missions","Race1");
		} 
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
		{ 
			Application.LoadLevel("GameMenu");
		}
	
	}

	public void LoadGame()
	{
		LoadTexture.localPosition = new Vector3 (0,0,0);
	}
	 
	public void  LevelLoadSelest (int i) 
	{
		Application.LoadLevel (i);
	}
	
	public void MissionStart()

	{

			Application.LoadLevel (PlayerPrefs.GetString ("missions"));

	}
}
