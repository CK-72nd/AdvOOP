using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(PlayerComtroller))]
    [RequireComponent(typeof(Animator))]

    public class PlayerAnim : MonoBehaviour
    {

        private PlayerComtroller player;
        private Animator anim;

        #region Unity Functions
        // Use this for initialization

        void Awake()
        {

        }
        void OnEnable()
        {
            print("Enabled");
        }
        void OnDisable()
        {
            print("Disabled");
        }

        void Start()
        {
            player = GetComponent<PlayerComtroller>();
            anim = GetComponent<Animator>();
            player.onGroundedChanged += OnGroundedChanged;
        }

        #endregion

        #region Custom Functions
        void OnGroundedChanged(bool isGrounded)
        {
            // Update is grounded in animator
            if(isGrounded)
            {
                print("I'm grounded :(");
            }
            else
            {
                print("I'm not grounded! :)");
            }
        }
        #endregion
    }
}
