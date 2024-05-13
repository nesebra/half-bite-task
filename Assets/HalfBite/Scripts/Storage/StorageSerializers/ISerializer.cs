namespace HalfBite.Scripts.Storage.StorageSerializers
{
    public interface ISerializer
    {
        public string ObjectToString(object data);
        
        public T StringToObject<T>(string data) where T : class;
    }
}