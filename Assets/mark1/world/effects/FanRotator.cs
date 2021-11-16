using System;
using UnityEngine;

namespace mark1.world.effects
{
    public class FanRotator : MonoBehaviour
    {
        public float speed = 15;
        
        private void Update()
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }
}