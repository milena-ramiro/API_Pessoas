using System.ComponentModel.DataAnnotations.Schema;

namespace API_Pessoas.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long id { get; set; }
    }
}