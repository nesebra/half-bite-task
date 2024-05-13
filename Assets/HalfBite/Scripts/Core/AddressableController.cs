using System;
using System.Collections;
using HalfBite.Scripts.Tools;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Zenject;
using Logger = HalfBite.Scripts.Tools.Logger;

namespace HalfBite.Scripts.Core
{
    public class AddressableController
    {
        [Inject] private MonoBehaviourHelper monoBehaviourHelper;
        
        public void Load<T>(string key, Action<T> result) where T : class
        {
            monoBehaviourHelper.StartCoroutine(CoLoad(key, result));
        }
        
        private static IEnumerator CoLoad<T>(string key, Action<T> result) where T : class
        {
            var asyncOperationHandler = Addressables.LoadAssetAsync<T>(key);
            yield return asyncOperationHandler;
            
            if (asyncOperationHandler.Status == AsyncOperationStatus.Succeeded)
            {
                result?.Invoke(asyncOperationHandler.Result);
            }
            else
            {
                Logger.Log($"error while loading addressable {key} -> {asyncOperationHandler.OperationException}", 
                   Logger.LoggerAreas.Core, Logger.LoggerTypes.Error);
                result?.Invoke(null);
            }
        }
    }
}