using AESModel; 
using System;

namespace AESEngine
{
    public class AESService : IAESService
    {
        
        private readonly IAESDBHandler _aesDbHandler;

        // Constructor injection of IAESDBHandler
        public AESService(IAESDBHandler aesDbHandler)
        {
            _aesDbHandler = aesDbHandler ?? throw new ArgumentNullException(nameof(aesDbHandler));
        }

        // Implementing the AESDataCollector method
        public string AESDataCollector()
        {
            // Calling GetAESData method from IAESDBHandler
            var data = _aesDbHandler.GetAESData();
            return data;
        }

        // You can implement the GenerateScript method if needed
        public bool GenerateScript(ScriptModel scriptModel)
        {
            return _aesDbHandler.GenerateScript(scriptModel);
        }
    }
}
