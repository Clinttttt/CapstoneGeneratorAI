using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.Entities
{
   public class Flashcard
    {
        public int Id { get; set; }
        public int NoteId { get; set; }
        public string? Question { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool UserEdited { get; set; } 
    }
}
