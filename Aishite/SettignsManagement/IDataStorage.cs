namespace Aishite.SettignsManagement
{
    public interface IDataStorage
    {
        T? GetValue<T>(string key) where T : class;
        void SetValue<T>(string key, T value) where T : class;
    }
}
