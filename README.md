# MEMORY MANAGEMENT
## TASK-1 
- A Console Application named `ValueAndReferenceTypes` is created.
- In the Main method, a value type (an integer) and a reference type (Custom class - `Product`) are defined. 
- A method is created to take both types as parameters and modify them. 
- This method is invoked in the main method, and the values of both types are printed afterwards to observe the difference in behaviour.

### OBSERVATION
- The value type remains `unchanged` after the method call, whereas the reference type reflects the changes made within the method.

  ![image](https://github.com/user-attachments/assets/4d820d94-27f9-4d56-838f-7d6a5b8e042c)

  ![task1mem](https://github.com/user-attachments/assets/21c38826-7c40-45a0-85b9-40fb63df5a47)
### INSIGHTS
- The reference type variable holds the address `(in the stack)` of the object which stores the value in the `heap`. So if the reference type variable is passed into the method, the address of the object in the heap is shared and so the address is directly modified by the method. Therefore the changes are reflected in the reference type variable.
- The value type variable holds the value and is stored in the stack. Therefore when the method is invoked a copy of the local variable is shared as a new variable which is then modified and so the changes are not reflected in the original local variable.

## TASK-2 
- Two methods are created, one which creates a large array of integers (a reference type), and another that performs a calculation with a large number of local variables (value types). 
- The `Visual Studio's Diagnostic Tools` is used to observe how memory is used when these methods are called.
### OBSERVATION
- The method with the large array uses more heap memory, whereas the method with the many local variables does not consume the heap memory.

  ![task2console](https://github.com/user-attachments/assets/3512ba1d-d8d5-40d1-9ed2-af332fbf1be7)

  ![task2 memory](https://github.com/user-attachments/assets/0aeebf3c-3090-41ef-8308-b0f4b2885fe0)
### INSIGHTS
- The method that creates the large array creates a reference type variable of large size and so it is stored in the heap memory.
- The creation of the large array clearly consumes memory from the heap memory which is shown in the process memory graph timeline.
- The method that creates local variables does not consume much heap memory since the local variables are created in the stack memory.

## TASK-3
- A Console Application named `GarbageCollection` is created.
- A method that creates and destroys a large number of objects in a for loop with large count is created.
- The memory usage of the application is observed using  `Visual Studio's Diagnostic Tools`. 
- `GC.Collect()` is used to manually trigger garbage collection and the impact on memory usage is observed.

### OBSERVATION
- A drop in memory usage is observed after `garbage collection` occurs. The performance impact is noted when garbage collection is triggered.

  ![tablememroy](https://github.com/user-attachments/assets/731bff13-b866-4c7e-b75e-52ed18812949)

  ![gc_main](https://github.com/user-attachments/assets/771b9ec8-04be-4a54-a397-ba576ef66ebb)
### OBSERVATION
- When the method creates the large array of objects, the consumption of the heap memory size is drastic.
- When the method destroys the array, the memory is freed which can be analyzed from the `process memory graph timeline` and the analysis table of heap memory.
- When the `GC.Collect()` method is called, it is reflected by a indication in the graph and there is change in the heap memory.

## TASK-4
- A Console Application named `IDisposableDemo` is created.
- A class that opens a file for writing is created and it implements the `IDisposable` interface. The Dispose method is implemented and it is ensured that the file is properly closed and released. 
- In the main method, an instance of this class is created in a 'using' block and some text is written in the file.
- After the `using` block, the same file is opened for reading.
- Since the file was properly released using the Dispose method, the program is executed without any errors.
### OBSERVATION
- The application is able to open the file for reading after the   using   block, demonstrating that the file was properly released when the `IDisposable` object was disposed.

  ![image](https://github.com/user-attachments/assets/402df770-b687-4350-81bc-7c60ddc763e4)
### INSIGHTS
- Only when the Dispose method from the IDisposable Interface is implemented, the file is able to be read and written from the same main method. Otherwise the `file is currently used by someother object` exception is thrown.

