namespace Aishite.SettignsManagement
{
    public interface ISettingsProvider
    {
        Settings Get();
        Settings Save(Settings entity);
    }
}
