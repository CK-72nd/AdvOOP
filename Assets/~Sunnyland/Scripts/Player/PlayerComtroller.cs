using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]

    public class PlayerComtroller : MonoBehaviour
    {
        public float speed = 5f;
        public float maxVelocity = 2f;
        public float rayDistance = .5f;
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public LayerMask groundLayer;

        private Vector3 moveDirection;
        private int currentJump = 0;

        //References
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            rend = GetComponent<SpriteRenderer>();
            anim = GetComponent<Animator>();
            rigid = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            // Apply gravity to move direction
            moveDirection.y += Physics.gravity.y * Time.deltaTime;
        }

        void FixedUpdate()
        {
            // Feel for the ground
            DetectGround();
        }

        void OnDrawGizmos()
        {
            Ray groundRay = new Ray(transform.position, Vector3.down);
            Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
        }
        #endregion

        #region Custom Functions
        void DetectGround()
        {
            // Create a ray going down
            // Set Hit to 2D Raycast
            // If hit collider is not null
            // Reset currentJump
        }

        void LimitVelocity()
        {
            // If Rigid's velocity (magnitude) is greater than maxVelocity
            // Set Rigid velocity to velocity normalized x maxVelocity
        }

        public void Jump()
        {
            // If currentJump is less than max jump
            // Increment currentJump
            // Add force to player (using Impulse)
        }

        public void Climb()
        {
            // CHALLENGE
        }

        public void Move(float horizontal)
        {
            // If horizontal > 0
            // Flip Character
            // If horizontal < 0
            // Flip Character

            // Add force to player in the right direction
            // Limit Velocity
        }
        #endregion
    }
}
