﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Bird))]
    public class UserInput : MonoBehaviour
    {
        private Bird bird;
       

        // Use this for initialization
        void Start()
        {
            bird = GetComponent<Bird>();
        }

        // Update is called once per frame
        void Update()
        {
            // Check for mouse down
            if (Input.GetMouseButtonDown(0))
            {
                // Flap the bird
                bird.Flap();
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                bird.MoveColumn(true);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                bird.MoveColumn(false);
            }
        }
    }
}