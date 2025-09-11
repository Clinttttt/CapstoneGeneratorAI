using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.Enums
{
    public class Industry
    {

        public enum Industry_Options
        {
            All,
            Business,
            Education,
            Healthcare,
            Technology,
            Entertainment,
            Agriculture,          
            Government,
            Cybersecurity,
            Energy
        }

        public enum Project_Type
        {
            Web_App,
            Mobile_App,
            Desktop_App,
            IoT_App,
            Data_App,
            AI_App,
            All,
        }

    }
}
