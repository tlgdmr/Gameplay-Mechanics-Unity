using System.Collections.Generic;
using System.Linq;
using GameplayMechanics.Teleporting.Scripts.Entities;
using UnityEngine;

namespace GameplayMechanics.Teleporting.Scripts.Controller
{
    public class PlayerController : MonoBehaviour
    {
        private List<PlayerEntity> _playerEntities;
    
        public void Initialize()
        {
            _playerEntities = FindObjectsOfType<PlayerEntity>().ToList();

            foreach (var playerEntity in _playerEntities)
            {
                playerEntity.Initialize();
            }
        }
    }
}
