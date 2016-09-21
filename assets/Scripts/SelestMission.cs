using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class SelestMission : MonoBehaviour {

	public string         _missionName;
	public int            _missionPrice;

	public RectTransform  _windowBay; 
	public RectTransform  _windowEror; 
	public Button         _selestMission;
	public Text           _selestMissionText;

	public Text           _RecordUI; 
	public Text           _RecordOpenUI;
	public float          _RecordOpen;
	public string         _RecordOpenNemeScene;

	void Start () 
	{
	
	PlayerPrefs.SetInt ("missionOpenRece",1);
	}

	void Update()

	{
	if(PlayerPrefs.GetFloat(_RecordOpenNemeScene+"Record") >= _RecordOpen)
		{
	PlayerPrefs.SetInt ("missionOpen"+_missionName,1);
		}

	_RecordUI.text = System.Convert.ToString(PlayerPrefs.GetFloat(_missionName+"Record"))+" km";

	if (PlayerPrefs.GetInt ("missionOpen" + _missionName) == 1) 
		{
			_selestMissionText.text = "select";
		} 
		else 
		{
			_selestMissionText.text = "unlock";
		}

		if (PlayerPrefs.GetString ("missions") == _missionName) 
		{
			_selestMissionText.text = "selected";
			_selestMission.interactable = false;
		} 
		else 
		{
			_selestMission.interactable = true;
		}

		if (PlayerPrefs.GetFloat (_RecordOpenNemeScene + "Record") <= _RecordOpen)
		{
			PlayerPrefs.SetInt ("missionOpen" + _missionName,1);
		}

	}


	public void OpenMissionsSelest () 
	{
		if (PlayerPrefs.GetInt ("missionOpen" + _missionName) == 1) 
		{
		PlayerPrefs.SetString ("missions", _missionName);
		}
		else 
		{
			if(_missionPrice <= PlayerPrefs.GetInt("maney"))
			{
				PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")-_missionPrice);
				PlayerPrefs.SetInt ("missionOpen" + _missionName,1);
				PlayerPrefs.SetString ("missions", _missionName);
			}
			else
			{
				_windowEror.localPosition = new Vector3 (0, 0, 0);
			}
		}

	}
	public void ExitWindows () 
	{
		_windowBay.localPosition = new Vector3 (0, 2000, 0);
		_windowEror.localPosition = new Vector3 (0, 2000, 0);
	}

}
