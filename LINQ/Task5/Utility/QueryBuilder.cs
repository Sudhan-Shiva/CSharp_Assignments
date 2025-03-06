namespace Task5.Utility
{
    /// <summary>
    /// A class that provides query building capabilities.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collection.</typeparam>
    public class QueryBuilder<T>
    {
        /// <summary>
        /// The collection of items which is to be handled.
        /// </summary>
        private IEnumerable<T> _tRepository;

        public QueryBuilder(IEnumerable<T> TRepository)
        {
            _tRepository = TRepository;
        }

        /// <summary>
        /// Filters the collection based on the specified predicate.
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition.</param>
        /// <returns>A new instance with the filtered collection.</returns>
        public QueryBuilder<T> Filter(Func<T, bool> predicate)
        {
            QueryBuilder<T> query = new QueryBuilder<T>(_tRepository.Where(predicate));
            return query;
        }

        /// <summary>
        /// Sorts the collection based on the specified key.
        /// </summary>
        /// <typeparam name="TKey">The type of the key returned by the key selector.</typeparam>
        /// <param name="predicate">A function to extract a key from an element.</param>
        /// <returns>A new instance with the sorted collection.</returns>
        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> predicate)
        {
            QueryBuilder<T> query = new QueryBuilder<T>(_tRepository.OrderBy(predicate));
            return query;
        }

        /// <summary>
        /// Joins the collection with another collection based on matching keys.
        /// </summary>
        /// <typeparam name="T2">The type of the elements of the second collection.</typeparam>
        /// <typeparam name="TKey">The type of the key returned by the key selectors.</typeparam>
        /// <param name="secondCollection">The other collection to join with.</param>
        /// <param name="firstCollectionKey">A function to extract the key from an element of the first collection.</param>
        /// <param name="secondCollectionKey">A function to extract the key from an element of the second collection.</param>
        /// <param name="result">A function to create a result element from two matching elements.</param>
        /// <returns>A new instance with the joined collection.</returns>
        public QueryBuilder<T> Join<T2, TKey>(IEnumerable<T2> secondCollection,
                                              Func<T, TKey> firstCollectionKey,
                                              Func<T2, TKey> secondCollectionKey,
                                              Func<T, T2, T> result)
        {
            QueryBuilder<T> query = new QueryBuilder<T>(_tRepository.Join(secondCollection, firstCollectionKey, secondCollectionKey, result));
            return query;
        }

        /// <summary>
        /// Executes the query and returns the resulting collection.
        /// </summary>
        /// <returns>The resulting collection after applying the query.</returns>
        public IEnumerable<T> Execute()
        {
            return _tRepository;
        }
    }
}
