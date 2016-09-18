using UnityEngine;
using System.Collections;

public class CarForse : MonoBehaviour {
	
	private Transform        myTransform;
	public  Texture[]       _forsageTexture;
	private Texture         _forsageTextureEnergy;


	public  WheelCollider[] CarWheels; // Колайдеры колесс
	public  Transform[]     CarWheelsObject; // Колайдеры колесс

	public  float           carMotor;  // Сила придающая крутящий момент
	private float           carMotorStart;  // Сила придающая крутящий момент

	public  float           carBrake;  // Сила тормозов
	private float           carBrakeStart;  // Сила тормозов
	
	public  float           MaxSpeed;  // Максимальная скорость
	private float           MaxSpeedStart;  // Максимальная скорость при старте

	public  float           _forsage;
	private float           _forsageStart;
	public  float           speed;//текущая скорость

	private float           _timer;

	
	// Use this for initialization
	void Start () 
	{
	MaxSpeed += PlayerPrefs.GetInt (gameObject.name + "speed");
	MaxSpeedStart = MaxSpeed;
	carMotorStart = carMotor;
	carBrakeStart = carBrake;
	_forsageStart = _forsage/4.0f;

	myTransform = gameObject.transform;

	}
	
	
	// Update is called once per frame
	void Update () 
	{
		if (_timer < Time.time) 
		{
			MaxSpeed=MaxSpeedStart;
			carMotor=carMotorStart;
			carBrake=carBrakeStart;
		}

		int i;
		i = System.Convert.ToInt32(_forsage / _forsageStart);

		_forsageTextureEnergy = _forsageTexture [i];


		if (_forsage < 0.0f) 
		{
			_forsage=0.0f;
		}
		if (_forsage > _forsageStart*4) 
		{
			_forsage=_forsageStart*4;
		}


	}
	
	
	void	FixedUpdate()
	{
	speed  =((CarWheels [0].rpm * CarWheels [0].radius)/6 + (CarWheels [1].rpm * CarWheels [1].radius)/6) ;

		if(speed < MaxSpeed)
		{
		foreach(WheelCollider colliderCar in CarWheels)
		{
			colliderCar.motorTorque = carMotor;
			colliderCar.brakeTorque = 0;
		}
		}
		else
		{
			foreach(WheelCollider colliderCar in CarWheels)
			{
			colliderCar.motorTorque = carMotor/2;
			colliderCar.brakeTorque = carBrake;
			}
		}
	
	}

	void OnGUI()
	{
		//GUI.DrawTexture (new Rect (Screen.width-Screen.height/7-Screen.height/4,Screen.height-Screen.height/7, Screen.height/7, Screen.height/7),_forsageTextureEnergy);
		Rect _forsPosition  = new Rect (Screen.width-Screen.height/7-Screen.height/4,Screen.height-Screen.height/7, Screen.height/7, Screen.height/7);

		for (int i = 0; i < Input.touchCount; i++) 
		{
			Vector2 _positionTouch = Input.touches [i].position;  
			_positionTouch.y = Screen.height - _positionTouch.y;

			if (_forsPosition.Contains (_positionTouch) && _forsage > 0.0f) 
			{
				MaxSpeed=MaxSpeedStart+MaxSpeedStart/10.0f;
				carMotor=carMotorStart+carMotorStart/2.0f;
				carBrake=carBrakeStart+carMotorStart/2.0f;
				_forsage-=1*Time.deltaTime;
				_timer=Time.time+0.1f;
			}
		}
	
	}
	

}
