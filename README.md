# Understanding and Practicing Collections and Generics in C# 

## Task 1: Working with Lists 
A program is implemented that uses a List to store a collection of book titles. 
- **1.1** A `List` of strings is created, each representing a book title.
- **1.2** Five book titles are added to the list using the `Add` method.
- **1.3** A book is removed from the list using the `Remove` method.
- **1.4** `Contains` method is used to check if a particular book is in the list.
- **1.5** All the books in the list are displayed.

## Task 2: Using Stacks 
A program is implemented that uses a Stack to reverse a string. 
- **2.1** A `Stack` of characters is created.
- **2.2** Each character of a given string is `pushed` onto the stack.
- **2.3** Each character is `popped` off the stack and append it to a new string.
- **2.4** The original and reversed string are displayed.

## Task 3: Working with Queues
A program is implemented hat simulates a queue of people waiting in line. 
- **3.1** A `Queue` of strings is created, each representing a person's name.
- **3.2** Five people are added to the queue using the `Enqueue` method.
- **3.3** A person is removed from the queue using the `Dequeue` method.
- **3.4** All the people in the queue are displayed.
  
## Task 4: Understanding Dictionaries
A program is implemented that maps a student's name to their grade. 
- **4.1** A `Dictionary` is created with the key as a string (student's name) and the value as an integer (grade).
- **4.2** Five students and their grades are added to the dictionary.
- **4.3** A student is removed from the dictionary.
- **4.4** All the students and their grades are displayed.
  
## Task 5: Applying Generic Collections
The previous tasks are converted to use `generic` collections. This enhances type safety and allow for code `reusability`. 
- **5.1** Update the book list to use `List<T>`.
- **5.2** Update the string reversal stack to use `Stack<T>`.
- **5.3** Update the queue of people to use `Queue<T>`.
- **5.4** Update the student grade dictionary to use `Dictionary<TKey, TValue>`.

## Task 6: Understanding IEnumerable, Concrete Types, and IReadOnlyDictionary
### 6.1 Implement a function named SumOfElements
- **6.1.1** The function `SumOfElements` is created which accepts `IEnumerable<int>` as a parameter.
- **6.1.2** This function computes and returns the `sum of all integers` in the collection.
- **6.1.3** This function is tested with different concrete collection types like `List, Array, and Queue` containing integers.

### 6.2 Understanding the ReadOnlyCollection
- **6.2.1** A function named `GenerateDictionary` is implemented that creates a Dictionary object and returns it as an `IReadOnlyDictionary<string, int>`.
- **6.2.2** This function adds a few key-value pairs to the dictionary before returning it.
- **6.2.3** A function named `PrintDictionary` is implemented that accepts `IReadOnlyDictionary<string, int>` as a parameter.
- **6.2.4** This function prints all the key-value pairs in the dictionary.
- **6.2.5** This function is tested by passing the return value of `GenerateDictionary` as input.
- **6.2.6** A function is implemented that attempts to modify the output of `GenerateDictionary`.
