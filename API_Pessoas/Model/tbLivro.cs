using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Pessoas.Model
{
    [Table("tblivros")]
    public class tbLivro
    {
        [Column("id")]
        public int id { get; set; }

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