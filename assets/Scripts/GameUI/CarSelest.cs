using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CarSelest :   MonoBehaviour 
{
	[Header ("Классы с информацией об авто")]
	public  CarInfo[]      carInfoArrey;      //классы с информацией об авто
	public  CarInfo        carInfoSelest;     //клас с выбранным авто

	[Header ("Массив с обьектами машин")]
	public  GameObject[]   carObject;         //массив с моделями автомобилей
	private Transform      carPosition;       //позиция создания автомобиля
	private int            selest;            //индекс выбранного автомобиль из списка
	private GameObject     carSelestObject;   //обьект созданного автомобиля(для удаления не нужного авто)

	[Header ("Кнопки управления выбором авто и текст на кнопке выбора/покупки")]
	public  Button         ButtonLeft;        //кнопки смены автомобиля
	public  Button         ButtonRight;        
	public  Button         ButtonSelest;      //кнопка выбора
	public  Text           ButtonSelestText;  //текст на кнопке выбора авто

	[Header ("Всплывающие окна")]
	public  RectTransform  BayWindow;         //окно покупок автомобиля
	public  RectTransform  BayWindowUpdate;   //окно улучшений автомобиля
	public  RectTransform  BayWindowEror;     //окно покупок автомобиля

	[Header ("Индикатор выбранна/не выбранна (авто)")]
	public  Text           selestIndicator;   //надпись Выбрано

	[Header ("Текстовые поля с данными об автомобиле")]
	public  Text           nameCar;           //елементы интерфейса с информацией об автомобиле
	public  Text           infoCar;          
	public  Text           ttxCar;
	public  Text           ttxCarUpdate;

	[Header ("Кнопки управления улучшениями")]
	public  Button         hpButton;        //кнопки улучшений
	public  Button         speedButton;        


	[Header ("Текстовые поля с ценой улучшений")]
	public  Text           hpText;         //текстовые поля с ценами улучшений
	public  Text           speedText;          
	private string         updateSelest;

	List<int> CarNeedToResize = new List<int>(){1, 3};

	void Start () 
	{
		//		PlayerPrefs.SetInt ("Iveco",0);
		//		PlayerPrefs.SetInt("maney",1000);

		//		PlayerPrefs.SetInt ("Iveco" + "hpUpdate",0);
		//		PlayerPrefs.SetInt ("Iveco" + "speedUpdate",0);
		//
		//		PlayerPrefs.SetInt ("Humvee" + "hpUpdate",0);
		//		PlayerPrefs.SetInt ("Humvee" + "speedUpdate",0);

		PlayerPrefs.SetInt ("UAZ",1);

		selest = PlayerPrefs.GetInt("carPlayer");
		carPosition = transform;
		carInfoSelest  = carInfoArrey [selest];
		CarInstantiate (0);
		ButtonControl();
		InfoUpdate ();
		Purchase(1);
	}




	public	void CarInstantiate (int i) //создание и удаление автомобилей и смена индекса
	{
		selest+=i;
		Destroy (carSelestObject);
		carSelestObject = Instantiate (carObject [selest], carPosition.position, carPosition.rotation) as GameObject;
		if (CarNeedToResize.Contains (selest))
			carSelestObject.transform.localScale = new Vector3 (0.9f,0.9f,0.9f);
		TTXUpdate ();
		ButtonControl ();
	}

	public void  TTXUpdate() //обновление информации об автомобиле
	{
		carInfoSelest       = carInfoArrey [selest];
		nameCar.text        = carInfoSelest.name;
		//infoCar.text      = carInfoSelest.info;
		//ttxCar.text         = System.Convert.ToString(System.Convert.ToInt32(carInfoSelest.hp)+PlayerPrefs.GetInt(carSelestObject.name + "hp")) + "\n" + System.Convert.ToString(System.Convert.ToInt32(carInfoSelest.speed)+PlayerPrefs.GetInt(carSelestObject.name + "speed")) + "\n" + carInfoSelest.control;
		ttxCar.text         = carInfoSelest.hp + "\n" + carInfoSelest.speed + "\n" + carInfoSelest.control;

		if (PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate") < carInfoSelest._hp_update.Length && PlayerPrefs.GetInt (carInfoArrey[selest].name) == 1) 
		{
			ttxCarUpdate.text = "+" + System.Convert.ToString(carInfoSelest._hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")] - PlayerPrefs.GetInt (carSelestObject.name + "hp"));
		} 
		else
		{
			ttxCarUpdate.text="";
		}

		if (PlayerPrefs.GetInt (carInfoSelest.name + "speedUpdate") < carInfoSelest._speed_update.Length && PlayerPrefs.GetInt (carInfoArrey[selest].name) == 1) {
			ttxCarUpdate.text += "\n" + "+" + System.Convert.ToString(carInfoSelest._hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "speedUpdate")]-PlayerPrefs.GetInt (carSelestObject.name + "speed"));
		} 
		else
		{
			ttxCarUpdate.text += "\n"+" ";
		}



		InfoUpdate ();

		Purchase_and_Selest_Button();
	}

	public void   InfoUpdate() //обновление информации об автомобиле
	{
		if (PlayerPrefs.GetInt (carInfoArrey [selest].name) == 1) {
			if (carInfoSelest._hp_update.Length <= PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")) {
				hpButton.interactable = false;
				hpText.text = "max";
			} else {
				hpButton.interactable = true;
				hpText.text = System.Convert.ToString (carInfoSelest.price_hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")]) + " $";
			}

			if (carInfoSelest._speed_update.Length <= PlayerPrefs.GetInt (carInfoSelest.name + "speedUpdate")) {
				speedButton.interactable = false;
				speedText.text = "max";
			} else {
				speedButton.interactable = true;
				speedText.text = System.Convert.ToString (carInfoSelest.price_speed_update [PlayerPrefs.GetInt (carInfoSelest.name + "speedUpdate")]) + " $";	
			}
		}else {
			hpButton.interactable = false;
			hpText.text = " ";
			speedButton.interactable = false;
			speedText.text = " ";
		}
	}

	public void ButtonControl()  //включение и отключение кнопок выбора автомобилей 
	{
		if (selest > 0) {
			ButtonLeft.interactable = true;
		} else {
			ButtonLeft.interactable = false;
		}

		if (selest < carObject.Length-1) 
		{
			ButtonRight.interactable = true;
		} 
		else 
		{
			ButtonRight.interactable = false;

		}

	}
	public void Purchase_test()
	{
		if(PlayerPrefs.GetInt (carInfoArrey[selest].name) == 1)
		{
			Purchase(1);
			SelestSave(0);
		}
		else
		{
			//			if(PlayerPrefs.GetInt("maney") >= carInfoSelest.price)
			//			{
			BayWindow.localPosition = new Vector3 (0,0,0);
			BayWindowEror.localPosition = new Vector3 (0,2000,0);

			//			}
			//			else
			//			{
			//				BayWindow.localPosition = new Vector3 (0,4000,0);
			//				BayWindowEror.localPosition = new Vector3 (0,0,0);
			//			}
		}

	}

	public void Purchase(int index)
	{
		if(index==0)
		{
			//			if(PlayerPrefs.GetInt("maney") >= carInfoSelest.price)
			//			{
			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")-carInfoSelest.price);
			BayWindow.localPosition = new Vector3 (0,4000,0);
			BayWindowEror.localPosition = new Vector3 (0,2000,0);
			SelestSave(1);
			//			}
			//			else
			//			{
			//				BayWindow.localPosition = new Vector3 (0,4000,0);
			//				BayWindowEror.localPosition = new Vector3 (0,0,0);
			//			}
		}
		else
		{
			BayWindow.localPosition = new Vector3 (0,4000,0);
			BayWindowEror.localPosition = new Vector3 (0,2000,0);
		}
		TTXUpdate ();
		Purchase_and_Selest_Button();
	}




	public void Purchase_and_Selest_Button()
	{
		if(PlayerPrefs.GetInt ("carPlayer") == selest)
		{
			selestIndicator.text = "ВЫБРАНА";
			ButtonSelest.interactable = false;
		}
		else
		{
			selestIndicator.text = "";
			ButtonSelest.interactable = true;
		}



		if(PlayerPrefs.GetInt (carInfoArrey[selest].name) == 1)
		{
			ButtonSelestText.text = "ВЫБРАТЬ";


		}
		else
		{
			ButtonSelestText.text = System.Convert.ToString(carInfoArrey[selest].price)+ " $";

		}


	}



	public void SelestSave(int info)
	{
		if(info == 1)
		{
			PlayerPrefs.SetInt (carInfoArrey[selest].name,1);
		}

		PlayerPrefs.SetInt ("carPlayer",selest);
		PlayerPrefs.Save();
	}

	public void UpdateSelest(string index)
	{
		updateSelest = index;
	}

	public void UpdateCars()
	{
		WindowUpdate (1);

		if (updateSelest == "hp") 
		{
			if (PlayerPrefs.GetInt ("maney") >= carInfoSelest.price_hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")]) 
			{
				PlayerPrefs.SetInt ("maney", PlayerPrefs.GetInt ("maney") - carInfoSelest.price_hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")]);
				PlayerPrefs.SetInt (carSelestObject.name + "hp",carInfoSelest._hp_update[PlayerPrefs.GetInt(carInfoSelest.name + "hpUpdate")]);
				PlayerPrefs.SetInt (carInfoSelest.name + "hpUpdate", PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate") + 1);
			}
			else 
			{
				BayWindowEror.localPosition = new Vector3 (0,0,0);
			}
		} 


		if (updateSelest == "speed") 
		{
			            if(PlayerPrefs.GetInt("maney") >= carInfoSelest.price_speed_update[PlayerPrefs.GetInt(carInfoSelest.name + "speedUpdate")])
						{


			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")-carInfoSelest.price_speed_update[PlayerPrefs.GetInt(carInfoSelest.name + "speedUpdate")]);
			PlayerPrefs.SetInt (carSelestObject.name + "speed",carInfoSelest._speed_update[PlayerPrefs.GetInt(carInfoSelest.name + "speedUpdate")]);
			PlayerPrefs.SetInt (carInfoSelest.name + "speedUpdate",PlayerPrefs.GetInt(carInfoSelest.name + "speedUpdate")+1);
						}
						else 
						{
							BayWindowEror.localPosition = new Vector3 (0,0,0);
						}
		}
		TTXUpdate ();
	}

	public void WindowUpdate(int index)
	{
		if (index == 0) 
		{
			if (updateSelest == "hp") 
			{
				if (PlayerPrefs.GetInt ("maney") >= carInfoSelest.price_hp_update [PlayerPrefs.GetInt (carInfoSelest.name + "hpUpdate")]) 
				{
					BayWindowUpdate.localPosition = new Vector3 (0,0,0);
				}
				else 
				{
					BayWindowEror.localPosition = new Vector3 (0,0,0);
				}
			} 


			if (updateSelest == "speed") 
			{
				//				if(PlayerPrefs.GetInt("maney") >= carInfoSelest.price_speed_update[PlayerPrefs.GetInt(carInfoSelest.name + "speedUpdate")])
				//				{
				BayWindowUpdate.localPosition = new Vector3 (0,0,0);
				//				}
				//				else 
				//				{
				//					BayWindowEror.localPosition = new Vector3 (0,0,0);
				//				}
			}

		}
		else 
		{
			BayWindowUpdate.localPosition = new Vector3 (0, -2000, 0);
			BayWindowEror.localPosition = new Vector3 (0, 2000, 0);
		}
	}







}
