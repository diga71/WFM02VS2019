using System;
using System.Collections.Generic;

namespace Domain
{
    public class Mission : IMission
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public IOperator WFOperator { get; set; }
        public long? IdOpe { get; set; }
        public IActivity Activity { get; set; }
        public long? IdAct { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
