using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class Genre
    {
        public virtual int GenreId { get; set; }

        [Required(ErrorMessage = "Genre Name cannot be blank")]
        public virtual string Name { get; set; }

        [StringLength(300, ErrorMessage = "TLDR; let's keep it at a reasonable length")]
        public virtual string Description { get; set; }        
    }
}