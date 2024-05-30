using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace GOAP.Behaviors 
{
    public class RatMoveBehavior : MonoBehaviour
    {
        private NavMeshAgent agent;
        //private Animator animator;
        private AgentBehaviour behaviour;
        private ITarget CurrentTarget;
        private Vector2 LastPosition;
        [SerializeField] private float MinMoveDistance = 0.25f;

        private void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            //animator = GetComponent<Animator>();
            behaviour = GetComponent<AgentBehaviour>();
        }
        private void OnEnable()
        {
            behaviour.Events.OnTargetInRange += EventsOnTargetInRange;
            behaviour.Events.OnTargetChanged += EventsOnTargetChanged;
            behaviour.Events.OnTargetOutOfRange += EventsOnTargetOutOfRange;
        }

        private void EventsOnTargetInRange(ITarget target)
        {
            CurrentTarget = target;
            agent.SetDestination(target.Position);
        }

        private void OnDisable()
        {
            behaviour.Events.OnTargetChanged -= EventsOnTargetChanged;
            behaviour.Events.OnTargetOutOfRange -= EventsOnTargetOutOfRange;
        }

        private void EventsOnTargetOutOfRange(ITarget target)
        {
            //Animator.SetBool(WALK, false);
        }

        private void EventsOnTargetChanged(ITarget target, bool inRange)
        {
            CurrentTarget = target;
            LastPosition = CurrentTarget.Position;
            agent.SetDestination(target.Position);
            //Animator.SetBool(WALK, true);
        }

        private void Update()
        {
            if (CurrentTarget == null)
            {
                return;
            }

            if (MinMoveDistance <= Vector2.Distance(CurrentTarget.Position, LastPosition))
            {
                LastPosition = CurrentTarget.Position;
                agent.SetDestination(CurrentTarget.Position);
            }

            //Animator.SetBool(WALK, NavMeshAgent.velocity.magnitude > 0.1f);
        }
    }
}
