﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disntergrate : MonoBehaviour {


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Destroy(gameObject);
        }
    }
}
