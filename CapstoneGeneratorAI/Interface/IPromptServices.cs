using CapstoneGeneratorAI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapstoneGeneratorAI.Domain.Enums.Industry;

namespace CapstoneGeneratorAI.Domain.Interface
{
    public interface IPromptServices
    {
        string PromptAsync(Industry_Options industry, Project_Type type);
    }
}
