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
        [Header("Grounding")]
        public float rayDistance = .5f;
        public bool isGrounded = false;
        public float maxSlopeAngle = 45f;
        [Header("Crouch")]
        public bool isCrouching = false;
        [Header("Jump")]
        public float jumpHeight = 2f;
        public int maxJumpCount = 2;
        public bool isJumping = false;
        [Header("Climb")]
        public float climbSpeed = 5f;
        public bool isClimbing = false;
        public bool isOnSlope = false;
        [Header("References")]
        public Collider2D defaultCollider;
        public Collider2D crouchCollider;

        //References
        private SpriteRenderer rend;
        private Animator anim;
        private Rigidbody2D rigid;

        // Delegates
        public EventCallback onJump;
        public EventCallback onHurt;
        public BoolCallback onCrouchChanged;
        public BoolCallback onGroundedChanged;
        public BoolCallback onSlopeChanged;
        public BoolCallback onClimbChanged;
        public FloatCallback onMove;
        public FloatCallback onClimb;

        private Vector3 groundNormal = Vector3.up;
        private Vector3 moveDirection;
        private int currentJump = 0;

        private float vertical, horizontal;

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

        // Check to see if ray hit object is ground
        bool CheckSlope(RaycastHit2D hit)
        {
            // Grab the angle in degrees of the surface we're standing on
            float slopeAngle = Vector3.Angle(Vector3.up, hit.normal);
            // If the angle is greater than max
            {
                // Make player slide down surface
                rigid.AddForce(Physics.gravity);
            }

            if (slopeAngle > 0 && slopeAngle < maxSlopeAngle)
            {
                return true;
            }
            return false;
        }
        // Check to see if ray hit object is ground
        bool CheckGround(RaycastHit2D hit)
        {
            // Check if
            if(hit.collider != null && // It hits something AND
               hit.collider.name != name && // It didn't hit me AND
               !hit.collider.isTrigger) // It didnt't hit a trigger
            {
                // Reset the jump count
                currentJump = 0;
                // Is grounded!
                isGrounded = true;
                // Set ground normal now that we're grounded
                groundNormal = -hit.normal;
                // Record 'isOnSlope' value 
                bool wasOnSlope = isOnSlope;
                // Check if we're on a slope!
                isOnSlope = CheckSlope(hit);
                // Has the 'isOnSlope' value changed?
                if (wasOnSlope != isOnSlope)
                {
                    // Invoke event
                    if(onSlopeChanged != null)
                    {
                        onSlopeChanged.Invoke(isOnSlope);
                    }
                }

                // We have found our ground so exit the function
                // (No need to check any more hits)
                return true;
            }

            else
            {
                // We are no longer grounded
                isGrounded = false;
            }

            // Haven't found the ground (so keep looking)
            return false;
        }

        void DetectGround()
        {
            // Record a copy of what isGrounded was
            bool wasGrounded = isGrounded;

            #region Ground Detection Logic
            // Create a ray going down
            Ray groundRay = new Ray(transform.position, Vector3.down);
            RaycastHit2D[] hits = Physics2D.RaycastAll(groundRay.origin, groundRay.direction, rayDistance);
            // Set Hit to 2D Raycast
            foreach (var hit in hits)
            {
                if (CheckGround(hit))
                {
                    // We found the ground! So exit the function
                    break;
                }

                // If hit collider is not null
                // Reset currentJump
            }
            #endregion

            // Check if:
            if (wasGrounded != isGrounded && // IsGrounded has changed since before the detection AND
                onGroundedChanged != null) // Something is subscribed to this event
            {
                // Run all the things subscribed to event and give it "isGrounded" value
                onGroundedChanged.Invoke(isGrounded);
            }
        }

        void LimitVelocity()
        {
            // If Rigid's velocity (magnitude) is greater than maxVelocity
            if(rigid.velocity.magnitude > maxVelocity)
            {
                // Set Rigid velocity to velocity normalized x maxVelocity
                rigid.velocity = rigid.velocity.normalized * maxVelocity;
            }
        }

        public void Jump()
        {
            // If currentJump is less than max jump
            if (currentJump < maxJumpCount)
            {
                // Increment currentJump
                // Add force to player (using Impulse)
            }
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
