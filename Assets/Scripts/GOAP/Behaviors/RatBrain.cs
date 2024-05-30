using CrashKonijn.Goap.Behaviours;
using GOAP.Goals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GOAP.Behaviors 
{
    public class RatBrain : MonoBehaviour
    {
        private AgentBehaviour agent;
        private void Awake()
        {
            agent = GetComponent<AgentBehaviour>();
        }
        // Start is called before the first frame update
        void Start()
        {
            agent.SetGoal<WanderGoal>(endAction: false);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

