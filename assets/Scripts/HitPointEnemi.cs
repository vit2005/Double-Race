using UnityEngine;
using System.Collections;

public class HitPointEnemi : HitPoint {
	public GameObject destroyerObjectEfect;
	public int        maney;


	void Start () 
	{

	}
	

	void Update () 
	{
	if(hp <= 0 )
		{
			PlayerPrefs.SetInt("enemiDestroy",PlayerPrefs.GetInt("enemiDestroy")+1);
			PlayerPrefs.SetInt("enemiDestroyMoney",PlayerPrefs.GetInt("enemiDestroyMoney")+maney);
			Instantiate(destroyerObjectEfect,transform.position,transform.rotation);
			Destroy(gameObject);

		}
	}
}
