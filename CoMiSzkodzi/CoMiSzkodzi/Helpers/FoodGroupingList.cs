using CoMiSzkodzi.Databases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CoMiSzkodzi.Helpers
{
    public class FoodGroupingList : List<Food>
    {
        public FoodGroupingList(string heading) : base()
        {
            Heading = heading;
        }
        public FoodGroupingList(string heading, List<Food> foods) : base(foods)
        {
            Heading = heading;
            Foods = foods;
        }
        public string Heading { get; set; }
        public List<Food> Foods { get; set; }
    }
}
