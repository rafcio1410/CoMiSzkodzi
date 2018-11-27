﻿using System;
using System.Collections.Generic;
using System.Text;
using CoMiSzkodzi.Enums;
using SQLite;

namespace CoMiSzkodzi.Databases
{
    public class Food
    {
        [PrimaryKey]
        public int id { get; set; }
        public string name { get; set; }
        public Categories categories { get; set;} 
        public bool blacklisted { get; set; }
    }
}