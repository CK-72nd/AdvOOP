using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand.Player
{
    [RequireComponent(typeof(PlayerComtroller))]
    public class PlayerAudio : MonoBehaviour
    {
        public AudioSource onHurtSound;

        private PlayerComtroller player;

        #region Unity Functions
        // Use this for initialization
        void Start()
        {
            player = GetComponent<PlayerComtroller>();
            // Subscribe to on hurt function
            player.onHurt += OnHurt;
        }

        // Update is called once per frame
        void Update()
        {

        }
        #endregion

        #region Custom Functions
        void OnHurt()
        {
            onHurtSound.Play();
        }
        #endregion
    }
}
