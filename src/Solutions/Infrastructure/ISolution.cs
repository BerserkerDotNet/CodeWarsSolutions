namespace Solutions.Infrastructure
{
    public interface ISolution
    {
        string DisplayName { get; }

        void Execute(IHost host);
    }
}
