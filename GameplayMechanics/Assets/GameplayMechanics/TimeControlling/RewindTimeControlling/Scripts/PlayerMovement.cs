using System;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private float _targetX;

        private void Start()
        {
            _targetX = transform.position.x * -1;
        }

        void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                new Vector3(_targetX, transform.position.y, transform.position.z), 
                speed * Time.deltaTime);
            
            if (Mathf.Abs(transform.position.x - _targetX) < 0.001f)
            {
                _targetX *= -1;
            }
        }
    }
}