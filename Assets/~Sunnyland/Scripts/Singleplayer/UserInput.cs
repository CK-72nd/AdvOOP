using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(PlayerComtroller))]

    public class UserInput : MonoBehaviour
    {
        private PlayerComtroller player;

        private float inputH, inputV; // << THIS,
        private bool isJumping;
        private bool isCrouching;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerComtroller>();
        }

        // Update is called once per frame
        void Update()
        {
            // TEST
            if (Input.GetKeyDown(KeyCode.U))
            {
                // Hurt yourself when you press U
                player.Hurt(10, new Vector2(1, 1));
            }
            ///////

            GetInput();
            player.Move(inputH);
            player.Climb(inputV); // << THIS,
            if (isJumping)
            {
                player.Jump();
            }
            if (isCrouching)
            {
                player.Crouch();
            }
            else
            {
                player.UnCrouch();
            }
        }

        void GetInput()
        {
            inputH = Input.GetAxis("Horizontal");
            inputV = Input.GetAxis("Vertical"); // << AND THIS
            isJumping = Input.GetKeyDown(KeyCode.Space);
            isCrouching = Input.GetKeyDown(KeyCode.LeftControl);
        }
    }
}
