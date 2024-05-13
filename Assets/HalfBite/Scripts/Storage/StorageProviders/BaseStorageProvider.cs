using HalfBite.Scripts.Storage.StorageSerializers;

namespace HalfBite.Scripts.Storage.StorageProviders
{
    public abstract class BaseStorageProvider<TS> where TS: ISerializer
    {
        protected readonly ISerializer serializer;
        
        public BaseStorageProvider(TS serializer)
        {
            this.serializer = serializer;
        }

        public abstract void Save<TO>(string key, TO objectToSave) where TO : class;
        public abstract TO Load<TO>(string key) where TO : class;
    }
}