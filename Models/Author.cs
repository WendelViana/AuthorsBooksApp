using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AuthorsBooksApp.Models
{
    public class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Firs Name is required")]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        //At Postman is "eamil". I mapped it to the correct field name "Email".
        [JsonProperty("eamil")]
        [EmailAddress(ErrorMessage = "invalid e-mail address")]
        public string Email { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("address1")]
        public string Address1 { get; set; }

        [JsonProperty("address2")]
        public string Address2 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public string Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }
    }
}