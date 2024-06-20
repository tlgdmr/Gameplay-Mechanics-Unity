using System.Collections.Generic;
using System.Linq;
using GameplayMechanics.Teleporting.Scripts.Entities;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Controller
{
    public class TeleportController : MonoBehaviour
    {
        private List<TeleportEntity> _teleportEntities;
    
        public void Initialize()
        {
            _teleportEntities = FindObjectsOfType<TeleportEntity>().ToList();

            foreach (var teleportEntity in _teleportEntities)
            {
                teleportEntity.Initialize();
            }
        }
    }
}
