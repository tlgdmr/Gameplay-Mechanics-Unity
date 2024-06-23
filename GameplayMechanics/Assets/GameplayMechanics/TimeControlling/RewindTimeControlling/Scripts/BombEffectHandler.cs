using GameplayMechanics.TimeControlling.RewindTimeControlling.Interfaces;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class BombEffectHandler : MonoBehaviour, IDamageable
    {
        [SerializeField] private Rigidbody rb;
        
        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
        [SerializeField] private float upwardsModifier;
        
        public void ApplyForce(Vector3 explosionForcePoint)
        {
            rb.AddExplosionForce(explosionForce, explosionForcePoint,explosionRadius,upwardsModifier);
        }
    }
}