using System.Collections;
using System.Collections.Generic;
using GameplayMechanics.Teleporting.Scripts.Interfaces;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class TeleportEntity : MonoBehaviour, ITeleportHandler
    {
        [Tooltip("Enter the time in seconds.")]
        [SerializeField] private float teleportingDelay;
        [Space]
        [SerializeField] private List<Transform> teleportPositions;
        [SerializeField] private Collider[] teleportingPositionColliders;
        
        public void Initialize()
        {
            
        }

        public void OnTeleporting()
        {
            SetTeleportingPosCollider(false);
            StartCoroutine(DisableTeleportingWithDelay());
        }

        private IEnumerator DisableTeleportingWithDelay()
        {
            yield return new WaitForSeconds(teleportingDelay);
            SetTeleportingPosCollider(true);
        }

        private void SetTeleportingPosCollider(bool status)
        {
            foreach (var teleportingPositionCollider in teleportingPositionColliders)
            {
                teleportingPositionCollider.enabled = status;
            }
        }
    }
}
