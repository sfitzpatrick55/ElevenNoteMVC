using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Models.Note
{
	public class NoteDetail
	{
        public int NoteId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        [Display(Name="Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name="Date Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}

