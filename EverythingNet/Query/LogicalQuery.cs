namespace EverythingNet.Query
{
    using EverythingNet.Interfaces;
    using System.Collections.Generic;

    internal class LogicalQuery : Query
    {
        private readonly string logicalOperator;

        public LogicalQuery(IEverythingInternal everything, IQueryGenerator parent, string logicalOperator)
          : base(everything, parent)
        {
            this.logicalOperator = logicalOperator;
        }

        public override IEnumerable<string> GetQueryParts()
        {
            List<string> query = new List<string>();

            query.AddRange(base.GetQueryParts());
            query.Add(this.logicalOperator);

            return query;
        }
    }
}