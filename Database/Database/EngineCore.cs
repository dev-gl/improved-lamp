﻿using System.Threading.Tasks;

namespace Database
{
    public class EngineCore : IEngineCore
    {
        public void Load()
        {
        }

        public async Task<string> QueryAsync(string queryText)
        {

            return await Task.FromResult("No Results Found");
        }
    }
}
