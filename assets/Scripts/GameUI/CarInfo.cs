using UnityEngine;
using System.Collections;

public class CarInfo : MonoBehaviour 
{


	public string  name;
	public string  info;
	public string  hp;
	public string  speed;
	public string  control;
	public Vector3 positionWeapon;

	public int     price;

	[Header ("Значения и цена улучшения прочности")]
	public int[]   price_hp_update;
    public int[]   _hp_update;

	[Header ("Значения и цена улучшения скорости")]
	public int[]   price_speed_update;
	public int[]   _speed_update;




}
