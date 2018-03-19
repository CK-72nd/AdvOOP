using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    public class PlayerAnim : MonoBehaviour
    {

        private PlayerComtroller player;
        private Animator anim;

        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerComtroller>();
            anim = GetComponent<Animator>();
        }

   
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
    }
}
