using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;

namespace RepositoryPattern.Core.EntityFramework
{
    public abstract class EntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : class, new()
    {
        private readonly IDbContext _context;
        private IDbSet<TEntity> _entities;
        protected IDbSet<TEntity> Entities => _entities ?? (_entities = _context.Set<TEntity>());

        protected EntityRepository(IDbContext entityContext)
        {
            if (entityContext == null) throw new ArgumentNullException(nameof(entityContext));

            _context = entityContext;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Entities;
        }

        public void Create(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            Entities.Add(entity);
            SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null) { throw new ArgumentNullException(nameof(entity)); }

            SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Entities.Remove(entity);
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string validationErrorMessages = CreateValidationErrorMessages(dbEx);
                throw new Exception(validationErrorMessages, dbEx);
            }
        }

        private string CreateValidationErrorMessages(DbEntityValidationException dbEx)
        {
            IEnumerable<DbValidationError> validationErrors = dbEx.EntityValidationErrors.SelectMany(ve => ve.ValidationErrors);

            var stringBuilder = new StringBuilder();

            foreach (var validationError in validationErrors)
            {
                stringBuilder.Append(FormatValidationErrorMessage(validationError));
            }
            return stringBuilder.ToString();
        }

        private string FormatValidationErrorMessage(DbValidationError validationError)
        {
            return $"Property Name: {validationError.PropertyName} Error Message: {validationError.ErrorMessage}" + Environment.NewLine;
        }
    }
}