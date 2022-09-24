using Identity.Base.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.Interfaces
{
    public interface ICreatedAudition
    {
        public void MarkCreation(Guid id);
        public CreatedAuditionDto CreationInfo { get; }
    }
}
