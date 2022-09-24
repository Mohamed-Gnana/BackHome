using Identity.Base.Domain.Entities;
using Identity.Base.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Identity.Base.Domain.Tests.Entities
{
    public class AuditableEntityShould : BaseEntityShould, IDisposable
    {
        private AuditableEntity _auditableEntity;

        public AuditableEntityShould(AuditableEntity? entity = null): base(new AuditableEntity())
        {
            #region Arrange
            _auditableEntity = entity ?? new AuditableEntity();
            #endregion
        }

        [Fact]
        public override void BeCreated()
        {
            Assert.NotNull(_auditableEntity);
        }

        [Fact]
        public void ImplementBaseEntity()
        {
            Assert.IsAssignableFrom<BaseEntity>(_auditableEntity);
        }

        [Fact]
        public void ImplementICreatedAudition()
        {
            Assert.IsAssignableFrom<ICreatedAudition>(_auditableEntity);
        }

        [Fact]
        public void ImplementIModifiedAudition()
        {
            Assert.IsAssignableFrom<IModifiedAudition>(_auditableEntity);
        }

        [Fact]
        public void BeInitializedWithNewCreatedAudition()
        {
            #region Actual
            var createdAudition = _auditableEntity.CreationInfo;
            #endregion

            Assert.NotNull(createdAudition);
        }

        [Fact]
        public void BeInitializedWithNewModifiedAudition()
        {
            #region Actual
            var modificationInfo = _auditableEntity.ModificationInfo;
            #endregion

            Assert.NotNull(modificationInfo);
        }

        [Fact]
        public void BeInitializedWithNullValuesInCreationAudition()
        {
            #region Actual
            var creationAudition = _auditableEntity.CreationInfo;
            #endregion

            Assert.Null(creationAudition.CreatedBy);
            Assert.Null(creationAudition.CreatedDate);
        }

        [Fact]
        public void BeInitializedWithNullValuesInModificationAudition()
        {
            #region Actual
            var modificationAudition = _auditableEntity.ModificationInfo;
            #endregion

            Assert.Null(modificationAudition.LastModifiedBy);
            Assert.Null(modificationAudition.LastModifiedDate);
        }

        [Fact]
        public void NotBeEmptyAfterMarkAsCreated()
        {
            #region Arrange
            _auditableEntity.MarkCreation(Guid.Empty);
            var creationAudition = _auditableEntity.CreationInfo;
            #endregion

            Assert.NotNull(creationAudition.CreatedBy);
            Assert.NotNull(creationAudition.CreatedDate);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenMarkCreatedIsCalledForSecondTime()
        {
            #region Arrange
            _auditableEntity.MarkCreation(Guid.Empty);
            #endregion

            Assert.Throws<InvalidOperationException>(() => _auditableEntity.MarkCreation(Guid.Empty));
        }

        [Fact]
        public void NotBeEmptyAfterMarkModification()
        {
            #region Arrange
            _auditableEntity.MarkModification(Guid.Empty);
            var modificationAudition = _auditableEntity.ModificationInfo;
            #endregion

            Assert.NotNull(modificationAudition.LastModifiedBy);
            Assert.NotNull(modificationAudition.LastModifiedDate);
        }

        [Fact]
        public void HaveMarkModificationCalledAgaionWithNoProblem()
        {
            #region Arrange
            string value = "00000000-0000-0000-0000-000000000001";
            _auditableEntity.MarkModification(Guid.Empty);
            _auditableEntity.MarkModification(Guid.Parse(value));
            #endregion

            Assert.Equal(_auditableEntity.ModificationInfo.LastModifiedBy, Guid.Parse(value));
        }
    }
}
