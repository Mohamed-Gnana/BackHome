using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.ValueObjects
{
    public class ModifiedAuditionDto
    {
        public Guid? LastModifiedBy { get; private set; }
        public DateTime? LastModifiedDate { get; private set; }

        public ModifiedAuditionDto()
        {
            LastModifiedBy = null;
            LastModifiedDate = null;
        }

        public ModifiedAuditionDto Execute(Guid id)
        {
            LastModifiedDate = DateTime.UtcNow;
            LastModifiedBy = id;
            return this;
        }
    }
}
