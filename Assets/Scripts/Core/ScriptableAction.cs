using System;
using UnityEngine;

namespace Core
{
    public abstract class ScriptableAction : ScriptableObject
    {
        public abstract Type PropertyType { get; } 
        public abstract bool CanApply();
        public abstract void Apply();
    }
}