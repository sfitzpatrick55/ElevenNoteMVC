using System;
using ElevenNote.Data;
using ElevenNote.Models.Note;

namespace ElevenNote.Services
{
	public class NoteService
	{
		private readonly Guid _userId;

        private readonly ApplicationDbContext _ctx;

		public NoteService(Guid userId, ApplicationDbContext ctx)
		{
			_userId = userId;
            _ctx = ctx;
		}

		public bool CreateNote(NoteCreate model)
        {
			var entity = new Note()
			{
				OwnerId = _userId,
				Title = model.Title,
				Content = model.Content,
				CreatedUtc = DateTimeOffset.Now
			};

            
				_ctx.Notes.Add(entity);
				return _ctx.SaveChanges() == 1;
            
        }

        public IEnumerable<NoteListItem> GetNotes()
        {
            var query = _ctx
                .Notes
                .Where(e => e.OwnerId == _userId)
                .Select(
                        e =>
                            new NoteListItem
                            {
                                NoteId = e.NoteId,
                                Title = e.Title,
                                CreatedUtc = e.CreatedUtc
                            }
                    );
                return query.ToArray();
        }
    }
}

