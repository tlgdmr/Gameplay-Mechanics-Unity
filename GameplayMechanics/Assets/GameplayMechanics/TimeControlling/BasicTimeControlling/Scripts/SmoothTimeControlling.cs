using System.Collections;
using GameplayMechanics.TimeControlling.DataClasses;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.Scripts
{
    public class SmoothTimeControlling : MonoBehaviour
    {
        private SmoothTimeControllingData _smoothTimeControllingData;
        
        public void Initialize(SmoothTimeControllingData smoothTimeControllingData)
        {
            _smoothTimeControllingData = smoothTimeControllingData;
        }
        
        public IEnumerator PauseGameCoroutine()
        {
            float elapsedTime = 0;

            while (elapsedTime < _smoothTimeControllingData.smoothPauseDuration)
            {
                elapsedTime += Time.unscaledDeltaTime; // Use unscaledDeltaTime to continue counting time even as timeScale approaches 0
                var updatedTimeScaleValue = Mathf.Lerp(1, 0, elapsedTime / _smoothTimeControllingData.smoothPauseDuration);
                Time.timeScale = updatedTimeScaleValue;
                yield return null; // Wait for the next frame
            }

            Time.timeScale = 0; // Ensure time scale is set to 0 after finishing
        }
        
        public IEnumerator ResumeGameCoroutine()
        {
            float elapsedTime = 0;

            while (elapsedTime < _smoothTimeControllingData.smoothResumeDuration)
            {
                elapsedTime += Time.unscaledDeltaTime; // Continue counting time with unscaledDeltaTime
                var updatedTimeScaleValue = Mathf.Lerp(0, 1, elapsedTime / _smoothTimeControllingData.smoothResumeDuration);
                Time.timeScale = updatedTimeScaleValue;
                yield return null; // Wait for the next frame
            }

            Time.timeScale = 1; // Ensure time scale is set to 1 after finishing
        }
    }
}