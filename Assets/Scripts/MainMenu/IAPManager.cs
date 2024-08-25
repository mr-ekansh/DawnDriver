using System;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using GooglePlayGames;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public Button CorvettePackButton;
    public Button CamaroPackButton;
    public Button SupremeGtButton;
    public Button CamaroButton;
    public Button CorvetteButton;
    public GameObject PurchaseFailedPanel;
    public static IAPManager instance;
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;
    //Step 1 create your products
    private string BunchCoins = "bunch_coins";
    private string SackCoins = "sack_coins";
    private string ChestCoins = "chest_coins";
    private string BunchGems = "bunch_gems";
    private string SackGems = "sack_gems";
    private string ChestGems = "chest_gems";
    private string CorvetteCar = "corvette_car";  
    private string CamaroCar = "camaro_car"; 
    private string SupremeCar = "supreme_car";
    private  string CorvettePack = "corvette_pack";
    private  string CamaroPack = "camaro_pack";

    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        ConfigurationBuilder builder;
        builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(BunchCoins, ProductType.Consumable);
        builder.AddProduct(SackCoins, ProductType.Consumable);
        builder.AddProduct(ChestCoins, ProductType.Consumable);
        builder.AddProduct(BunchGems, ProductType.Consumable);
        builder.AddProduct(SackGems, ProductType.Consumable);
        builder.AddProduct(ChestGems, ProductType.Consumable); 
        builder.AddProduct(CorvetteCar, ProductType.NonConsumable);      
        builder.AddProduct(CamaroCar, ProductType.NonConsumable);   
        builder.AddProduct(SupremeCar, ProductType.NonConsumable);        
        builder.AddProduct(CorvettePack, ProductType.NonConsumable);
        builder.AddProduct(CamaroPack, ProductType.NonConsumable);
        UnityPurchasing.Initialize(this, builder);
    }
    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }
    //Step 3 Create methods
    public void Buybunchcoins()
    {
        BuyProductID(BunchCoins);
	}
    public void Buysackcoins()
    {
        BuyProductID(SackCoins);
	}
    public void Buychestcoins()
    {
        BuyProductID(ChestCoins);
	}
    public void Buybunchgems()
    {
        BuyProductID(BunchGems);
	}
    public void Buysackgems()
    {
        BuyProductID(SackGems);
	}
    public void Buychestgems()
    {
        BuyProductID(ChestGems);
	}
    public void Buycorvette()
    {
        BuyProductID(CorvetteCar);
	}   
    public void Buycamaro()
    {
        BuyProductID(CamaroCar);
	}
    public void Buysupreme()
    {
        BuyProductID(SupremeCar);
	}
    public void Buycorvettepack()
    {
        BuyProductID(CorvettePack);
	}
    public void Buycamaropack()
    {
        BuyProductID(CamaroPack);
	}
    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, BunchCoins, StringComparison.Ordinal))
        {
            int coins = PlayerPrefs.GetInt("Coins");
            coins = coins+100;
            PlayerPrefs.SetInt("Coins", coins);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, SackCoins, StringComparison.Ordinal))
        {
            int coins = PlayerPrefs.GetInt("Coins");
            coins = coins+500;
            PlayerPrefs.SetInt("Coins", coins);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ChestCoins, StringComparison.Ordinal))
        {
            int coins = PlayerPrefs.GetInt("Coins");
            coins = coins+1000;
            PlayerPrefs.SetInt("Coins", coins);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, BunchGems, StringComparison.Ordinal))
        {
            int gems = PlayerPrefs.GetInt("Gems");
            gems = gems+30;
            PlayerPrefs.SetInt("Gems", gems);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, SackGems, StringComparison.Ordinal))
        {
            int gems = PlayerPrefs.GetInt("Gems");
            gems = gems+60;
            PlayerPrefs.SetInt("Gems", gems);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, ChestGems, StringComparison.Ordinal))
        {
            int gems = PlayerPrefs.GetInt("Gems");
            gems = gems+100;
            PlayerPrefs.SetInt("Gems", gems);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, CorvetteCar, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("CorvetteLock", 1);
            CorvetteButton.interactable = false;
            PlayerPrefs.SetInt("CorvetteButton", 0);
            CorvettePackButton.interactable = false;
            PlayerPrefs.SetInt("CorvettePackButton", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, CamaroCar, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("CamaroLock", 1);
            CamaroButton.interactable = false;
            PlayerPrefs.SetInt("CamaroButton", 0);
            CamaroPackButton.interactable = false;
            PlayerPrefs.SetInt("CamaroPackButton", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, SupremeCar, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("SupremeLock", 1);
            SupremeGtButton.interactable = false;
            PlayerPrefs.SetInt("SupremeGtButton", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, CorvettePack, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("CorvetteLock", 1);
            CorvetteButton.interactable = false;
            PlayerPrefs.SetInt("CorvetteButton", 0);
            int gems = PlayerPrefs.GetInt("Gems");
            gems = gems+100;
            PlayerPrefs.SetInt("Gems", gems);
            int coins = PlayerPrefs.GetInt("Coins");
            coins = coins+1000;
            PlayerPrefs.SetInt("Coins", coins);
            CorvettePackButton.interactable = false;
            PlayerPrefs.SetInt("CorvettePackButton", 0);
        }
        else if (String.Equals(args.purchasedProduct.definition.id, CamaroPack, StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("CamaroLock", 1);
            CamaroButton.interactable = false;
            PlayerPrefs.SetInt("CamaroButton", 0);
            int gems = PlayerPrefs.GetInt("Gems");
            gems = gems+100;
            PlayerPrefs.SetInt("Gems", gems);
            int coins = PlayerPrefs.GetInt("Coins");
            coins = coins+1000;
            PlayerPrefs.SetInt("Coins", coins);
            CamaroPackButton.interactable = false;
            PlayerPrefs.SetInt("CamaroPackButton", 0);
        }
        else
        {
            PurchaseFailedPanel.SetActive(true);
        }
        return PurchaseProcessingResult.Complete;
    }
    public void RestoreGooglePurchase()
    {
        if(m_StoreController.products.WithID("corvette_car").hasReceipt)
        {
            PlayerPrefs.SetInt("CorvetteLock", 1);
            CorvetteButton.interactable = false;
            PlayerPrefs.SetInt("CorvetteButton", 0);
            CorvettePackButton.interactable = false;
            PlayerPrefs.SetInt("CorvettePackButton", 0);
        }
        if(m_StoreController.products.WithID("camaro_car").hasReceipt)
        {
            PlayerPrefs.SetInt("CamaroLock", 1);
            CamaroButton.interactable = false;
            PlayerPrefs.SetInt("CamaroButton", 0);
            CamaroPackButton.interactable = false;
            PlayerPrefs.SetInt("CamaroPackButton", 0);
        }
        if(m_StoreController.products.WithID("supreme_car").hasReceipt)
        {
            PlayerPrefs.SetInt("SupremeLock", 1);
            SupremeGtButton.interactable = false;
            PlayerPrefs.SetInt("SupremeGtButton", 0);
        }
	}
    private void Awake()
    {
        TestSingleton();
    }
    void Start()
    {
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
    public void OkButton()
    {
        PurchaseFailedPanel.SetActive(false);
	}
}