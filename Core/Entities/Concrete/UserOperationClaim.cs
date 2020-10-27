using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity<int>, IEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

    }
}
