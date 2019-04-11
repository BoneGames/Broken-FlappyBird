using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bird : MonoBehaviour
    {
        public float upForce;           // Upward force of the "flap"
        private bool isDead = false;    // Has the player collider with the wall? 
        private Rigidbody2D rigid;
        public float clickRotation;
        Quaternion up, down;
        public static List<GameObject> columns = new List<GameObject>();

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
            up = Quaternion.Euler(0, 0, clickRotation);
            down = Quaternion.Euler(0, 0, -clickRotation);
        }

        private void Update()
        {
            transform.rotation = rigid.velocity.y > 0 ? up : rigid.velocity.y < -2 ? down : up;
            if(columns.Count > 0)
            {
                if(transform.position.x > columns[0].transform.position.x)
                {
                    columns.RemoveAt(0);
                }
            }
            
        }

        public void MoveColumn(bool up)
        {
            Vector3 direction;
            direction = up ? Vector3.up : Vector3.down;
            columns[0].transform.Translate(direction * Time.deltaTime);
        }

        public void Flap()
        {
            // Only flap if the Bird isn't dead yet
            if (!isDead)
            {
                rigid.velocity = Vector2.zero;
                // Give the bird some upward force
                rigid.AddForce(new Vector2(0, upForce), ForceMode2D.Impulse);
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            // Cancel velocity
            rigid.velocity = Vector2.zero;
            // Bird is now dead
            isDead = true;
            // Tell the GameManager about it
            GameManager.Instance.BirdDied();
        }
    }
}