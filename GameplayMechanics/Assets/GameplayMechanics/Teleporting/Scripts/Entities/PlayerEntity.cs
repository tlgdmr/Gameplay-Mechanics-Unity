using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private float playerMovementSpeed;
        [SerializeField] private PlayerInteraction playerInteraction;
        [SerializeField] private PlayerAnimation playerAnimation;

        private bool _isTeleporting;
        private Transform _currentTeleportingPosition;
        
        public void Initialize()
        {
            playerInteraction.Initialize(SetTeleportingStatus, GetNewPlayerPosition);
            playerAnimation.Initialize(SetTeleportingStatus, SetNewPlayerPosition);
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_isTeleporting)
                return;

            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");

            var movementDirection = new Vector3(horizontal, 0, vertical);

            if (movementDirection.magnitude > 1)
            {
                movementDirection.Normalize();
            }

            movementDirection *= playerMovementSpeed * Time.deltaTime;
            transform.Translate(movementDirection);
        }

        private void GetNewPlayerPosition(Transform nextTeleportingTransform)
        {
            _currentTeleportingPosition = nextTeleportingTransform.transform;
        }

        private void SetNewPlayerPosition()
        {
            transform.position = _currentTeleportingPosition.position;
        }

        private void SetTeleportingStatus(bool status)
        {
            _isTeleporting = status;
            if (status)
            {
                playerAnimation.StartTeleportingAnim();
            }
        }
        
    }
}
