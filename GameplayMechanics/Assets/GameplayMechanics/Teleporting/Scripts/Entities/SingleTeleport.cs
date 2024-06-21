using System;
using GameplayMechanics.Teleporting.Scripts.Interfaces;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class SingleTeleport : MonoBehaviour ,ITeleportHandler
    {
        private Action _onTeleporting;
        private Action<Transform> _getNextTeleportTransform;
        
        public Transform nextTeleportPosition;
        private Transform _teleportTransform;
        
        public void Initialize(Action onTeleporting, Action<Transform> getNextTeleportTransform)
        {
            _onTeleporting = onTeleporting;
            _getNextTeleportTransform = getNextTeleportTransform;
        }
        
        public void OnTeleporting()
        {
            _onTeleporting?.Invoke();
        }
        
        public Transform TeleportTransform()
        {
            _getNextTeleportTransform?.Invoke(transform);
            return nextTeleportPosition;
        } 
    }
}