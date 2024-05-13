using HalfBite.Scripts.Storage.StorageProviders;
using HalfBite.Scripts.Storage.StorageSerializers;
using Zenject;

namespace HalfBite.Scripts.Storage
{
    public class PlayerStorage : IInitializable
    {
        private BaseStorageProvider<ISerializer> storageProvider;
        
        public void Initialize()
        {
            storageProvider = new PlayerPrefsStorageProvider(new JsonSerializer());
        }

        public void Save<T>(string key, T objectToSave) where T : class
        {
            storageProvider.Save(key, objectToSave);
        }

        public T Load<T>(string key) where T : class
        {
            return storageProvider.Load<T>(key);
        }
    }
}
