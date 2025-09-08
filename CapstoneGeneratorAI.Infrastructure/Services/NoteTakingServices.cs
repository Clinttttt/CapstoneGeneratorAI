using CapstoneGeneratorAI.Domain.DTOs;
using CapstoneGeneratorAI.Domain.Entities;
using CapstoneGeneratorAI.Domain.Interface;
using CapstoneGeneratorAI.Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneGeneratorAI.Infrastructure.Services
{

    public class NoteTakingServices(ApplicationDbContext context) : INoteTakingServices
    {
        public async Task<IEnumerable<NoteTaking>> GetAllRecord()
        {
            var data =  await context.notetaking.ToListAsync();
            return data.Adapt<IEnumerable<NoteTaking>>();
        }
        public async Task<NoteTaking?> RecordNoteAsync(NoteTakingDTO note)
        {
            var data = note.Adapt<NoteTaking>();
            if (data is null)
            {
                return null;
            }
           await context.notetaking.AddAsync(data);
           await context.SaveChangesAsync();
            return data;

        }
        public async Task<NoteTakingDTO?> GetRecordAsync(int Id)
        {
            var data = await context.notetaking.FindAsync(Id);
            if(data is null)
            {
                return null;
            }
            return data.Adapt<NoteTakingDTO>();
        }
        public async Task<NoteTakingDTO?> EditRecordAsync(NoteTaking note)
        {
            var data = await context.notetaking.FindAsync(note.Id);
            if(data is null)
            {
                return null;
            }
            var updated = new NoteTaking
            {
                Title = data.Title,
                Content = data.Content,
            };
            return updated.Adapt<NoteTakingDTO>();

        }
        public async Task<bool> DeleteRecordAsync( int id)
        {
            var data = await context.notetaking.FirstOrDefaultAsync(s => s.Id == id);
            if(data is null)
            {
                return false;
            }
            var delete = context.notetaking.Remove(data);
            await context.SaveChangesAsync();
            return true;
        }
       
    }
}
