namespace Task5.Model
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetRepository();

        public void AddToRepository(T item);
    }
}
