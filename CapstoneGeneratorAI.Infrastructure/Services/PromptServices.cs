using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Interface;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Infrastructure.Services
{
    public class PromptServices : IPromptServices
    {
        private readonly HttpClient _http;
        public PromptServices(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
        }
        public string PromptAsync(Industry_Options industry, Project_Type type)
        {
            var industries = industry switch
            {
                Industry_Options.All => "random field",
                Industry_Options.Energy => "Energy",
                Industry_Options.Business => "Business",
                Industry_Options.Entertainment => "Entertainment",
                Industry_Options.Government => "Government",
                Industry_Options.Agriculture => "Agriculture",
                Industry_Options.Healthcare => "HealthCare",
                Industry_Options.Cybersecurity => "CyberSecurity",
                Industry_Options.Technology => "Technology",
                Industry_Options.Education => "Education",
                _ => "any industry of your choice"
            };
            var types = type switch
            {
                Project_Type.AI_App => "AI Application",
                Project_Type.Web_App => "Web Application",
                Project_Type.Mobile_App => "Mobile Application",
                Project_Type.Data_App => "Data Application",
                Project_Type.Desktop_App => "Desktop Application",
                Project_Type.IoT_App => "IOT Application",
                Project_Type.All => "any type of application"
,  
                _ => "any type of application"
            };
            return $"Generate exactly 1 unique capstone project title and 5 features of it. of {industries} and the type of {types} Return only the title, a clear description and make sure to have minimum of 5 features with 2-3 words each.";



        }


    }

}