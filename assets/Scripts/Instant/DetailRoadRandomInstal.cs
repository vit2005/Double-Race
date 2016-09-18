using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailRoadRandomInstal : MonoBehaviour {

	public GameObject[]     detail;
	public int              detailInt;
	public List<Transform>  detailPosition;
	
	void Awake () 
	{
		for(int i = 0; i < detailInt ;i++)
		{
			int randomPos    = Random.Range(0,detailPosition.Count);
			int randomDetail = Random.Range(0,detail.Length);
			GameObject clone;
			detailPosition[randomPos].Rotate(0,Random.Range(0,360),0);
			clone = Instantiate(detail[randomDetail],detailPosition[randomPos].position,detailPosition[randomPos].rotation) as GameObject;
			detailPosition.RemoveAt(randomPos);
		}
	}
}
