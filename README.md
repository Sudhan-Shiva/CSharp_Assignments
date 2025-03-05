# Asynchronous Programming
 
## Task 1 - Understanding and Implementing Async/Await
* Created an async method to download content from a URL using HttpClient class. 
* The method downloads the content asynchronously and returns the downloaded content.
* In the Main method, called the async method using the await keyword for the content to be returned and printed to the console.
 
## Task 2 - Implementing and Understanding Task Parallel Library
* Implemented a method to compare the performance of parallel and sequential execution of computing the square of an array numbers. 
 
## Task 3 - Advanced Understanding and Usage of Multi-Threading
* Implemented separate methods to calculate the factorial and calculate the sum of the cubes of elements.
* Created new threads to execute each of the methods and used the Join method to wait for all threads to complete their execution. 
* Printed the results obtained from the methods to ensure that the result is as expected.
 
## Task 4 - Implementing Multi-Layered Async/Await Operations in a Real-World Scenario
* Implemented MethodA that calculates the sum of squares of elements and returns the result.
* Implemented MethodB that calls MethodsA and then downloads content from a URL by modifying the result from MethodA and returns the content.  
* Implemented MethodC that searches for the number of key-value pairs in the content returned by MethodB.
* MethodA is called using Task.Run(), MethodB and MethodC are declared asynchronous and MethodC is called in the Main method.

  ![image](https://github.com/user-attachments/assets/12bae43e-2087-4798-a6da-2e1e987d2f96)
## Task 5 - Debugging and Fixing Deadlock Conditions
* In the initial code given, the use of .Result on the async method blocks the code to wait synchronously for the result.
* Modified the code to use the await keyword to execute the method asynchronously and set ConfigureAwait to false in the asynchronous method to make it continue its execution on a different thread instead of waiting.
 
## Task 6 - Real-World Application of ConfigureAwait in a Console Application with Thread Tracking
* Implemented an async method MethodA to simulate a delay and calculate the sum of squares of elements.
* Implemented an async method MethodB to simulate a delay, call MethodA and further calculate the sum of squares of elements.
* Used ConfigureAwait(false) in MethodA to ensure that the consequent methods do not have to wait for the original context. 
* Analyzed the change in the thread ID using Thread.CurrentThread.ManagedThreadId which shows that the MethodB can be run on a different thread without waiting for the thread executing MethodA.

  ![image](https://github.com/user-attachments/assets/59050afc-09da-49fd-a551-ce3a7397be12)
 
## Task 7 - Understanding the Difference between Async Void and Async Task with Exceptions.
* Implemented two async methods with one throwing an exception and returning void and the other throwing an exception and returning Task.
* When executed, the exception thrown by the method with void return type could not be caught, whereas the exception caused the method returning Task could be caught and handled.

  ![image](https://github.com/user-attachments/assets/7e0ef8e0-5643-48b3-af93-54489dfeddd0)
