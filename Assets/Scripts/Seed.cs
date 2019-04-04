using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public GameObject plant;
	void Start ()
    {
        plant.transform.position = transform.position;
        plant.SetActive(true);
    }

	void Update ()
    {
		
	}


}
