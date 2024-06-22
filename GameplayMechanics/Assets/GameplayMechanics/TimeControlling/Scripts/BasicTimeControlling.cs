using GameplayMechanics.TimeControlling.DataClasses;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.Scripts
{
    public class BasicTimeControlling : MonoBehaviour
    {
        private BasicTimeControllingData _basicTimeControllingData;
        
        public void Initialize(BasicTimeControllingData basicTimeControllingData)
        {
            _basicTimeControllingData = basicTimeControllingData;
        }
        
        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
        
        public void ApplySlowMotion()
        {
            Time.timeScale = _basicTimeControllingData.slowMotionValue;
        }
        
        public void ApplyFastMotion()
        {
            Time.timeScale = _basicTimeControllingData.fastMotionValue;
        }
    }
}