using System;
using GameplayMechanics.Teleporting.Scripts.Interfaces;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class PlayerInteraction : MonoBehaviour
    {
        private Action<bool> _onPlayerTeleporting;
        private Action<Transform> _getNextTeleportTransform;
        
        public void Initialize(Action<bool> onPlayerTeleporting, Action<Transform> getNextTeleportTransform)
        {
            _onPlayerTeleporting = onPlayerTeleporting;
            _getNextTeleportTransform = getNextTeleportTransform;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.transform.name);
            if (other.CompareTag("TeleportPoint"))
            {
                if (other.TryGetComponent(out ITeleportHandler teleportHandler))
                {
                    teleportHandler.OnTeleporting();
                    _onPlayerTeleporting?.Invoke(true);
                    _getNextTeleportTransform?.Invoke(teleportHandler.TeleportTransform());
                }
            }
        }
    }
}