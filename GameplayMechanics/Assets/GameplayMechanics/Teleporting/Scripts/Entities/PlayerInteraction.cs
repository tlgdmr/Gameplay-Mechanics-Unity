using System;
using GameplayMechanics.Teleporting.Scripts.Interfaces;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class PlayerInteraction : MonoBehaviour
    {
        private Action<bool> _onPlayerTeleporting;
        
        public void Initialize(Action<bool> onPlayerTeleporting)
        {
            _onPlayerTeleporting = onPlayerTeleporting;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TeleportPoint"))
            {
                if (other.TryGetComponent(out ITeleportHandler teleportHandler))
                {
                    teleportHandler.OnTeleporting();
                    _onPlayerTeleporting?.Invoke(true);
                }
            }
        }
    }
}