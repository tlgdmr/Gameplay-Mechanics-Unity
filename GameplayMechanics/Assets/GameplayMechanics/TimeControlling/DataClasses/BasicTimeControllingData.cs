using System;
using UnityEngine;

namespace GameplayMechanics.TimeControlling.DataClasses
{
    [Serializable]
    public class BasicTimeControllingData
    {
        [Range(0,1)]
        public float slowMotionValue;
        [Range(1,10)]
        public float fastMotionValue;
    }
}