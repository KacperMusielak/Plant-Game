using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject seedPrefab;
    public bool seedPlanted;
    void Start ()
    {

    }

	void Update ()
    {
        plantSeed();
    }

    void plantSeed()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!seedPlanted)
            {
                seedPrefab.SetActive(true);
                seedPlanted = true;
            }

        }
    }
}
