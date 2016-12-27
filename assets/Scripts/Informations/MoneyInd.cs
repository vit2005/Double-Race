using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoneyInd : MonoBehaviour 
{
	public  Text  money;
	public  bool  allOF;


	void Start () 
	{
		PlayerPrefs.SetInt("enemiDestroy",0);

		IndicatorMoney () ;
	}


	public void IndicatorMoney () 
	{
		int ind = PlayerPrefs.GetInt("maney");
		if (ind < 0) {
			PlayerPrefs.SetInt("maney", 0);
			ind = 0;
		}
		if(allOF==true)
		{
			money.text=System.Convert.ToString(PlayerPrefs.GetInt("enemiDestroyMoney"));
		}
		else
		{
			money.text=System.Convert.ToString(ind);
		}
		Invoke("IndicatorMoney",0.1f);
	}
}
