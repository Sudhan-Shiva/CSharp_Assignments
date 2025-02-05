namespace Task5.Utility
{
    public class QueryBuilder<T>
    {
        private IEnumerable<T> _tRepository;

        public QueryBuilder(IEnumerable<T> TRepository)
        {
            _tRepository = TRepository;
        }
        public QueryBuilder<T> Filter(Func<T, bool> predicate)
        {
            QueryBuilder<T> query = new QueryBuilder<T>(_tRepository.Where(predicate));
            return query;
        }

        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> predicate)
        {
            QueryBuilder<T> query = new QueryBuilder<T>(_tRepository.OrderBy(predicate));
            return query;
        }

        public IEnumerable<T> Execute()
        {
            return _tRepository;
        }
    }
}