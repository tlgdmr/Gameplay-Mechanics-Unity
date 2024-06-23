using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class ObjectTimeRewindController : MonoBehaviour
    {
        private List<ObjectTimeRewindEntity> _objectTimeRewindEntities;
        public void Initialize()
        {
            _objectTimeRewindEntities = FindObjectsOfType<ObjectTimeRewindEntity>().ToList();
            foreach (var objectTimeRewindEntity in _objectTimeRewindEntities)
            {
                objectTimeRewindEntity.Initialize();
            }
        }

        public void RewindTimeForObjects()
        {
            foreach (var objectTimeRewindEntity in _objectTimeRewindEntities)
            {
                objectTimeRewindEntity.RewindTime();
            }
        }

        public void RecordForObjects()
        {
            foreach (var objectTimeRewindEntity in _objectTimeRewindEntities)
            {
                objectTimeRewindEntity.RecordTime();
            }
        }
    }
}