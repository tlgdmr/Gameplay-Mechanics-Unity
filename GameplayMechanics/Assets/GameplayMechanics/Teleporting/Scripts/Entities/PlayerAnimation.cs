using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Serialization;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Renderer objectRenderer;
    [SerializeField] private float dissolvingAnimDuration;
    [SerializeField] private float delayBetweenAnimations;
    
    private Action<bool> _onPlayerTeleportingEnd;
    private Action _onPlayerTeleportingBreak;
    private static readonly int DissolveStrength = Shader.PropertyToID("_DissolveStrength");
    private MaterialPropertyBlock _propertyBlock;

    public void Initialize(Action<bool> onPlayerTeleportingEnd, Action onPlayerTeleportingBreak)
    {
        _propertyBlock = new MaterialPropertyBlock();
        _onPlayerTeleportingEnd = onPlayerTeleportingEnd;
        _onPlayerTeleportingBreak = onPlayerTeleportingBreak;
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
            
            _propertyBlock.SetFloat(DissolveStrength, dissolveStrengthValue);
            objectRenderer.SetPropertyBlock(_propertyBlock);
            
            yield return null;
        }
        
        StartCoroutine(ApplyDelayBetweenAnimation());
    }
    
    private IEnumerator ApplyDelayBetweenAnimation()
    {
        _onPlayerTeleportingBreak?.Invoke();
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
            
            _propertyBlock.SetFloat(DissolveStrength, dissolveStrengthValue);
            objectRenderer.SetPropertyBlock(_propertyBlock);
            
            yield return null;
        }
        
        OnTeleportingEnd();
    }

    private void OnTeleportingEnd()
    {
        _onPlayerTeleportingEnd?.Invoke(false);
    }
}