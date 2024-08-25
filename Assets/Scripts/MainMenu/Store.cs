using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
    public Button _GemsButton;
    public GameObject _GemsPanel;
    public Button _CoinsButton;
    public GameObject _CoinsPanel;
    public Button _CarsButton;
    public GameObject _CarsPanel;
    public Button _PacksButton;
    public GameObject _PacksPanel;
    void Start()
    {
        _GemsButton.interactable = false;
        _GemsPanel.SetActive(true);
    }
    public void gemsbutton()
    {
        _GemsPanel.SetActive(true);
        _CoinsPanel.SetActive(false);
        _CarsPanel.SetActive(false);
        _PacksPanel.SetActive(false);
        _GemsButton.interactable = false;
        _CoinsButton.interactable = true;
        _CarsButton.interactable = true;
        _PacksButton.interactable = true;
    }
    public void coinsbutton()
    {
        _GemsPanel.SetActive(false);
        _CoinsPanel.SetActive(true);
        _CarsPanel.SetActive(false);
        _PacksPanel.SetActive(false);
        _GemsButton.interactable = true;
        _CoinsButton.interactable = false;
        _CarsButton.interactable = true;
        _PacksButton.interactable = true;
	}
    public void carsbutton()
    {
        _GemsPanel.SetActive(false);
        _CoinsPanel.SetActive(false);
        _CarsPanel.SetActive(true);
        _PacksPanel.SetActive(false);
        _GemsButton.interactable = true;
        _CoinsButton.interactable = true;
        _CarsButton.interactable = false;
        _PacksButton.interactable = true;
	}
    public void packsbutton()
    {
        _GemsPanel.SetActive(false);
        _CoinsPanel.SetActive(false);
        _CarsPanel.SetActive(false);
        _PacksPanel.SetActive(true);
        _GemsButton.interactable = true;
        _CoinsButton.interactable = true;
        _CarsButton.interactable = true;
        _PacksButton.interactable = false;
	}
}
