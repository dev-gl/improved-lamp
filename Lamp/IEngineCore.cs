using System.Threading.Tasks;

namespace Lamp
{
    public interface IEngineCore
    {
        void Load();
        Task<string> QueryAsync(string queryText);
    }
}