﻿using System;
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

        public NoteDetail GetNoteById(int id)
        {
            var entity = _ctx
                .Notes
                .Single(e => e.NoteId == id && e.OwnerId == _userId);
            return
                new NoteDetail
                {
                    NoteId = entity.NoteId,
                    Title = entity.Title,
                    Content = entity.Content,
                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc = entity.ModifiedUtc
                };        
        }

        public bool UpdateNote(NoteEdit model)
        {
            var entity = _ctx
                .Notes
                .Single(e => e.NoteId == model.NoteId && e.OwnerId == _userId);

            entity.Title = model.Title;
            entity.Content = model.Content;
            entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _ctx.SaveChanges() == 1;
        }

        public bool DeleteNote(int noteId)
        {
            var entity = _ctx
                .Notes
                .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

            _ctx.Notes.Remove(entity);

            return _ctx.SaveChanges() == 1;
        }
    }
}

