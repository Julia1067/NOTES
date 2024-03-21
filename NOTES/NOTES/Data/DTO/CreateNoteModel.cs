using System.ComponentModel.DataAnnotations.Schema;

namespace NOTES.Data.DTO
{
    public class CreateNoteModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
