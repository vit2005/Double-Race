using UnityEngine;
using System.Collections;

public class WeaponCarInstal : MonoBehaviour 
{
	public GameObject[] _prefarb;


	void Start () 
	{
	GameObject clone = Instantiate (_prefarb[PlayerPrefs.GetInt("weaponPlayer")],transform.position,transform.rotation) as GameObject;
	clone.transform.parent = gameObject.GetComponentInParent<Transform> ();
	}
	


}
