using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NOTES.Data.Domain
{
    public class NoteModel
    {
        [Key]
        public string NoteId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime CreationDate { get; set; }
        
        [Column(TypeName = "timestamp")]
        public DateTime LastUpdateDate { get; set; }
    }
}
