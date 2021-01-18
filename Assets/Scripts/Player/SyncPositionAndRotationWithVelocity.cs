using System;
using UnityEngine;

namespace Player
{
    public class SyncPositionAndRotationWithVelocity : MonoBehaviour
    {
        private Rigidbody rg;
        
        
        private void Start()
        {
            rg = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (rg.velocity.magnitude > 0)
            {
                // Sync position and rotation
                
            }
        }
    }
}