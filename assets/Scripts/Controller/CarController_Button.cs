using UnityEngine;
using System.Collections;

public class CarController_Button : MonoBehaviour 
{
	private Rigidbody       car;              //физика обьекта
	private Transform       carRotate;        //трансформ автомобиля

	private bool            clic;             //есть клик на екране или нет 

	private float           clicPos;          //положение курсора на екране по оси Х

	private bool            left;             //разрешон ли поворот влево
	private bool            right;            //разрешон ли поворот вправо

	private float           current_angle;   //текуший угол автомобиля 

	public  Transform       CoM;


	public  int             minX;
	public  int             maxX;

	public  WheelCollider[] wheelCar;        //передние колеса автомобиля,требуеться для поворота

	public  float           angleMax;        //максимальный угол поворота автомобиля(самого автомобиля на дороге)
	public  float           angleWhell;      //угол поворота колес

	public float i;





	void Start () 
	{
		left      = true;                   //разрешаем повороты и отмечаем что нет кликов екранных 
		right     = true;
		clic      = false;

		carRotate = transform;              //кешируем все требуемые елементы 
		car       = gameObject.GetComponent<Rigidbody>();


		gameObject.GetComponent<Rigidbody>().centerOfMass=CoM.position;
	}



	void Update ()
	{
		i = carRotate.eulerAngles.y;
		ControlPosition();
		ControlRotation();

		if (carRotate.rotation.y < 0.0f) //проверка на отрицательный или положительный угол поворота(- или + ось)
		{
			current_angle = carRotate.eulerAngles.y-360.0f;  //если минусовая получаем градус с минусом ,поскольку трансформ имеет замкнутый цикл 0-360 градусов
		}
		else 
		{
			current_angle = carRotate.eulerAngles.y;          //если положительная ось получаем угол 
		}

		if (current_angle < -angleMax || carRotate.position.x <= minX) //проверка на максимальный угол поворота по оси  и разрешаем поворот или запрещаем 
		{
			left = false;
		} 
		else 
		{
			left = true;
		}

		if (current_angle > angleMax || carRotate.position.x >= maxX) 
		{
			right = false;
		} 
		else 
		{
			right=true;
		}





	}

	void ControlRotation()
	{
		float _y;
		if (carRotate.localEulerAngles.y >= 180) //проверка на отрицательный или положительный угол поворота(- или + ось)
		{
			_y = Mathf.Clamp(carRotate.localEulerAngles.y ,360.0f-angleMax,360.0f);
			transform.localEulerAngles = new Vector3 (carRotate.localEulerAngles.x,_y,carRotate.localEulerAngles.z);
		}
		else
		{
			_y = Mathf.Clamp(carRotate.localEulerAngles.y ,0.0f,angleMax);
			transform.localEulerAngles = new Vector3 (carRotate.localEulerAngles.x,_y,carRotate.localEulerAngles.z);
		}
	}


	void ControlPosition()
	{
		float _x = Mathf.Clamp(carRotate.position.x ,minX,maxX);
		float _y = Mathf.Clamp(carRotate.position.y ,0.0f,2.0f);
		transform.position = new Vector3(_x,_y,carRotate.position.z);

	}


	void FixedUpdate()
	{
		ControlClick(); 
		ControlButton();

		if(!Input.GetKey("a")&&!(Input.GetKey("d"))&& clic==false)

		{
			NoRotate();
		}
	}

	void ControlButton()
	{
		//управление автомобилем ,выше запуск функции для телефонов ,ниже управление под ПК
		if(Input.GetKey("a"))
		{

			Left();
		}

		if(Input.GetKey("d"))
		{
			Right();
		}
	}


	void ControlClick()
	{

		if (Input.touchCount > 0) 
		{ //проверка на нажатие
			clic=true;

			for (int i = 0; i < Input.touchCount; i++)       
			{

				if (Input.touches [i].position.x < Screen.width / 2) //если положение тача на левой части екранна то поворот авто влево и наоборот 
				{
					Left ();
				}

				if (Input.touches [i].position.x > Screen.width / 2) 
				{

					Right ();
				}
			}
		} 
		else 
		{
			clic=false;
		}
	}







	void Left()
	{
		if (left == true) 
		{

			wheelCar [0].steerAngle = -angleWhell;
			wheelCar [1].steerAngle = -angleWhell;
		} 
		else 
		{
			NoRotate();
		}

	}

	void Right()
	{
		if(right==true)
		{
			wheelCar[0].steerAngle=angleWhell;
			wheelCar[1].steerAngle=angleWhell;
		}
		else 
		{
			NoRotate();
		}
	}



	void NoRotate()
	{

		wheelCar[0].steerAngle=-current_angle;      //выравнивание автомобиля(угол поворота колес = углу поворота автомобиля *-)
		wheelCar[1].steerAngle=-current_angle;
	}




}
