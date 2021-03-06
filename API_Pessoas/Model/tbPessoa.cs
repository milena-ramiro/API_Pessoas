﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using API_Pessoas.Model.Base;

namespace API_Pessoas.Model
{
    [Table("tbpessoa")]
    public class tbPessoa : BaseEntity
    {
        [Column("first_name")]
        public string FirstName { get; set; }

        [Column("last_name")]
        public string LastName { get; set; }

        [Column("gender")]
        public string Gender { get; set; }
        
        [Column("enabled")]
        public bool Enabled { get; set; }

        [Column("addres")]
        public string Addres { get; set; }
    }
}
