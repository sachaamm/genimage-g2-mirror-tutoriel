using UnityEngine;

namespace Physics
{
    public class LimitVelocities : MonoBehaviour
    {
        private Rigidbody rg;

        public float Velocity = 10;
        public float DivideAngularVelocity = 10;
        
        void Start()
        {
            rg = GetComponent<Rigidbody>();
        }
        
        void Update()
        {
            rg.angularVelocity /= DivideAngularVelocity;
            rg.velocity /= Velocity;
        }
    }
}
