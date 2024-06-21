using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class TeleportGroupEntity : MonoBehaviour
    {
        [Tooltip("Enter the time in seconds.")]
        [SerializeField] private float teleportingDelay;
        [Space] 
        [SerializeField] private List<SingleTeleport> singleTeleportList;
        [SerializeField] private List<Transform> teleportTransforms;
        [SerializeField] private Collider[] teleportingPositionColliders;
        
        public void Initialize()
        {
            InitializeSingleTeleports();
        }

        private void InitializeSingleTeleports()
        {
            foreach (var singleTeleport in singleTeleportList)
            {
                singleTeleport.Initialize(OnTeleporting, SetNextTeleportTransform);
            }
        }

        private void SetNextTeleportTransform(Transform interactedTeleportTransform)
        {
            foreach (var singleTeleport in singleTeleportList)
            {
                singleTeleport.nextTeleportPosition = FindNextTeleportTransform(interactedTeleportTransform);
            }
        }
        
        private Transform FindNextTeleportTransform(Transform interactedTeleportTransform)
        {
            foreach (var teleportTransform in teleportTransforms)
            {
                if (interactedTeleportTransform != teleportTransform)
                {
                    return teleportTransform;
                }
            }

            return interactedTeleportTransform;
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