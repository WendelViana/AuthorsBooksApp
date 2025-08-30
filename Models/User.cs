using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthorsBooksApp.Models
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("email")]
        [EmailAddress(ErrorMessage = "invalid e-mail address")]
        public string Email { get; set; }

        [JsonProperty("passwordHash")]
        public string PasswordHash { get; set; }
    }
}