namespace Timetable.Base.Interfaces.Services
{
    public interface IConfigurationService
    {
        object GetValue(string setting);

        void SetValue<T>(string setting, T value);
    }
}
