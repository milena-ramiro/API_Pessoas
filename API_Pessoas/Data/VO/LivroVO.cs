using System;
using System.ComponentModel.DataAnnotations.Schema;
using API_Pessoas.Model.Base;

namespace API_Pessoas.Data.VO
{
    public class LivroVO
    {
        public long Id { get; set; }
        public string Author { get; set; }

        public DateTime Launch_Date { get; set; }

        public decimal Price { get; set; }

        public string Title { get; set; }
    }
}