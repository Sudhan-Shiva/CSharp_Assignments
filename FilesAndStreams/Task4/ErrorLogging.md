# Task 4: Analyze and Resolve Performance Issues with Logging System for Multiple Users

## Code Issues
 
### MemoryStream Issue

- The code first writes data to a `MemoryStream`, then writes it to a `FileStream`.
- The file stream then writes the data into a file.
- Since MemoryStream occupies `temporary storage` in memory for faster processing of data, it is unnecessary in this case since the data is directly written into the file.
 
### Racing Conditions
 - Multiple threads (Multiple Users) writing to the same file simultaneously could lead to `race conditions` and also might result in `corrupted error messages`.

### Exception Possibility
- If multiple users are trying to log error at the same time, this will result in `IOException` since the user is trying to access an already open file.
 
## Optimizations
 
### Subtask 2
 
- Removed MemoryStream and switched to direct file writing using FileStream.
- Try Catch blocks are implemented to catch any `IOException`.
 
### Subtask 3
 
- Implemented a `locking mechanism (lock statement)` to prevent multiple threads from writing to the same file at the same time.
 
### Subtask 4
 
- Instead of a single file, each user's errors are stored in `separate files`.
