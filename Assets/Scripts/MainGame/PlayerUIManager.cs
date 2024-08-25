using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] _livessprite;
    [SerializeField]
    private Image _livesimage;
    public void Updatelives(int currentlives)
    {
        _livesimage.sprite = _livessprite[currentlives];
	}
}
