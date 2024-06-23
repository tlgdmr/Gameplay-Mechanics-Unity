using System.Collections.Generic;
using GameplayMechanics.TimeControlling.RewindTimeControlling.DataClasses;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class ObjectTimeRewindEntity : MonoBehaviour
    {
        [SerializeField] private int maxNumberOfRewindCount;
        private List<ObjectTransformData> _transformData;
        
        public void Initialize()
        {
            _transformData = new List<ObjectTransformData>();
        }

        public void RewindTime()
        {
            if (_transformData.Count <= 0)
            {                
                RecordTime();
                return;
            }

            transform.position = _transformData[0].position;
            transform.rotation = _transformData[0].rotation;
            _transformData.RemoveAt(0);
        }

        public void RecordTime()
        {
            if (_transformData.Count >= maxNumberOfRewindCount)
            {
                _transformData.RemoveAt(_transformData.Count - 1);
            }
            
            _transformData.Insert(0, new ObjectTransformData(transform.position, transform.rotation));
        }
    }
}