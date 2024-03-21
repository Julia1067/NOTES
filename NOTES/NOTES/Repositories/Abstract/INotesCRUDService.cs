using NOTES.Data.Domain;
using NOTES.Data.DTO;

namespace NOTES.Repositories.Abstract
{
    public interface INotesCRUDService
    {
        public Task<StatusModel> CreateNoteAsync(CreateNoteModel note);

        public Task<StatusModel> UpdateNoteAsync(CreateNoteModel note);

        public Task<StatusModel> DeleteNoteAsync(string noteId);

        public Task<NoteModel> GetCurretNoteAsync(string noteId);

        public Task<List<NoteModel>> GetNotesAsync();
    }
}
