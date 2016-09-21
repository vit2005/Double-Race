using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireMachineGunPlayer : FireMachineGun 
{

	public   Texture buletTexture;
	public   Texture reloadTexture;
	public   Texture fireTexture;

	public   int     buletLine;

	private  float   widthScale;
	private  Vector3 scaleGame;
	public   Sprite  UIImage;

	void Start()
	{
		widthScale       = Screen.width  / (Screen.height / 720.0f);
		scaleGame.x      = Screen.height / 720.0f;
		scaleGame.y      = Screen.height / 720.0f;
		scaleGame.z      = 1;

		buletHolderMax=buletHolder; //сохраняем максимальное количество патроннов в обойме
		efect.SetActive(false);//выключить ефект(вспышка от выстрелла)
		timer=0.0f;
		if (GameObject.FindWithTag ("UiWeapon") != null)
			GameObject.FindWithTag ("UiWeapon").GetComponent<Image> ().sprite = UIImage;
	}

	void Update()
	{
		if(buletHolder == 0)
		{
			Reload();
		}
	}

	void OnGUI()
{

		GUI.matrix = Matrix4x4.Scale(new Vector3(1,1,1));


		if (Application.loadedLevelName != "Garage") 
		{
//			for (int i = 0; i < Input.touchCount ; i++) 
//			{
//
//
//				Rect _rectReload = new Rect (Screen.width-Screen.height/7,Screen.height-Screen.height/4-Screen.height/7, Screen.height/7, Screen.height/7);
//				Rect _rectFire = new Rect (Screen.width-Screen.height/4,Screen.height-Screen.height/4, Screen.height/4, Screen.height/4);
//				Vector2 _positionTouch = Input.GetTouch(i).position;  
//				_positionTouch.y=Screen.height-_positionTouch.y;
//
//				if (_rectReload.Contains (_positionTouch)) 
//				{
//					Reload ();
//				}
//
//				if (_rectFire.Contains (_positionTouch)) 
//				{
					//Fire ();

//				}
//
//			}
	
			AngleTarget ();
			//GUI.DrawTexture (new Rect (Screen.width-Screen.height/7,Screen.height-Screen.height/4-Screen.height/7, Screen.height/7, Screen.height/7), reloadTexture);
			//GUI.DrawTexture (new Rect (Screen.width-Screen.height/4,Screen.height-Screen.height/4, Screen.height/4, Screen.height/4), fireTexture);

//			GUI.matrix = Matrix4x4.Scale(scaleGame);
//
			if (timer - Time.time <= reloadBulet + 0.1f) {
				int namberLine = 0;
				int line = 0;


				for (int i = 0; i < buletHolder; i++) {
					GUI.DrawTexture (new Rect (widthScale - (20 + (namberLine * 15)), 215 + (15 * line), 15, 15), buletTexture);
					namberLine++;
					if (namberLine == buletLine) {
						line++;
						namberLine = 0;
					}
				}
			}
		 }
}


}
