using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace FSM
{
    public abstract class BasicAI : MonoBehaviour
    {
        public LayerMask TargetLayerMask;
        public float ChaseRadius;
        public WeaponController WeaponController;
        public Transform Target;
        public NavMeshAgent NavMeshAgent;

        public Vector3 spawnPoint { get; private set; }
        private State initialState;

        private void Awake()
        {
            spawnPoint = transform.position;
            initialState = GetInitialState();
        }

        protected abstract State GetInitialState();

        private void Update()
        {
            initialState.PerformActions(this);
            var nextState = initialState.GetNextState(this);
            if (nextState != null)
            {
                initialState = nextState;
            }
        }
    }
}
