using Identity.Base.Domain.Entities;
using Identity.Base.Domain.Interfaces;
using Identity.Base.Domain.ValueObjects;
using System;
using Xunit;

namespace Identity.Base.Domain.Tests.Entities
{
    public class BaseEntityShould: IDisposable
    {
        private BaseEntity _entity;
        public BaseEntityShould(BaseEntity? entity = null)
        {
            #region Arrange
            _entity = entity ?? new BaseEntity(); 
            #endregion
        }

        public void Dispose()
        {
            // Clear
        }

        [Fact]
        public virtual void BeCreated()
        {
            #region Arrange
            #endregion
        }
        
        [Fact]
        public void BeNotNullAfterCreation()
        {

            #region Assert
            Assert.NotNull(_entity);
            #endregion
        }

        [Fact]
        public void ReturnId()
        {
            #region Act
            // compile time error
            var id = _entity.Id;
            #endregion
        }

        [Fact]
        public void ReturnEmptyIdAfterCreation()
        {
            #region Act
            var id = _entity.Id;
            #endregion

            #region Assert
            var expected = Guid.Empty;
            Assert.Equal(expected, id);
            #endregion
        }

        [Fact]
        public void ImplementISoftDeleteInterface()
        {
            #region Assert
            var type = Assert.IsAssignableFrom<ISoftDelete>(_entity);
            Assert.NotNull(type);
            #endregion
        }

        [Fact]
        public void BeInitializedWithDeletedInfo()
        {
            #region Act
            var deletedInfo = _entity.DeletedInfo;
            #endregion

            #region Assert
            var expectedType = (new DeletedAuditionDto()).GetType();
            Assert.NotNull(deletedInfo);
            Assert.IsType(expectedType, deletedInfo);
            #endregion
        }

        [Fact]
        public void BeInitializeWithIsDeletedAsFalse()
        {
            #region Actual
            var deletedInfo = _entity.DeletedInfo?.IsDeleted;
            #endregion

            #region Assert
            Assert.NotNull(deletedInfo);
            Assert.False(deletedInfo!.Value);
            #endregion
        }

        [Fact]
        public void DeleteItemAfterCallingMarkAsDeleted()
        {
            #region Actual
            _entity.MarkAsDeleted(Guid.Empty);
            var deletedInfo = _entity.DeletedInfo;
            #endregion

            Assert.True(deletedInfo.IsDeleted);
            Assert.NotNull(deletedInfo.DeletedDate);
            Assert.NotNull(deletedInfo.DeletedBy);
        }

        [Fact]
        public void ThrowInvalidOperationExceptionWhenDeletingForSecondTime()
        {
            #region Arrange
            _entity.MarkAsDeleted(Guid.Empty);
            #endregion

            #region Assert
            Assert.Throws<InvalidOperationException>(() => _entity.MarkAsDeleted(Guid.Empty));
            #endregion
        }

        [Fact]
        public void ReturnFalseAfterCreation()
        {
            Assert.False(_entity.IsDeleted());
        }

        [Fact]
        public void HaveIsDeletedReturnTrueAfterCallingMarkAsDeleted()
        {
            #region Actual
            _entity.MarkAsDeleted(Guid.Empty);
            #endregion

            Assert.True(_entity.IsDeleted());
        }

    }
}
