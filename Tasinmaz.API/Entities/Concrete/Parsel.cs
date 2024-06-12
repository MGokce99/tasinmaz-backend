using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Core.Entities.Abstract;
using Tasinmaz.API.Core.Entities.Concrete;

namespace Entities.Concrete
{
    [Table("tblparsel")]
    public class Parsel : IEntity
    {
        [Key, Column("parselid")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParselId { get; set; }
        //örnek değer girildi.
        [Column("il")]
        public int Il { get; set; }

        [Required, Column("ilce")]
        public int Ilce { get; set; }

        //Tablo değeri kolonlandı.
        [Column("mahalleid")]
        public int MahalleId { get; set; }

        [ForeignKey("MahalleId")]
        public Mahalle Mahalle { get; set; }

        [Required, Column("ada"), StringLength(30)]
        public string AdaNo { get; set; }

        [Required, Column("parsel"), StringLength(30)]

        public string ParselNo { get; set; }

        [Required, Column("nitelik"), StringLength(30)]

        public string Nitelik { get; set; }
        
        [Required, Column("adres"), StringLength(60)]

        public string Adres { get; set; }

        [Column("userid")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required, Column("x"), StringLength(155)]
        public string coorX { get; set; }

        [Required, Column("y"), StringLength(155)]
        public string coorY { get; set; }
    }
}
