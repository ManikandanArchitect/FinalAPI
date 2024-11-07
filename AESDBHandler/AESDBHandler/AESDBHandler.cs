using AESEngine;
using AESModel;
using System;

namespace AESDBHandler
{
    public class AESDBHandler : IAESDBHandler
    {
        private readonly DropdownDataFetcher _dropdownDataFetcher;
        private readonly GenerateScript _generateScript;

        // Constructor with Dependency Injection
        public AESDBHandler(DropdownDataFetcher dropdownDataFetcher, GenerateScript generateScript)
        {
            _dropdownDataFetcher = dropdownDataFetcher ?? throw new ArgumentNullException(nameof(dropdownDataFetcher));
            _generateScript = generateScript ?? throw new ArgumentNullException(nameof(generateScript));
        }

        /// <summary>
        /// Generates a script based on the provided script model.
        /// </summary>
        /// <param name="scriptModel">The model containing script data.</param>
        /// <returns>A boolean indicating success or failure.</returns>
        public bool GenerateScript(ScriptModel scriptModel)
        {
            return _generateScript.ScriptData(scriptModel);
        }

        /// <summary>
        /// Retrieves AES data in JSON format for dropdown.
        /// </summary>
        /// <returns>A JSON string with dropdown data.</returns>
        public string GetAESData()
        {
            return _dropdownDataFetcher.GetDropDown();
        }
    }
}
