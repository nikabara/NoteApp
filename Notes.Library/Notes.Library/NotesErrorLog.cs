namespace Notes.Library
{
    public class NotesErrorLog
    {
        public int ErrorId { get; set; }
        public int ErrorNumber { get; set; }
        public byte ErrorState { get; set; }
        public byte ErrorSeverity { get; set; }
        public string? ErrorMessage { get; set; }
        public int ErrorLine { get; set; }
    }
}
