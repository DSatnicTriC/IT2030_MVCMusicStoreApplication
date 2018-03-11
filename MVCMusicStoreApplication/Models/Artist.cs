using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCMusicStoreApplication.Models
{
    public class Artist
    {
        public virtual int ArtistId { get; set; }

        [Required(ErrorMessage = "Artist Name cannot be blank")]
        public virtual string Name { get; set; }
    }
}