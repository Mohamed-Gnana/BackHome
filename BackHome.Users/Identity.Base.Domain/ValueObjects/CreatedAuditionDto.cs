using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.ValueObjects
{
    public class CreatedAuditionDto
    {
        public Guid? CreatedBy { get; private set; }
        public DateTime? CreatedDate { get; private set; }

        public CreatedAuditionDto()
        {
            CreatedDate = null;
            CreatedBy = null;
        }

        public CreatedAuditionDto Execute(Guid id)
        {
            if (CreatedBy is not null) throw new InvalidOperationException("Entity is already created.");
            CreatedBy = id;
            CreatedDate = DateTime.UtcNow;
            return this;
        }
    }
}
