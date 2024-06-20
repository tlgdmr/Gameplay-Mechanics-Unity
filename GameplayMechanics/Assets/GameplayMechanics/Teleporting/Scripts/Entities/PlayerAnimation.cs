using System;
using System.Collections;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Entities
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Material dissolveMaterial;
        [SerializeField] private float dissolvingAnimDuration;
        [SerializeField] private float delayBetweenAnimations;
        
        private Action<bool> _onPlayerTeleportingEnd;
        private static readonly int DissolveStrength = Shader.PropertyToID("_DissolveStrength");
        
        public void Initialize(Action<bool> onPlayerTeleportingEnd)
        {
            _onPlayerTeleportingEnd = onPlayerTeleportingEnd;
        }

        public void StartTeleportingAnim()
        {
            StartCoroutine(StartDissolvingAnimation());
        }

        private IEnumerator StartDissolvingAnimation()
        {
            var elapsedTime = 0.0f;
            
            while (elapsedTime < dissolvingAnimDuration)
            {
                elapsedTime += Time.deltaTime;
                var dissolveStrengthValue = Mathf.Lerp(0.0f, 1.0f, elapsedTime / dissolvingAnimDuration);
                dissolveMaterial.SetFloat(DissolveStrength,dissolveStrengthValue);
                yield return null;
            }
            
            StartCoroutine(ApplyDelayBetweenAnimation());
        }
        
        private IEnumerator ApplyDelayBetweenAnimation()
        {
            yield return new WaitForSeconds(delayBetweenAnimations);
            StartCoroutine(StartReDissolvingAnimation());
        }
        
        
        private IEnumerator StartReDissolvingAnimation()
        {
            var elapsedTime = 0.0f;
            
            while (elapsedTime < dissolvingAnimDuration)
            {
                elapsedTime += Time.deltaTime;
                var dissolveStrengthValue = Mathf.Lerp(1.0f, 0.0f, elapsedTime / dissolvingAnimDuration);
                dissolveMaterial.SetFloat(DissolveStrength,dissolveStrengthValue);
                yield return null;
            }
            
            OnTeleportingEnd();
        }

        private void OnTeleportingEnd()
        {
            _onPlayerTeleportingEnd?.Invoke(false);
        }
    }
}