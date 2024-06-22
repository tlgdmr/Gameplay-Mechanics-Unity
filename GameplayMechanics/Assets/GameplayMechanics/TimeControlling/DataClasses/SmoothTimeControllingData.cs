using System;
using UnityEngine.Serialization;

namespace GameplayMechanics.TimeControlling.DataClasses
{
    [Serializable]
    public class SmoothTimeControllingData
    {
        public float smoothResumeDuration;
        public float smoothPauseDuration;
    }
}