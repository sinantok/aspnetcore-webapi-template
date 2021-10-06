using Data.Mongo.Attributes;
using Data.Mongo.Collections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Mongo.Repo
{
    public class MongoRepository<T> : IMongoRepository<T> where T : MongoBaseDocument
    {

        protected IMongoCollection<T> Collection { get; }

        public MongoRepository(IMongoDatabase database)
        {
            string collectionName;

            var att = Attribute.GetCustomAttribute(typeof(T), typeof(BsonCollectionAttribute));

            if (att != null)
            {
                collectionName = ((BsonCollectionAttribute)att).CollectionName;
            }
            else
            {
                collectionName = typeof(T).Name;
            }

            //var collectionName = typeof(TEntity).GetCustomAttribute<BsonCollectionAttribute>(false).CollectionName;
            Collection = database.GetCollection<T>(collectionName);

        }

        public async Task AddAsync(T entity)
            => await Collection.InsertOneAsync(entity);

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> FindDistinctAsync(string field, FilterDefinition<T> filter)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
