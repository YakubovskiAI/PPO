using SQLite;

namespace LR2_Notes
{
    public class Note
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Description { get; set; }
    }
}
