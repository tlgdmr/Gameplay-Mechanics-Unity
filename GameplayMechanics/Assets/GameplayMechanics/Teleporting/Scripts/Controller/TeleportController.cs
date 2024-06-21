using System.Collections.Generic;
using System.Linq;
using GameplayMechanics.Teleporting.Scripts.Entities;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Controller
{
    public class TeleportController : MonoBehaviour
    {
        private List<TeleportGroupEntity> _teleportEntities;
    
        public void Initialize()
        {
            _teleportEntities = FindObjectsOfType<TeleportGroupEntity>().ToList();

            foreach (var teleportEntity in _teleportEntities)
            {
                teleportEntity.Initialize();
            }
        }
    }
}
