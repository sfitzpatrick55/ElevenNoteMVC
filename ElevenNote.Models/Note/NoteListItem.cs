using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Models.Note
{
	public class NoteListItem
	{
        public int NoteId { get; set; }
        public string Title { get; set; }

        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}

