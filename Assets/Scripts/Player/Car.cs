using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace Player
{
    public class Car : NetworkBehaviour
    {
        [SyncVar] private int positionClassement = 1;

        [SyncVar] private int tour = 1;

        [SyncVar] private int indexCheckPoint = 1;
        
        void Start()
        {
            CarUtility.Singleton.AddCar(this);
        }
        
        private void Update()
        {
            CalculatePosition();
        }
        
        [Server]
        void CalculatePosition()
        {
            List<Car> cars = CarUtility.Singleton.CarList();
            positionClassement = CalculPosition(this, cars);
        }

        int CalculPosition(Car currentCar, List<Car> cars)
        {
            // TODO
            return 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Checkpoint")
            {
                CmdEnterInNewCheckpoint();
            }
        }

        [Command]
        void CmdEnterInNewCheckpoint()
        {
            bool inRangeCheckpoint;

            foreach (var checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint"))
            {
                // float distanceToCheckpoint
                // if()
                
                // Si je suis a coté d'un checkpoint et que ca correspond a l'index du checkpoint 
                
            }
            
            indexCheckPoint++;
        }
    }
}