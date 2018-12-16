﻿using System;
using System.Collections.Generic;
using System.Text;
using CoMiSzkodzi.Enums;
using SQLite;

namespace CoMiSzkodzi.Databases
{
    [Table("Food")]
    public class Food
    {
        [PrimaryKey,AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public Categories categories { get; set;} 
        public BlackListed blacklisted { get; set; }
    }
}
