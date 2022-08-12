using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingAppTest
{
    
    
    public class User
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("user_id")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        public Profile Profile { get; set; }
    }
    public class Profile
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("profile_id")]
        public int id { get; set; }


        public int userId { get; set; }
        public User user { get; set; }


        public string? first_name { get; set; } = string.Empty;
        public string? last_name { get; set; } = string.Empty;
        public string? address { get; set; } = string.Empty;

        public ICollection<Trade> Trades { get; set; }

        public ICollection<Wire> Wires { get; set; }
    }
    public class Trade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int profile_id { get; set; }
        public Profile profile{ get; set; }
        public string? symbol{ get; set; } = string.Empty;
        public int quantity{ get; set; }
        public int open_price{ get; set; }
        public int close_price{ get; set; }

        [DataType(DataType.Date)]
        public DateTime open_datetime{ get; set; }

        [DataType(DataType.Date)]
        public DateTime close_datetime{ get; set; }
        public bool open { get; set; }
    }
    public class Wire
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public Profile profile { get; set; }
        public int amount { get; set; }
        public bool withdrawal { get; set; }
    }
}