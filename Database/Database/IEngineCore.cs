using System.Threading.Tasks;

namespace Database
{
    public interface IEngineCore
    {
        void Load();
        Task<string> QueryAsync(string queryText);
    }
}