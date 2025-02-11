# TASK -6 : Understanding IEnumerable, Concrete Types, and IReadOnlyDictionary
## TASK- 6.1 : IEnumerable Collection
- In the task, **SumOfElements** is a method which can be used to sum up all of the elements in an `IEnumerable<int>` collection.

  ![image](https://github.com/user-attachments/assets/1854168b-1d98-41e3-8451-574f83b53f22)

- When other collection type of `<int>` such as `List<int>`, `Stack<int>`  or `int[]` is supplied to the method, then the sum of the integers in the collections are returned.
- Generally, the access of the data is based on the type of the collection such as `FIFO` approach in`queue`, `LIFO` approach in `stack` and `Index` approach in `arrays`.
- This shows that a method devised to take an IEnumerable as an input can also take collections containing the same `DataType` and perform the corresponding opertions.
- This opens up multiple new advantages such as **Reusability** and **Feature Enhancements** in the collection types.
## TASK- 6.2 : ReadOnly Collections
- The collection types present in C# can be used to store large amounts of data in a required format.
- The access of the data is based on the type of the collection such as `FIFO` approach in`queue`, `LIFO` approach in `stack` and `Index` approach in `arrays`.
- Collections can be modified externally though the collection specific methods which ensure their `flexibility` and enhancements.
- But if the data that is stored in the collections are of high security and it must not be allowed for further changes, then `ReadOnly collections` are used.
- In the task, **GenerateDictionary()** method is used to return an `IReadOnlyDictionary` with some added `(key, value)`pairs.
- When an additional `(key,value)` pair is tried to be added into the  IReadOnlyDictionary, then an error **IReadOnlyDictionary<string, int>.this[string]' cannot be assigned to -- it is read only** is thrown.

  ![readonly collection](https://github.com/user-attachments/assets/a354e995-f71d-45a1-90df-2db41a4029c0)

- This shows that any element is not allowed to be added or modified in a `ReadOnlyCollection`  which ensures that the data stored in the collection is maintained.
- The method **PrintDictionary()** is used to print the `IReadOnlyDictionary` as a Console Table. This shows that the ReadOnlyCollections can be read but cannot be modified.
- This approach can be used in configuration files or high security applications where the user is not allowed to edit the underlying data.
