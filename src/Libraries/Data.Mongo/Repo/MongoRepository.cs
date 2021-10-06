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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
            => await Collection.DeleteOneAsync(e => e.Id == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
            => await Collection.Find(predicate).AnyAsync();

        /// <summary>
        /// Not Async
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
            => Collection.Find(predicate).ToList();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
            => await Collection.Find(predicate).ToListAsync();

        public async Task<ICollection<T>> FindDistinctAsync(string field, FilterDefinition<T> filter)
            => (ICollection<T>)await Collection.DistinctAsync<T>(field, filter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(string id)
            => await GetAsync(e => e.Id == id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
            => await Collection.Find(predicate).SingleOrDefaultAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(T entity)
            => await Collection.ReplaceOneAsync(e => e.Id == entity.Id, entity);
    }
}
