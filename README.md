# C# Advanced Concepts: Events, Delegates, Lambda, Anonymous Methods 
## Task 1: Understanding and Implementing Events and Delegates in C# 

- Created a simple console application that uses events and delegates to notify the user when an action is performed.  
- Defined a delegate, **Notify** in a class **Notifier** that accepts a string message and returns void. 
- Defined an event, **OnAction** in the same class using the Notify delegate. 
- In the **Main** method of the console application, an instance of `Notifier` is created. 
- The `OnAction event` is subscribed with a method that writes the message to the console. 
- The OnAction event is triggered with a `string message` and observe the console output. 
- When the console application runs, the string message is printed in the console. 

## Task 2: Understanding the Use of Dynamic and Var Keywords and Their Differences 

- A console application is created to demonstrate the differences between `var` and `dynamic`. 
- **var** is used to declare a variable and assign it a value. Any attempt to change the variable's type after declaration results in `error`. 
- **dynamic** is used to declare a variable and assign it a value. Any attempt to change the variable's type after declaration results in the `change of the variable type`. 

## Task 3: Implementing Anonymous Methods 

- A console application is created that uses an `anonymous method` to sort an array of integers in ascending order. 
- An array of integers is declared. 
- The `Array.Sort` is used and an anonymous method is provided for comparison. 
- The sorted array is printed to the console. 
- The console displays the array of integers sorted in ascending order. 

## Task 4: Understanding and Using Lambda Expressions and Statements 

- A console application is created that uses **lambda** expressions and statements to filter and modify a collection of data. 
- A list of integers is declared. 
- A lambda expression is used with the `Where` LINQ method to filter out even numbers. 
- A lambda statement is used with the `Select` LINQ method to square the filtered numbers. 
- The resulting collection is printed to the console. 
- The console displays the `square of odd numbers` from the list. 

## Task 5: Advanced Use of Delegates for Sorting (Advanced) 

- A console application is created to demonstrate the use of delegates for complex sorting operations. 
- A Product class is created with properties Name, Category, and Price. 
- A list of Product objects is created. 
- A delegate `SortDelegate` is created that takes in two Product objects and returns an integer. 
- Three methods `SortByName`, `SortByCategory`, and `SortByPrice` are created that take two Product objects and return an integer based on the comparison of the relevant properties.
- Instances of `SortDelegate` is created for each of the sorting methods in the main method. 
- A method `SortAndDisplay` is created that takes a SortDelegate and a list of Product objects. 
- This method sorts the list using the provided delegate and then prints the sorted list to the console. 

## Task 6: Implementing and Manipulating Records in C# 9.0 and Above (Advanced) 

- A **record** `Book` is defined with properties Title, Author, and ISBN. 
- A few Book records is declared and their details are displayed in the console. 
- The value `equality` of records is demonstrated by creating two Book records with the same property values.
- The `immutability` of records is shown by trying to change a property of a Book record after its declaration.
- The **with** keyword is used to create a new Book record based on an existing one but with one or more properties changed. Print both records to show that the original has not been modified. 
- A method `DisplayBook` is implemented that takes a Book record and uses deconstruction to print its properties. 

## Task 7: Implementing Advanced Pattern Matching in C# 7.0 and Above  

- A base class **Shape** is defined with properties common to all shapes. 
- Subclasses like **Circle**, **Rectangle**, and **Triangle** are defined each with properties specific to that shape. 
- A method `CalculateArea` is defined in each subclass to calculate and return the `area` of the shape. 
- A list of Shape objects is declared in the main method. 
- A method `DisplayShapeDetails` is implemented that takes a Shape object and uses `type patterns` in a switch statement to match the shape's type.
- DisplayShapeDetails is called on each shape in your list.

 
