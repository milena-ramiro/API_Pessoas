using System;
using System.ComponentModel.DataAnnotations.Schema;
using API_Pessoas.Model.Base;

namespace API_Pessoas.Model
{
    [Table("tblivros")]
    public class tbLivro : BaseEntity
    {
        [Column("author")]
        public string Author { get; set; }

        [Column("launch_date")]
        public DateTime Launch_Date { get; set; }

        [Column("price")]
        public decimal Price { get; set; }

        [Column("title")]
        public string Title { get; set; }
    }
}