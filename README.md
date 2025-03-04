# Reflection in C# - Hands-on Technical Assignment
 
## Task-1 (Inspect Assembly Metadata)  
Implemented a program that inspects the metadata of an assembly using Reflection.  
- **Used** `Assembly.LoadFile` to load assemblies dynamically.  
- **Extracted** types, methods, properties, fields, and events using `GetTypes`, `GetMethods`, `GetProperties`, `GetFields`, and `GetEvents`.  
- **Displayed** metadata information for analysis.

  ![image](https://github.com/user-attachments/assets/cb82ecbd-6340-4f91-a0fb-8ae77d4b2003)  &emsp;&emsp;&emsp; ![image](https://github.com/user-attachments/assets/f2b5f81a-7afd-4289-be96-80e41245285d)

## Task-2 (Dynamic Object Inspector)  
Developed a dynamic object inspector tool to view and modify object properties at runtime.  
- **Retrieved** object metadata using `GetType`.  
- **Displayed** all properties and their values using `GetProperties`.  
- **Allowed** modification of property values dynamically using `SetValue`.

  ![image](https://github.com/user-attachments/assets/80a225bf-aeed-46eb-83da-a1c54ddb232f) &emsp;&emsp;&emsp; ![image](https://github.com/user-attachments/assets/b4f4fde8-4c77-472e-b743-14eda1a1ebc4)

## Task-3 (Dynamic Method Invoker)  
Implemented a method invoker that dynamically calls methods on an object based on a provided method name.  
- **Extracted** method metadata using `GetMethod`.  
- **Invoked** the method using `Invoke`, passing necessary parameters dynamically.  
 
## Task-4 (Dynamic Type Builder)  
Built a dynamic type at runtime with user-defined properties and methods.  
- **Created** an assembly and module using `AssemblyBuilder` and `ModuleBuilder`.  
- **Defined** a new class using `TypeBuilder`.  
- **Added** properties and methods dynamically using `DefineProperty` and `DefineMethod`.  
- **Instantiated** the dynamically generated type and used it in runtime operations.  
 
## Task-5 (Plugin System)  
Developed a plugin system for loading and executing methods from external assemblies at runtime.  
- **Defined** a common interface for plugins.  
- **Created** plugin assemblies that implement the interface.  
- **Loaded** plugin assemblies dynamically using `Assembly.LoadFile`.  
- **Retrieved** and instantiated plugin types dynamically.  
- **Called** methods on plugins through Reflection.  

  ![image](https://github.com/user-attachments/assets/10284fe6-dfcf-474b-ac50-3e1882a0f0fd)

## Task-6 (Mocking Framework)  
Implemented a dynamic mocking framework using Reflection.Emit.  
- **Identified** an interface to mock.  
- **Generated** a dynamic type implementing the interface using `TypeBuilder`.  
- **Defined** methods dynamically using `MethodBuilder`, returning default values.  
- **Created** an instance of the mock type and used it in unit testing scenarios.  
 
## Task-7 (Serialization API)  
Developed a simple serialization API using Reflection and optimized it using Reflection.Emit.  
- **Implemented** serialization of objects to a custom format using Reflection.  
- **Identified** performance and correctness limitations.  
- **Rewrote** serialization logic using `DynamicMethod` and `ILGenerator` to optimize performance.  
- **Compared** execution time and correctness between Reflection-based and Reflection.Emit-based serialization.

  ![image](https://github.com/user-attachments/assets/89ec86d8-496d-4413-b34e-864aaceef3bd)

 
