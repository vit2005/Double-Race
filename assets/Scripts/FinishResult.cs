using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Advertisements;

public class FinishResult : MonoBehaviour {

	public Text        _new;

	public RectTransform LoadTexture;

	public  Text      dist;
	public  Text      distManey;
	public  int       money10m;
	public  Text      Maxdist;
	private int       lastPosition;

	private Transform dataTransform;



	public  Text      enemi;
	public  Text      enemiManey;

	public  Text      total;


	void Start () 
	{

		dataTransform = GameObject.FindWithTag ("Player").transform;

	
		PlayerPrefs.SetInt("enemiDestroy",0);
		PlayerPrefs.SetInt("enemiDestroyMoney",0);

		IndicatorManey () ;
	}
	
	
	public void IndicatorManey () 
	{
		if(dataTransform)
		{
		lastPosition      = System.Convert.ToInt32(dataTransform.position.z);
		dist.text         = System.Convert.ToString(lastPosition/1000.0f)+ " km";
		distManey.text    = System.Convert.ToString(lastPosition/100*money10m);
		}

		enemi.text        = System.Convert.ToString(PlayerPrefs.GetInt("enemiDestroy"));
		enemiManey.text   = System.Convert.ToString(PlayerPrefs.GetInt("enemiDestroyMoney"));
	
		total.text        = System.Convert.ToString(lastPosition/100*money10m + PlayerPrefs.GetInt("enemiDestroyMoney"));
		Maxdist.text      = System.Convert.ToString (PlayerPrefs.GetFloat (Application.loadedLevelName + "Record"));
		if (PlayerPrefs.GetFloat (Application.loadedLevelName + "Record") < lastPosition / 1000.0f) 
		{
			_new.text="new";
			PlayerPrefs.SetFloat (Application.loadedLevelName + "Record", lastPosition / 1000.0f);
		}


		Invoke("IndicatorManey",0.1f);
	}

	public void ExitMenu()
	{
		LoadTexture.localPosition = new Vector3 (0,0,0);
		PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")+lastPosition/100*money10m + PlayerPrefs.GetInt("enemiDestroyMoney"));

	

		Application.LoadLevel(1);
	}

	public void ShowAd(){
		if (Advertisement.IsReady("ololo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("ololo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			Application.LoadLevel(Application.loadedLevel);
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}
