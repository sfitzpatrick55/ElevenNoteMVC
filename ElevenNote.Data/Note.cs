using System;
using System.ComponentModel.DataAnnotations;

namespace ElevenNote.Data
{
	public class Note
	{
        [Key]
        public int NoteId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        [Display(Name = "Date Created")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Date Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; } // '?' means the modified UTC can be null
    }
}