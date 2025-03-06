namespace Task2.Model
{
    /// <summary>
    /// Represents the Repository which contains the collection
    /// </summary>
    /// <typeparam name="T">The generic type present in the repository</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Returns the collection of the items in the repository
        /// </summary>
        /// <returns>The collection of the items in the repository</returns>
        public IEnumerable<T> GetRepository();

        /// <summary>
        /// Adds an item to the repository
        /// </summary>
        /// <param name="item">The item that is to be added to the collections</param>
        public void AddToRepository(T item);
    }
}
