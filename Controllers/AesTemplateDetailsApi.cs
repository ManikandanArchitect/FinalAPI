/*
 * Script Generator
 *
 * To get the template, product, and raw data from the database
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Newtonsoft.Json;
using ScriptGenerator.Attributes;
using ScriptGenerator.Models;
using AESEngine;
using System;

namespace ScriptGenerator.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class AesTemplateDetailsApiController : ControllerBase
    {
        private readonly IAESService _aesService;

        public AesTemplateDetailsApiController(IAESService aesService)
        {
            _aesService = aesService;
        }
        /// <summary>
        /// Get the details for template
        /// </summary>
        /// <remarks>Get the template</remarks>
        /// <response code="200">Successful operation</response>
        [HttpGet]
        [Route("/api/v1/getaes")]
        [ValidateModelState]
        [SwaggerOperation("GetAes")]
        [SwaggerResponse(statusCode: 200, type: typeof(InlineResponse200), description: "Successful operation")]
        public virtual IActionResult GetAes()
        {
            try
            {
                var data = _aesService.AESDataCollector();
                return Ok(data);
            }
            catch (Exception ex)
            {
                // Log exception
                return StatusCode(500, "An error occurred while fetching AES data.");
            }

        }
    }
}
