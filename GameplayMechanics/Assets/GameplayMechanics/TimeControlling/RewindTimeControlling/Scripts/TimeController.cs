using GameplayMechanics.TimeControlling.RewindTimeControlling.Interfaces;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class TimeController : MonoBehaviour
    {
        private IGameManager _gameManager;
        
        public void Initialize(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.A))
            {
                StartRewind();
                Debug.Log("rewinding");
            }
            else
            {
                StopRewind();
                Debug.Log("not rewinding");
            }
        }

        private void StartRewind()
        {
            _gameManager.HandleRewindingTime();
        }
        
        private void StopRewind()
        {
            _gameManager.HandleStopRewindingTime();
        }
    }
}