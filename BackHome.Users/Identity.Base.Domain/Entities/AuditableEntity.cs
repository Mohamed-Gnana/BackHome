using Identity.Base.Domain.Interfaces;
using Identity.Base.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.Entities
{
    public class AuditableEntity : BaseEntity, ICreatedAudition, IModifiedAudition
    {
        #region Private Members
        private CreatedAuditionDto _createdAudition;
        private ModifiedAuditionDto _modifiedAudtion;
        #endregion

        #region Constructors
        public AuditableEntity()
        {
            _createdAudition = new();
            _modifiedAudtion = new();
        }

        #endregion

        #region Public Properties
        public ModifiedAuditionDto ModificationInfo
        {
            get => _modifiedAudtion;
            private set => _modifiedAudtion = value;
        }

        public CreatedAuditionDto CreationInfo
        {
            get => _createdAudition;
            private set => _createdAudition = value;
        }
        #endregion
        public void MarkCreation(Guid id)
        {
            _createdAudition.Execute(id);
        }

        public void MarkModification(Guid id)
        {
            _modifiedAudtion.Execute(id);
        }
    }
}
