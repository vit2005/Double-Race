using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GarageSelestMenu : MonoBehaviour {

	[Header ("выбор раздела покупки")]
	public  RectTransform  _car;         //окно покупок автомобиля
	public  RectTransform  _weapon;   //окно улучшений оружия



	void Start () 
	{
		SelestWindow (0);
	}
	

	public void SelestWindow (int i) 
	{
		if (i == 0) {
			_car.localPosition = new Vector3 (0, 0, 0);
			_weapon.localPosition = new Vector3 (0, 2000, 0);
		} 
		else 
		{
			_car.localPosition = new Vector3 (0, 2000, 0);
			_weapon.localPosition = new Vector3 (0, 0, 0);
		}

	}
}
