namespace FreeIt.Domain.Interfaces.Models.ConfigsInterfaces
{
    public interface IDatabaseConfiguration
    {
        string DbName { get; }

        string ConnectionString { get; }
    }
}