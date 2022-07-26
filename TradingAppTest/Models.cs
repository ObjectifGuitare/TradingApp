using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace TradingAppTest
{



  /*  public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }*/
    
    
    public class User
    {
        public int id { get; set; }
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
    }
    public class Profile
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string? first_name { get; set; } = string.Empty;
        public string? last_name { get; set; } = string.Empty;
        public string? address { get; set; } = string.Empty;
    }
    public class Trade
    {
        public int id { get; set; }
        public int profile_id{ get; set; }
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
        public int id { get; set; }
        public int profile_id { get; set; }
        public int amount { get; set; }
        public bool withdrawal { get; set; }
    }
}