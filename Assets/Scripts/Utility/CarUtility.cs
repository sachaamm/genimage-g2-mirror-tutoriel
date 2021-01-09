using System;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    // Pas rattaché à un joueur
    public class CarUtility: MonoBehaviour
    {
        private List<Car> cars;

        public static CarUtility Singleton;
        
        private void Awake()
        {
            Singleton = this;
            cars = new List<Car>();
        }

        public List<Car> CarList()
        {
            return cars;
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }

        private void Update()
        {
            foreach (Car car in cars)
            {
                
            }
        }
    }
}