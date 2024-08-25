using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoading : MonoBehaviour
{
    [SerializeField]
    private Image _progressbar;
    private int selection;
    void Start()
    {
        selection = PlayerPrefs.GetInt("MainSelection");
        if(selection == 1)
        {
            StartCoroutine(LoadAsyncOperationMainGame());
        }
        else if(selection == 2)
        {
            StartCoroutine(LoadAsyncOperationShop());  
		}
    }
    IEnumerator LoadAsyncOperationMainGame()
    {
        AsyncOperation gamelevel = SceneManager.LoadSceneAsync("MainGame");
        while(gamelevel.progress < 1)
        {
              _progressbar.fillAmount = gamelevel.progress;
              yield return new WaitForEndOfFrame();
		}
	}
    IEnumerator LoadAsyncOperationShop()
    {
        AsyncOperation gamelevel = SceneManager.LoadSceneAsync("Shop");
        while(gamelevel.progress < 1)
        {
              _progressbar.fillAmount = gamelevel.progress;
              yield return new WaitForEndOfFrame();
		}
	}
}
