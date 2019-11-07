namespace Domain
{
    public class Operator : IOperator
    {
        public long Id { get; set; }
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string EMail { get; set; }

        public string GetSummary()
        {
            return $@"{Id}: {LastName} {FirstName} - {EMail}";
        }
    }
}
