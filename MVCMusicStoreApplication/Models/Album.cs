using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Models
{
    //[Bind(Exclude = "AlbumId")]
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int ArtistId { get; set; }

        [Display(Name = "Album Title")]
        [Required (ErrorMessage = "Album Title cannot be blank")]
        public virtual string Title { get; set; }

        [Display(Name = "Album Price")]
        [Required]
        [Range(0.01, 100, ErrorMessage = "Album price must be between $0.01 and $100.00")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public virtual decimal Price { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }

        [Display(Name = "Album Art URL")]
        [Required]
        public virtual string AlbumArtUrl {get;set;}
        //public virtual string AdditionalInfo { get; set; }
        public virtual bool Instock { get; set; }
        public virtual string CountryOfOrigin { get; set; }
    }
}