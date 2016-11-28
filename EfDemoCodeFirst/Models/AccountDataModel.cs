using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfDemo
{
    //[Table("Accounts")]
    public class AccountDataModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(30)]
        [Required]
        public string Account { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }

        public DateTime? Expire { get; set; }

        public DateTime Create { get; set; }
    }
}