namespace NOTES
{
    public class NoteItem
    {
        public Guid Id = Guid.NewGuid();

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
