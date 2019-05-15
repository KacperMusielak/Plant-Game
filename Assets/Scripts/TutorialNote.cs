﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialNote : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                foreach (Transform child in transform)
                {
                    child.gameObject.SetActive(false);
                }

                PlantController.IsReady = true;
                gameObject.SetActive(false);
            }
    }
}