using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField]
        private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField]
        private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)]
        [SerializeField]
        private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField]
        private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_Rigidbody2D = GetComponent<Rigidbody2D>();

        }


        private void FixedUpdate()
        {
            m_Grounded = false;
            RaycastHit2D hit = Physics2D.BoxCast(m_GroundCheck.position, new Vector2(0.99f, 0.1f), this.transform.eulerAngles.z, new Vector2(0, -1), 0, 1 << LayerMask.NameToLayer("Platform"), -Mathf.Infinity, Mathf.Infinity);
            if (hit.collider != null)
            {
                m_Grounded = true;
                Debug.Log("Grounded");
                return;
            }
            Debug.Log("Not Grounded");
        }


        public void Move(float move, bool jump)
        {

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
