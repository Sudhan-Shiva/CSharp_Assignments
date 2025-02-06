# EXPLORATION Q/A
## 1 . Explain what the .NET platform is and its primary purpose.
 
**Ans :**
-  The .NET platform is a framework which is used to build applications using languages such as C#, F# and IronPython.
- .NET platform enables the application to work across various OS including Windows, MAC and Linux.
- The .NET framework consists of Roslyn compiler which converts the .cs files to Common Intermediate Language (CIL) which is done during the compilation time and  is stored in .exe file.
- Even objects of other .NET compatible languages (F#, IronPython, Visual Basic) can be used in C# application since CIL acts as the common convertible language.
- At runtime, the CIL is converted into binary code (machine code) through the Just In Time (JIT) compiler which converts only the necessary parts thus saving time and memory.
- The .NET framework consists of the execution environment Common Language Runtime (CLR) which acts as the major part in running of the application.
- The CLR has several functionalities such as Memory Management, Exception Handling, Multithreading and many more.
## 2. What are the key components of the .NET platform?
 
**Ans :**
- The Source code in the .cs files (in case of C#) of the application desired acts as the basic key of the .NET platform.
-  The .NET framework consists of the execution environment Common Language Runtime (CLR) which acts as the major part in running of the application.
- CLR consists of  the Common Language Infrastructure (CLI), Just In Time (JIT) compiler and Garbage Collector (GC) .
- The .NET framework consists of Roslyn compiler which converts the .cs files to Common Intermediate Language (CIL) which is done during the compilation time and  is stored in .exe file.
- The CLI consists of Common Type System (CTS) and Common Language Specification (CLS) which defines the basic set of rules that must be followed by the Roslyn compiler.
- The CTS defines the set of datatypes and their properties followed across the .NET framework and CLS defines the set of common rules that must be followed by different languages compatible with the .NET platform.
- CTS and CLS are mainly focused during the CIL conversion to enable interoperability across multiple languages.
- At runtime, the CIL is converted into binary code (machine code) through the Just In Time (JIT) compiler which converts only the necessary parts thus saving time and memory.
-  GC performs Garbage collection (removal of unused objects) at some trigger points such as when the OS informs that only little memory is left in the machine, when the heap memory exceeds a certain threshold or when GC.Collect() is used.
- Framework Class Library (FCL) is an independent component of .NET platform which provides the classes, tools and libraries which can be reused throughout to build a .NET application.
## 3. Differentiate between the Common Language Runtime (CLR) and the Common Type System (CTS) in .NET.
**Ans :**
-  The .NET framework consists of the execution environment Common Language Runtime (CLR) which acts as the major part in running of the application.
- CLR consists of  the Common Language Infrastructure (CLI), Just In Time (JIT) compiler and Garbage Collector (GC) .
- The CLI consists of Common Type System (CTS) and Common Language Specification (CLS) which defines the basic set of rules that must be followed by the Roslyn compiler.
- The CTS is a part of CLR and it defines the set of datatypes and their properties followed across the .NET framework.
- .NET framework enables working across various programming languages such as C#, F# and IronPython.
- A component such as class of another programming language such as F# might be required (Reusability) to run an application developed in C#. Every programming language has its own set of unique datatypes which might not be compatible across other languages.
- To enable interoperability between different languages, CTS defines common datatypes which can be used across the .NET compatible languages. 
- When the source code is converted into CIL, the data types of all languages are converted into the common data types defined in the CTS format which enables the CLR to use the elements of different languages to create the machine code.
## 4. What is the role of the Global Assembly Cache (GAC) in .NET? 
**Ans :**
- The Global Assembly Cache (GAC) is a memory space which is present in the machine that has CLR installed in it.
- GAC is a common memory and it can be accessed by all the applications working under the CLR.
- GAC acts as an central place for storing assemblies of an application.  
- Whenever a CLR runs an application, GAC is the first one to be accessed for the required assembly and then if the assembly is not found then application specific folders will be accessed.
- This shows that placing the required assemblies in the GAC ensures faster access and processing.
- An additional tool or installer can be used to move assemblies to the GAC or it can be done manually too.
- But GAC is basically a cache memory and has limited space, so assemblies common to multiple applications must be given preference to be stored in GAC and precaution must be taken not to overload the GAC.
- GAC is very useful in deploying the same assembly across multiple applications simultaneously.
## 5. Explain the difference between value types and reference types in C#. 
**Ans :**
- C# defines various datatypes such as int, string, DateTime and many more.
- It also allows the user to create classes to define custom datatypes and collections.
- The variables can be assigned to two types - Value types and Reference types.
- Simple datatypes such as int, DateTime, float and struct are stored as value types where the variable consists of the value stored in it.
- Other datatypes such as strings, custom classes, arrays, lists and interfaces are reference type variables which means that they store the address of the object in their variable.
- A stack is present for each thread which consists of the local variables which are defined inside the scope. 
- The reference type variables whcih consists of the address are stored in the stack and the address points to their objects which are stored in the heap.
- The value types in stack can be accessed faster than the reference type values in the heap. But in terms of memory management, the reference type variables perform better since the stack has limited short memory whereas heap has considerably larger memory.
## 6.Describe the concept of garbage collection on .NET and its advantages. 
**Ans :**
- The heap memory must be cleared of the objects which are unused over a long time for better memory management and to prevent memory overloading.
- This functionality is handled by Garbage Collector (GC) which is an component of CLR.
- GC performs Garbage collection (removal of unused objects) at some trigger points such as when the OS informs that only little memory is left in the machine, when the heap memory exceeds a certain threshold or when GC.Collect() is used.
- The unused objects are not cleared immediately by the GC since it runs on its own thread and execution of GC might freeze the execution of the other threads which might cause perfomance issues.
- The GC decides which objects must be removed through Mark-Sweep algorithm (Tracing) where the graph of reachability is constructed from the application roots to determine the unreferenced objects.
- Memory fragmentation might occur due to garbage collection which is rectified by GC by moving the objects to accomodate the incoming objects. This process is called Memory Fragmentation.
- Large Object Heaps (LOH) are special heaps for large memory objects which are an exception to memory defragmentation since they are pinned to an address space.  
## 7.What is the purpose of the Globalization and Localization features in .NET? 
**Ans :**
- Globalization in .NET represents developing an application which is culture-neutal and language-neutral.
- The globalization is designed such that it isn't restricted by any culture Specifications and regional data assumptions.
- Globalization must be done in such a way that the application can be localized whenever required without much changes to the source code.
- Localization is the process of developing an application which is specific to the rules of an culture such as language specifications and data interpretation.
- The functionalities of the Globalized application might not differ much from the Localized application. But the data interpretation and the IO formats are adjusted according to the specific needs of the culture.
- The System.Globalization namespace consists of culture-related information such as date format, timings, language, etc,. which can be used in the design of the application to provide cultural specific information if needed.
- The Microsoft.Extensions.Localization can be used to derive methods to provide localization services for the application.
## 8. Explain the role of the Common Intermediate Language (CIL) and Just-In-Time (JIT) compilation in the .NET framework. 
**Ans :**
- The .NET framework consists of Roslyn compiler which converts the .cs files to Common Intermediate Language (CIL) which is done during the compilation time and  is stored in .exe file.
- Even objects of other .NET compatible languages (F#, IronPython, Visual Basic) can be used in C# application since CIL acts as the common convertible language.
- The CIL conversion requires a set of rules and common datatypes which are defined by CTS and CLS to enable interoperability between various .NET languages.
- The .NET framework consists of the execution environment Common Language Runtime (CLR) which acts as the major part in running of the application.
- CLR consists of the Common Language Infrastructure (CLI), Just In Time (JIT) compiler and Garbage Collector (GC) .
- At runtime, the CIL is converted into binary code (machine code) through the Just In Time (JIT) compiler.
- The JIT compiler converts the CIL to machine code based on the specific architecture (32 bit/64 bit) and operating system the compiler is working on.
- Another major advantage of JIT compilation is that it converts only the necessary parts of the code required to run the necessary functionalities, thus saving time and memory.