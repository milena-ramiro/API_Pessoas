using System.Text.Json.Serialization;

namespace API_Pessoas.Data.VO
{
    public class PessoaVO 
    {
        [JsonPropertyName("codigo")]
        public long Id { get; set; }
        
        [JsonPropertyName("nome")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [JsonPropertyName("sexo")]
        public string Gender { get; set; }
        
        [JsonIgnore]
        public string Addres { get; set; }
    }
}
