using UnityEngine;
using System.Collections;

public class FireMachineGunEnemi : FireMachineGun {


	void Start () 
	{
		buletHolderMax=buletHolder; //сохраняем максимальное количество патроннов в обойме
		efect.SetActive(false);//выключить ефект(вспышка от выстрелла)
		timer=0.0f;

		target=GameObject.FindWithTag("PlayerTarget").transform;//цель 
	}


	void OnTriggerStay(Collider other) 
	{
		if (other.tag=="PlayerTarget")
		{
			AngleTarget ();
	
		}
	}
}
