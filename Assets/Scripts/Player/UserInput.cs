using System.Collections;
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
            // Are there columns to move?
            if(Bird.columns.Count > 0)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    // move column up
                    bird.MoveColumn(true);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    // move column down
                    bird.MoveColumn(false);
                }
            }
        }
    }
}