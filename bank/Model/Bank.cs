using System.ComponentModel.DataAnnotations;

namespace bank.Model
{
    public class Bank
    {
        [Key]
        public int bankid { get; set; }
        [Required]
        [MaxLength(100)]
        public string bankname { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string banktype { get; set; } = string.Empty;

        public string bankbranch {  get; set; } = string.Empty ;

        [Required]
      
        public int bankpin { get; set; }

    }
}
