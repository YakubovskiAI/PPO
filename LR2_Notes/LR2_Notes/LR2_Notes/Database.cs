using SQLite;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LR2_Notes
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _databese;

        public Database(string dbPath)
        {
            _databese = new SQLiteAsyncConnection(dbPath);
            _databese.CreateTableAsync<Note>();
        }

        public Task<List<Note>> GetNotesAsync()
        {
            return _databese.Table<Note>().ToListAsync();
        }

        public Task<int> SaveNoteAsync(Note note)
        {
            return _databese.InsertAsync(note);
        }

        public Task<int> UpdateNoteAsync(Note note)
        {
            return _databese.UpdateAsync(note);
        }

        public Task<int> DeleteNoteAsync(Note note)
        {
            return _databese.DeleteAsync(note);
        }
    }
}
