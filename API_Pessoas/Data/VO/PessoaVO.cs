using System.Collections.Generic;
using System.Text.Json.Serialization;
using API_Pessoas.HyperMedia;
using API_Pessoas.HyperMedia.Abstract;

namespace API_Pessoas.Data.VO
{
    public class PessoaVO : ISupportHypermedia
    {
        [JsonPropertyName("codigo")]
        public long Id { get; set; }
        
        [JsonPropertyName("nome")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [JsonPropertyName("sexo")]
        public string Gender { get; set; }
        
        public bool Enabled { get; set; }
        
        //[JsonIgnore]
        public string Addres { get; set; }
        

        public List<HypermediaLink> Links { get; set; } = new List<HypermediaLink>();
    }
}
