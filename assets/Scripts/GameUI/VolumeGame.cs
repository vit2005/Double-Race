using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeGame : MonoBehaviour {



public int           volumeSoundSelest;
public int           volumeMusicSelest;

public Button[]      volumeSoundButton;
public Button[]      volumeMusicButton;

public Text          volumeSound;
public Text          volumeMusic;


void Start()
	{

volumeSoundSelest=PlayerPrefs.GetInt("sound");
volumeMusicSelest=PlayerPrefs.GetInt("music");
VolumeInfo();
	}




public void VolumeInfo() 
	{
		volumeSound.text = System.Convert.ToString(volumeSoundSelest);
		volumeMusic.text = System.Convert.ToString(volumeMusicSelest);
		PlayerPrefs.SetInt("sound",volumeSoundSelest);
		PlayerPrefs.SetInt("music",volumeMusicSelest);

		if(volumeSoundSelest < 1)
		{
			volumeSoundButton[0].interactable=false;
		}
		else
		{
			volumeSoundButton[0].interactable=true;
		}
		
		if(volumeSoundSelest > 9)
		{
			volumeSoundButton[1].interactable=false;
		}
		else
		{
			volumeSoundButton[1].interactable=true;
		}



		if(volumeMusicSelest < 1)
		{
			volumeMusicButton[0].interactable=false;
		}
		else
		{
			volumeMusicButton[0].interactable=true;
		}
		
		if(volumeMusicSelest > 9)
		{
			volumeMusicButton[1].interactable=false;
		}
		else
		{
			volumeMusicButton[1].interactable=true;
		}


	}

public void Sound(int volume)
	{
	
			volumeSoundSelest += volume;
		SoundControl.Instance.SetVolume ();

		VolumeInfo() ;
	}


	public void Music(int volume)
	{

			volumeMusicSelest += volume;

		
		VolumeInfo() ;
	}

}
