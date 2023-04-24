using System;
namespace Coding_Test.Models
{
    public class User
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}