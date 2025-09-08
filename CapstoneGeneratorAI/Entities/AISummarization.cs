using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.Entities
{
   public class AISummarization
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
