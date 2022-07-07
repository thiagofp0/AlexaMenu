using System;
using System.Collections.Generic;

namespace AlexaMenu.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Restaurant { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<Dish> Dishes { get; set; }

        public Meal()
        {
            this.Dishes = new List<Dish>(new Dish[0]);
        }
    }
}