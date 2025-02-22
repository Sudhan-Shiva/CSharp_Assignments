# Working with Files and Streams in C# 

## Task 1: Implement a File Data Processor 

- Created a console application that processes data files. 
- The application reads data from a source file, performs some processing on the data, and writes the processed data to a new file. 
- Created a file of size 1GB, through File write techniques and the data is taken from an online text file.
- Implemented a method that uses FileStream to read data from a large text file. The method reads the file in chunks using a buffer and measures the time it takes to read the entire file. 
- Created a method to use BufferedStream instead of FileStream and compared the performance of the two versions. 
- Implemented a method that processes the data read from the file.
- Implemented a method that writes the processed data to a new file. The method uses MemoryStream to buffer the data before writing it to the file. 

## Task 2: Implement a File Data Processor with Asynchronous Methods 

- Modified the console application to use the asynchronous methods of the FileStream, MemoryStream, and BufferedStream classes. 
- Implemented asynchronous versions of the read, process, and write methods. 
- Modified the application to process multiple files concurrently. 
- Compared the performance of the synchronous and asynchronous versions of the code. 

## Task 3: Investigate Issues in Basic File usage. 

- The issues in the code are analyzed.
- The code is modified to fix the memory issues. 
- A markdown file is included to describe the changes done. 

## Task 4: Analyze and Resolve Performance Issues with Logging System for Multiple Users

The multiple issues in the starter code is analyzed like inefficient memory usage and potential contention when writing to the file. 

### Subtask 1: Identifying Issues 

Analyzed the starter code and identified potential performance and concurrency issues that could occur when multiple users are logging errors simultaneously. 

### Subtask 2: Improving File Writing 

Modified the LogError method to write directly to the file instead of using a MemoryStream.

### Subtask 3: Thread-Safe Logging 

Implemented a locking mechanism to ensure that file write operations are thread safe. 

### Subtask 4: Independent Error Files 

Modified the logging system so that instead of logging all errors to a single file, each user’s error is logged to a unique file. 

### Subtask 5: Performance Testing 

Compared the multiple codes of the subtasks and tested for mulitple user logging errors.