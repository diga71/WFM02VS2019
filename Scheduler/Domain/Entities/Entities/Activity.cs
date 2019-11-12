using System;

namespace Domain
{
    public class Activity : IActivity
    {
        public long Id { get; set; }

        public String Description { get; set; }

        public double? Effort { get; set; }
    }
}
