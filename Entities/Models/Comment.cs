using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public string? CommentText { get; set; }
        [Required]
        [ForeignKey("Animal")]
        public int AnimalId { get; set; }
        public virtual Animal? Animal { get; set; }
    }
}
