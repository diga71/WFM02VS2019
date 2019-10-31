using System;

namespace Domain
{
    public class Activity : IActivity
    {
        public int Id { get; set; }

        public String Description { get; set; }

        public double? Effort { get; set; }
    }
}
