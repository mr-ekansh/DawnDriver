using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siren : MonoBehaviour
{
    public GameObject RedSiren;
    public GameObject BlueSiren;
    void Start()
    {
        RedSiren.SetActive(false);
        BlueSiren.SetActive(true);
        StartCoroutine(SirenLight());
    }
    IEnumerator SirenLight()
    {
        yield return new WaitForSeconds(0.5f);
        while(true)
        {
            RedSiren.SetActive(true);
            BlueSiren.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            BlueSiren.SetActive(true);
            RedSiren.SetActive(false);
            yield return new WaitForSeconds(0.5f);
		}
	}
}
