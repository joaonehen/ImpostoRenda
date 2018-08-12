using System;

namespace IR.Domain.Entity
{
    public class EntidadeBase
    {
        public Guid Id { get; protected set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
