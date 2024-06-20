using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Controller
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;
        [SerializeField] private TeleportController teleportController;
    
        private void Start()
        {
            playerController.Initialize();
            teleportController.Initialize();
        }
    }
}
