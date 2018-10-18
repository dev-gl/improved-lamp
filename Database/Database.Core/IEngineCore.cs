using System.Threading.Tasks;

namespace Database.Core
{
    public interface IEngineCore
    {
        void Load();
        Task<string> QueryAsync(string queryText);
    }
}