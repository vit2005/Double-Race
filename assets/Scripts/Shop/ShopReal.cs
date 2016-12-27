using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OnePF;
using UnityEngine.Advertisements;




public class ShopReal : MonoBehaviour 
{	
	private  const string SKU_1 = "money1";
	private  const string SKU_2 = "money2";
	private  const string SKU_3 = "money3";



	public   const string googleKey ="MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEA2pTH6yu1H9b3lB+bx3hF7pPMdpghCHXn2E08sqgDEz4z4eqDiZ6hfjHJpSexz+UzOf7AJdJB/3EBKwfgO1AqFtiiWyhnPUDqzIHcm09nndnuEYdsko23LXteChw7ZFr0nRisTP6WN9Bs1wzxvPU8e/GfxfaA4LTnSRShKDdDWt/ITYF2H1GX83jZFKz4ilzoIDiE1czHhjjQT0m5Nv50ups28JUFb9Ak0pHZ+zZvuQCckXZQX0NzT1kd2klZQixo4tPJakagdbKNyfpoh0N3bu0XfbLrIEVwEJA5eud1Ds4fouPPmGlabH4AeOy6YD/78TC8KXEVOV/C5J8iSrqdQQIDAQAB";


	private void Awake()

	{
		// Subscribe to all billing events
		OpenIABEventManager.billingSupportedEvent += OnBillingSupported;
		OpenIABEventManager.billingNotSupportedEvent += OnBillingNotSupported;
		OpenIABEventManager.purchaseSucceededEvent += OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent += OnPurchaseFailed;
		OpenIABEventManager.consumePurchaseSucceededEvent += OnConsumePurchaseSucceeded;
		OpenIABEventManager.consumePurchaseFailedEvent += OnConsumePurchaseFailed;
		OpenIABEventManager.transactionRestoredEvent += OnTransactionRestored;
		OpenIABEventManager.restoreSucceededEvent += OnRestoreSucceeded;
		OpenIABEventManager.restoreFailedEvent += OnRestoreFailed;
	}	

	private void OnDestroy()
	{
		// Unsubscribe to avoid nasty leaks
		OpenIABEventManager.billingSupportedEvent -= OnBillingSupported;
		OpenIABEventManager.billingNotSupportedEvent -= OnBillingNotSupported;
		OpenIABEventManager.purchaseSucceededEvent -= OnPurchaseSucceded;
		OpenIABEventManager.purchaseFailedEvent -= OnPurchaseFailed;
		OpenIABEventManager.consumePurchaseSucceededEvent -= OnConsumePurchaseSucceeded;
		OpenIABEventManager.consumePurchaseFailedEvent -= OnConsumePurchaseFailed;
		OpenIABEventManager.transactionRestoredEvent -= OnTransactionRestored;
		OpenIABEventManager.restoreSucceededEvent -= OnRestoreSucceeded;
		OpenIABEventManager.restoreFailedEvent -= OnRestoreFailed;
	}



	private void Start()
	{
		OpenIAB.mapSku(SKU_1, OpenIAB_Android.STORE_GOOGLE, SKU_1);
		OpenIAB.mapSku(SKU_2, OpenIAB_Android.STORE_GOOGLE, SKU_2);
		OpenIAB.mapSku(SKU_3, OpenIAB_Android.STORE_GOOGLE, SKU_3);


		var options = new OnePF.Options();	
		options.storeKeys.Add(OpenIAB_Android.STORE_GOOGLE,googleKey);
		options.verifyMode = OptionsVerifyMode.VERIFY_ONLY_KNOWN;
		OpenIAB.init(options);
	}


	private void OnBillingSupported()
	{
		OpenIAB.queryInventory(new string[] { SKU_1, SKU_2, SKU_3 }); //если возможны покупки запрашиваем наши
	}



	private void OnBillingNotSupported(string error)
	{

	}


	private void OnQueryInventoryFailed(string error)
	{

	}





	public void Bay(int bayNumbe)
	{
		if(bayNumbe==1)
		{
			OpenIAB.purchaseProduct(SKU_1);
		}
		if(bayNumbe==2)
		{
			OpenIAB.purchaseProduct(SKU_2);
		}
		if(bayNumbe==3)
		{
			OpenIAB.purchaseProduct(SKU_3);
		}

	}

	public void ShowAd(){
		if (Advertisement.IsReady("ololo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("ololo", options);
		}
	}

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log("The ad was successfully shown.");
			//Application.LoadLevel(Application.loadedLevel);
			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")+20);
			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}

	private void OnPurchaseSucceded(Purchase purchase)
	{
		if (purchase.Sku == SKU_1)
		{
			OpenIAB.consumeProduct(purchase);
			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")+1000);
		}
		if (purchase.Sku == SKU_2)
		{
			OpenIAB.consumeProduct(purchase);
			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")+2000);
		}
		if (purchase.Sku == SKU_3)
		{
			OpenIAB.consumeProduct(purchase);
			PlayerPrefs.SetInt("maney",PlayerPrefs.GetInt("maney")+3000);
		}

	}


	private void OnPurchaseFailed(int errorCode, string error)
	{

	}

	private void OnConsumePurchaseSucceeded(Purchase purchase)
	{
		//если покупка удалась
	}

	private void OnConsumePurchaseFailed(string error)
	{

	}

	private void OnTransactionRestored(string sku)
	{

	}

	private void OnRestoreSucceeded()
	{

	}

	private void OnRestoreFailed(string error)
	{

	}

}
