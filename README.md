# PROJECTS, SOLUTIONS AND BUILD ORDERS
## PROJECTS
### Project A (GreetingsApp)
- Displays a greeting message. 
- Uses **Project B** to perform the math operations and display the results.
###   Project B (MathApp)
- Contains a class which defines the methods to perform mathematical calculations of user choice.
- Uses **Project C** to get the required inputs and to display the results.
- Uses **Project E** to switch between the required math operations based on the user input.
### Project E (OperationsApp)
- Defines the available math operations as an Enum to declare the user choice.
- Uses **Project C** to get the user option and return it as an enum.
###   Project C (DisplayApp)
- Defines methods for getting integer inputs and display the results of the math operations.
- Uses **Project D** to validate the user inputs if it follows the required constraints.
###   Project D (UtilityApp)
- Implements `Helper` classes that can be used by other projects.
- In this case, input `data validation` acts as the helper class.
### BUILD ORDER
#### INITIAL
- Project A

  ![task-1](https://github.com/user-attachments/assets/d3553699-0906-49ab-a595-885b53500eda)
- Project B 	**--->** 	Project A

  ![task-2](https://github.com/user-attachments/assets/2346b7b3-5e1e-4c95-9f30-b5e8747f35ea)


- Project C 	**--->** 	Project B 	**--->** 	Project A

  ![task-3](https://github.com/user-attachments/assets/41420d32-212d-441f-9177-f97919b1cd99)


- Project D		**--->** 	Project C 	**--->** 	Project B 	**--->** 	Project A

  ![task-4](https://github.com/user-attachments/assets/7f57672c-68bf-48b7-af1b-b49879933f0b)

#### FINAL (After Project E)
- Project D		**--->** 	Project C 	**--->** 	Project E 	**--->** 	Project B 	**--->** 	Project A

  ![task-5](https://github.com/user-attachments/assets/735ca2d5-f49c-44eb-8813-531a420dab2e)

### PROJECT ORGANIZATION
Each project is configured to the respective dependencies by adding the project reference to the required projects and the projects are created accordingly. The process is broken down to sub-elements and defined as projects for more code readability and flexibility.
### CHALLENGES
- The main problem that might occur when a project is added to other projects as dependency, there is probability of circular dependency case occurring.
- Introducing a new project which is to be added as a dependency and also requires other projects as a dependency to be built, might cause issues in the build order.
- Breaking down the solution into multiple projects to handle proper execution order and allocating functionalities between the projects must be taken care of.
### REFERENCES
- https://learn.microsoft.com/en-us/visualstudio/extensibility/internals/solution-dot-sln-file?view=vs-2022
- https://www.udemy.com/course/ultimate-csharp-masterclass/
