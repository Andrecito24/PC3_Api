using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace API_pc.Models.DTO
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        [JsonPropertyName("first_name")]
        public string? Nombre { get; set; }

        [JsonPropertyName("last_name")]
        public string? Apellido { get; set; }
        public string? Avatar { get; set; }
    }
}