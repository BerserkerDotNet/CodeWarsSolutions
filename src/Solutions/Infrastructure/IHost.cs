namespace Solutions.Infrastructure
{
    public interface IHost
    {
        T Read<T>(string message);

        T Read<T>();

        void Show(string message);
    }
}
