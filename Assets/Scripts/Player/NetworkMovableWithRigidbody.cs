using System;
using Mirror;
using UnityEngine;

namespace Player
{
    // Un script pour tous les objets qu'on déplacera dans le Multiplayer par la méthode Rigidbody
    public class NetworkMovableWithRigidbody : NetworkBehaviour, INetworkMovable
    {
        Rigidbody rg;

        public float moveSpeed = 10;
        public float rotateSpeed = 10;

        private Tank _tank;

        private void Awake()
        {
            rg = GetComponent<Rigidbody>();
            _tank = GetComponent<Tank>();
        }

        private void Update()
        {
            if (ClientScene.localPlayer && ClientScene.localPlayer.gameObject == this.gameObject && _tank.IsAlive())
            {
                Controls();
            }
        }

        public void Controls()
        {
            // Les controles pour déplacer un NetworkMovableWithRigidbody
            
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                // AddForce(-transform.right * moveSpeed);
                transform.Rotate(-new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }
            
            if (Input.GetKey(KeyCode.RightArrow))
            {
                // AddForce(transform.right * moveSpeed);
                transform.Rotate(new Vector3(0,1,0) * Time.deltaTime * (rotateSpeed));
            }
            
            if (Input.GetKey(KeyCode.UpArrow))
            {
                AddForce(transform.forward * Time.deltaTime * 100 * moveSpeed);
            }
            
            if (Input.GetKey(KeyCode.DownArrow))
            {
                AddForce(-transform.forward * Time.deltaTime * 100 * moveSpeed);
            }
        }

        void AddForce(Vector3 v)
        {
            rg.AddForce(v);
        }
        
        
    }
}