using System.Collections.Generic;
using GameplayMechanics.TimeControlling.RewindTimeControlling.DataClasses;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.Scripts
{
    public class ObjectTimeRewindEntity : MonoBehaviour
    {
        [SerializeField] private int maxNumberOfRewindCount;
        [SerializeField] private Rigidbody rb;
        private List<ObjectTransformData> _transformData;
        
        public bool IsRewinding { private set; get; }
        
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

            rb.isKinematic = true;
            var objectTransformData = _transformData[0];
            transform.position = objectTransformData.position;
            transform.rotation = objectTransformData.rotation;
            _transformData.RemoveAt(0);
        }

        public void RecordTime()
        {
            rb.isKinematic = false;
            if (_transformData.Count >= maxNumberOfRewindCount)
            {
                _transformData.RemoveAt(_transformData.Count - 1);
            }
            
            _transformData.Insert(0, new ObjectTransformData(transform.position, transform.rotation));
        }
    }
}