using GameplayMechanics.TimeControlling.RewindTimeControlling.Interfaces;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class GameManager : MonoBehaviour, IGameManager
    {
        [SerializeField] private TimeController timeController;
        [SerializeField] private ObjectTimeRewindController objectTimeRewindController;

        private void Start()
        {
            timeController.Initialize(this);
            objectTimeRewindController.Initialize();
        }

        public void HandleRewindingTime()
        {
            objectTimeRewindController.RewindTimeForObjects();
        }

        public void HandleStopRewindingTime()
        {
            objectTimeRewindController.RecordForObjects();
        }
    }
}
