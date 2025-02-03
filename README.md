# ERROR HANDLING

## TASK-1
- A try/catch/finally block is created to handle any `DivideByZeroException` that might occur. 
- In the catch block, a meaningful error message is printed to the console. 
- In the finally block, a statement indicating that the block has been executed is printed.

  ![task1](https://github.com/user-attachments/assets/0afaf66a-c99b-4449-84fa-fe50fa4edf73)
## TASK-2
- In the catch block, a new exception is thrown with a custom message in case of any `IndexOutOfRangeException`.
- A second try/catch block is included to handle any exception thrown. 
- The new exception thrown from the first catch block is caught by the second catch block and its message is printed.

  ![task2](https://github.com/user-attachments/assets/4f248fd4-436c-4955-b0b9-418e31c33245)
## TASK-3
- A new custom exception class called `InvalidUserInputException` is defined.
- If the user enters an invalid input, an `InvalidUserInputException` is thrown out. 
- This exception is caught and its message. is printed to the console.

  ![TASK3](https://github.com/user-attachments/assets/7aaedc8c-7eb1-4ba9-ae95-bd5c4818453b)
## TASK-4
- A method is implemented that has unhandled exceptions. 
- The AppDomain's `UnhandledException` event is used to catch any unhandled exceptions globally.
- A custom message is printed when an unhandled exception is caught.

  ![task4](https://github.com/user-attachments/assets/6393cff4-9b48-4490-8b58-25b0dcce2ef0)
## TASK-5
- An exception is thrown in the program and it is caught globally. 
- The exception's stack trace is printed.

![task5](https://github.com/user-attachments/assets/025fc925-0765-4686-a24d-15cc732db49c)
### STACK TRACE
System.Exception: The given input 'Invalid' is in invalid Format and cannot be parsed into an integer.
   at GlobalExceptionHandler.ExecuteTask5(String userInput) in F:\C#_Assignments\ErrorHandling\Task5\GlobalExceptionHandler.cs:line 13
   at Program.Main() in F:\C#_Assignments\ErrorHandling\Task5\Program.cs:line 8
#### INTERPRETATION
- The stack trace indicates that an exception of type System.Exception has been thrown out.
- The exception origin is shown to be at the  `Line 13` of the `ExecuteTask5` method defined in the `GlobalExceptionHandler` Class.
- The exception occurs at the `Line 8` of the `Main` method defined in the `Program` Class which calls the `GlobalExceptionHandler` Class.
- The exception messsage shows that `Invalid` is a input in invalid format and the method is expecting a string input which can be parsed to a valid integer.
