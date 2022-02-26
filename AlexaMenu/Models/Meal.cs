using System;
using System.Collections.Generic;

namespace AlexaMenu.Models
{
    public class Meal
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Restaurant { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public List<Dish> Dishes { get; set; }
    }
}