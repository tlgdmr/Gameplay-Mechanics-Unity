using GameplayMechanics.TimeControlling.DataClasses;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.Scripts
{
    public class TimeController : MonoBehaviour
    {
        [Header("Basic Time Controlling Values")]
        public BasicTimeControllingData basicTimeControllingData;
        [Header("Smooth Time Controlling Values")]
        public SmoothTimeControllingData smoothTimeControllingData;
        [Space]
        [SerializeField] private BasicTimeControlling basicTimeControlling;
        [SerializeField] private SmoothTimeControlling smoothTimeControlling;

        private void Start()
        {
            basicTimeControlling.Initialize(basicTimeControllingData);
            smoothTimeControlling.Initialize(smoothTimeControllingData);
        }

        private void Update()
        {
            GetBasicTimeControllingInput();
            GetSmoothTimeControllingInput();
        }

        private void GetBasicTimeControllingInput()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                basicTimeControlling.PauseGame();
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                basicTimeControlling.ResumeGame();
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                basicTimeControlling.ApplySlowMotion();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                basicTimeControlling.ApplyFastMotion();
            }
        }
        
        private void GetSmoothTimeControllingInput()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                StartCoroutine(smoothTimeControlling.ResumeGameCoroutine());
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                StartCoroutine(smoothTimeControlling.PauseGameCoroutine());
            }
        }
    }
}