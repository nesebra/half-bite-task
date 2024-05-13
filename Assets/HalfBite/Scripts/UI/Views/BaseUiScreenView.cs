using HalfBite.Scripts.UI.Models;
using UnityEngine;

namespace HalfBite.Scripts.UI.Views
{
    public abstract class BaseUiScreenView : MonoBehaviour
    {
        public virtual void Open(BaseUiModel uiModel)
        {
            SubscribeAll();
        }

        public virtual void Close()
        {
            UnsubscribeAll();
            //todo: here should be a fabric or other pattern
            Destroy(gameObject);
        }

        protected abstract void SubscribeAll();
        protected abstract void UnsubscribeAll();
    }
}
