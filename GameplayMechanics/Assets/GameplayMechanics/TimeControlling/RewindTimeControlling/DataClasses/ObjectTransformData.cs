using System;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.RewindTimeControlling.DataClasses
{
    [Serializable]
    public class ObjectTransformData
    {
        public Vector3 position;
        public Quaternion rotation;
        
        public ObjectTransformData(Vector3 currentObjectPosition, Quaternion currentObjectRotation)
        {
            position = currentObjectPosition;
            rotation = currentObjectRotation;
        }
    }
}