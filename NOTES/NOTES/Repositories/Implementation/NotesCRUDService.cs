using Microsoft.EntityFrameworkCore;
using NOTES.Data.Domain;
using NOTES.Data.DTO;
using NOTES.Repositories.Abstract;

namespace NOTES.Repositories.Implementation
{
    public class NotesCRUDService : INotesCRUDService
    {
        private readonly DatabaseContext _dbContext;

        public NotesCRUDService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StatusModel> CreateNoteAsync(CreateNoteModel note)
        {
            StatusModel status = new();

            try
            {
                var newNote = new NoteModel()
                {
                    NoteId = Guid.NewGuid().ToString(),
                    Name = note.Name,
                    Description = note.Description,
                    CreationDate = DateTime.Now,
                    LastUpdateDate = DateTime.Now
                };

                await _dbContext.Notes.AddAsync(newNote);

                await _dbContext.SaveChangesAsync();

                status.Status = true;
                status.Message = "Note successfully created";
            }
            catch (Exception ex)
            {
                status.Status = false;
                status.Message = ex.Message;
            }

            return status;
        }

        public async Task<StatusModel> DeleteNoteAsync(string noteId)
        {
            StatusModel status = new();
            try
            {
                var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId);

                _dbContext.Notes.Remove(note);

                await _dbContext.SaveChangesAsync();

                status.Status = true;
                status.Message = "Note successfully deleted";
            }
            catch(Exception ex)
            {
                status.Status = false;
                status.Message = ex.Message;
            }

            return status;
        }

        public async Task<NoteModel> GetCurretNoteAsync(string noteId)
        {
            var note = await _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == noteId);

            if (note != null)
                return note;

            return null;
        }

        public async Task<List<NoteModel>> GetNotesAsync()
        {
            var notesList = await _dbContext.Notes.ToListAsync();

            return notesList;
        }

        public async Task<StatusModel> UpdateNoteAsync(CreateNoteModel note)
        {
            StatusModel status = new();

            try
            {
                var notesList = await _dbContext.Notes.ToListAsync();
                var first = notesList.FirstOrDefault();
                var newNote = await _dbContext.Notes.FirstOrDefaultAsync(n => n.NoteId == note.Id);

                if (note.Name != null)
                {
                    newNote.Name = note.Name;
                }
                newNote.Description = note.Description;
                newNote.LastUpdateDate = DateTime.Now;

                _dbContext.Notes.Update(newNote);

                await _dbContext.SaveChangesAsync();

                status.Status = true;
                status.Message = "Note successfully updated";
            }
            catch(Exception ex)
            {
                status.Status = false; 
                status.Message = ex.Message;
            }

            return status;
        }
    }
}
