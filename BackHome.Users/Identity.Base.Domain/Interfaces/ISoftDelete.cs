using Identity.Base.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.Interfaces
{
    public interface ISoftDelete
    {
        public void MarkAsDeleted(Guid id);
        public bool IsDeleted();
        public DeletedAuditionDto DeletedInfo { get; }
    }
}
