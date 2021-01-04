using System;
using UnityEngine;

namespace Player
{
    public class SetTargetFrameRate : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 300;
        }
    }
}