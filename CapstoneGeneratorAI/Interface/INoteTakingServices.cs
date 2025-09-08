using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Domain.Interface
{
    public interface INoteTakingServices
    {
        Task<IEnumerable<NoteTaking>> GetAllRecord();
        Task<NoteTaking?> RecordNoteAsync(NoteTakingDTO note);
        Task<NoteTakingDTO?> GetRecordAsync(int record);
        Task<NoteTakingDTO?> EditRecordAsync(NoteTaking note);
        Task<bool> DeleteRecordAsync(int id);
    }
}
