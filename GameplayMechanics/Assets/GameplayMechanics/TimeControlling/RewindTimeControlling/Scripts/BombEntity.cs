using GameplayMechanics.TimeControlling.RewindTimeControlling.Interfaces;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class BombEntity : MonoBehaviour
    {
        [SerializeField] private float effectedArea;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ApplyBombEffect();
            }
        }

        private void ApplyBombEffect()
        {
            var colliders = Physics.OverlapSphere(transform.position, effectedArea);

            foreach (var objectCollider in colliders)
            {
                if (objectCollider.TryGetComponent(out IDamageable  damageable))
                {
                    damageable.ApplyForce(transform.position);
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, effectedArea);
        }
    }
}