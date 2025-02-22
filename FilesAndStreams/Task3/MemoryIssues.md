# Task 3: Investigate Issues in Basic File Usage
 
## Code Issues
 
### MemoryStream Issue

- The code first writes data to a MemoryStream, then copies it to a FileStream.
- The file stream then writes the data into a file.
- Since MemoryStream occupies temporary storage in memory for faster processing of data, it is unnecessary in this case since the data is directly written into the file.
### Console Printing

- The code reads bytes from the file and prints them character by character.
- This is unnecessary since the buffer data can be directly converted to a string and then be printed.
- This removes any unwanted processing of the string to characters.
### Wastage of buffer memory

- The code reads with a buffer of fixed size which is 1024 bytes.
- If the contents of the file is smaller than 1024 bytes, the buffer will contain unnecessary empty data.

## Optimizations

### Removed MemoryStream

- Writing directly to the file using FileStream eliminates the unwanted memory allocation by MemoryStream.

### String Reading

- Instead of reading bytes in a loop, the file contents are stored into a buffer and converted to a string.
- This removes unnecessary loop iterations.

### String Conversion
 
- The Encoding.UTF8.GetString(buffer, 0, bytesRead) method converts only the actual number of bytes read into a string.
- This prevents any unwanted data or empty data to be present in the string.
