using System.Threading.Tasks;

namespace Database
{
    public interface IEngineCore
    {
        void Load();
        string Query(string queryText);
    }
}