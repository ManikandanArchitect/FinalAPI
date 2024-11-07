using AESDBHandler.DAL;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace AESDBHandler
{
    public class DropdownDataFetcher
    {
        private readonly ScriptGeneratorEntities _dbContext;

        // Constructor Injection for better testability and flexibility
        public DropdownDataFetcher(ScriptGeneratorEntities dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        /// <summary>
        /// Retrieves dropdown data in JSON format.
        /// </summary>
        /// <returns>JSON string with dropdown data.</returns>
        public string GetDropDown()
        {
            try
            {
                var dropDownData = _dbContext.ScriptTemplates
                    .Select(x => new
                    {
                        x.sd_st_attr_general_method_name,
                        x.sd_snippet_group_name,
                        x.sosv_setup_name
                    })
                    .Distinct()
                    .ToList();

                return JsonConvert.SerializeObject(dropDownData, Formatting.Indented);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                // You could return a meaningful error message or rethrow the exception based on requirements
                Console.WriteLine($"An error occurred: {ex.Message}");
                return string.Empty; // or throw; to let calling code handle it
            }
        }
    }
}
