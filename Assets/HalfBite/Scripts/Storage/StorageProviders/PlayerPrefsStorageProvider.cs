using HalfBite.Scripts.Storage.StorageSerializers;
using UnityEngine;

namespace HalfBite.Scripts.Storage.StorageProviders
{
    public class PlayerPrefsStorageProvider : BaseStorageProvider<ISerializer>
    {
        public PlayerPrefsStorageProvider(ISerializer serializer) : base(serializer)
        {
        }

        public override void Save<TO>(string key, TO objectToSave)
        {
            var stringData = serializer.ObjectToString(objectToSave);
            PlayerPrefs.SetString(key, stringData);
        }

        public override TO Load<TO>(string key)
        {
            var stringData = PlayerPrefs.GetString(key, null);

            if (stringData == null)
            {
                return null;
            }

            return serializer.StringToObject<TO>(stringData);
        }
    }
}