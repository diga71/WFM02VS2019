using System;
using System.Collections.Generic;

namespace Domain
{
    public class Mission : IMission
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public IOperator Operator { get; set; }
        public IActivity Activity { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
