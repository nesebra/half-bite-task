using System;
using UnityEngine;

namespace HalfBite.Scripts.Tools
{
    public class MonoBehaviourHelper : MonoBehaviour
    {
        public event Action OnUpdate;
        public event Action OnStart;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }  
        
        private void Start()
        {
            OnStart?.Invoke();
        }
    }
}