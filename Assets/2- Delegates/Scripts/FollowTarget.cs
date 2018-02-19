/*=============================================
-----------------------------------
Copyright (c) 2018 Calvin
-----------------------------------
@file: FollowTarget.cs
@date: 19/02/2018
@author: Calvin
@brief: Helper script for updating the agent's target position
===============================================*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

namespace Delegates
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;

        private NavMeshAgent agent;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            agent.SetDestination(target.position);
        }
    }
}
