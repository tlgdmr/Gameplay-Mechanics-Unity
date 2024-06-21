using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Interfaces
{
    public interface ITeleportHandler
    {
        public void OnTeleporting();
        public Transform TeleportTransform();
    }
}