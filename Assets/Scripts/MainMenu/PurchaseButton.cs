using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
	public enum PurchaseType {BunchCoins,SackCoins,ChestCoins,BunchGems,SackGems,ChestGems,CorvetteCar,CamaroCar,SupremeCar,CorvettePack,CamaroPack}
	public PurchaseType purchasetype;
	public void ClickPurchaseButton()
	{
		switch(purchasetype)
		{
			case PurchaseType.BunchCoins:
			IAPManager.instance.Buybunchcoins();
			break;
			case PurchaseType.SackCoins:
			IAPManager.instance.Buysackcoins();
			break;
			case PurchaseType.ChestCoins:
			IAPManager.instance.Buychestcoins();
			break;
			case PurchaseType.BunchGems:
			IAPManager.instance.Buybunchgems();
			break;
			case PurchaseType.SackGems:
			IAPManager.instance.Buysackgems();
			break;
			case PurchaseType.ChestGems:
			IAPManager.instance.Buychestgems();
			break;
			case PurchaseType.CorvetteCar:
			IAPManager.instance.Buycorvette();
			break;			
			case PurchaseType.CamaroCar:
			IAPManager.instance.Buycamaro();
			break;			
			case PurchaseType.SupremeCar:
			IAPManager.instance.Buysupreme();
			break;
			case PurchaseType.CorvettePack:
			IAPManager.instance.Buycorvettepack();
			break;			
			case PurchaseType.CamaroPack:
			IAPManager.instance.Buycamaropack();
			break;
		}
	}
}
