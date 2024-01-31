using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotesAPI.Models
{
    [Table("Notes")]
    public class Note
    {
        [Column("note_id")]
        [Key]
        public int Id { get; set; }
        [Column("content")]
        [Required]
        public string Content { get; set; }
        [Column("tags")]
        public List<string> Tags { get; set; }

        public const string PhoneTag = "PHONE";
        public const string EmailTag = "EMAIL";
    }
}