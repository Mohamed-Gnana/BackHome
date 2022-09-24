using Identity.Base.Domain.Interfaces;
using Identity.Base.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Base.Domain.Entities
{
    public class BaseEntity: ISoftDelete
    {
        #region Private Fields
        private Guid _id;
        private DeletedAuditionDto _deletedInfo;
        #endregion

        #region Constructors
        public BaseEntity()
        {
            _deletedInfo = new DeletedAuditionDto();
        }

        #endregion

        #region Public Properties
        public Guid Id
        {
            get => _id;
            private set => _id = value;
        }

        public DeletedAuditionDto DeletedInfo
        {
            get => _deletedInfo;
            private set => _deletedInfo = value;
        }

        #endregion

        #region Public Setters

        public bool IsDeleted()
        {
            return _deletedInfo.IsDeleted;
        }

        public void MarkAsDeleted(Guid id)
        {
            DeletedInfo.Excute(id);
        }

        #endregion

    }
}
