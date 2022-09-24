using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.ValueObjects
{
    public class DeletedAuditionDto
    {
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public Guid? DeletedBy { get; private set; }

        public DeletedAuditionDto()
        {
            IsDeleted = false;
            DeletedDate = null;
            DeletedBy = null;
        }

        #region Public Setters
        public DeletedAuditionDto Excute(Guid id)
        {
            if (IsDeleted) throw new InvalidOperationException("Entity is already deleted.");
            IsDeleted = true;
            DeletedDate = DateTime.UtcNow;
            DeletedBy = id;
            return this;
        }
        #endregion
    }
}
