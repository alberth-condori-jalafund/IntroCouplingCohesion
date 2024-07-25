# Refactoring

## Refactoring approach

Since the refactoring was free, the context I took was `Adaptability`, maybe with this approach some good practices like KISS are broken, but they help comply with others that are mentioned in the Clean Code book, in this case I used different programming principles, design patterns and good practices as seen in the UML diagram.

[Click to see the UML](https://drive.google.com/file/d/1ZZ_PBBh92TJ8Is3q_eqBNi_NB1kD6oND/view?usp=sharing)

## Programming Principles

1. Single responsibility: Each class and method has a specific responsibility. doing only what its name indicates, avoiding surprising the user or programmer by doing extra things.

2. Open close: Applied to a lesser extent, but the use of generics helps work with abstractions and not depend on specific types. This promotes code reuse and extensibility, for example, AbstractItem can be extended by other classes without changing its code base.

3. Liskov: Applied to a lesser extent, but created abstract classes or interfaces can replace their base classes without altering the behavior of the program.

4. Interface segregation: Applied to a lesser extent, but interfaces are designed so that users or programmers only know the methods they use.

5. Dependency Inversion: Classes depend on abstractions and not on concrete implementations. For example, OrderService depends on the IInventoryRepository, APaymentService, IOrderSender, and IFeedbackService interfaces.

## Design patterns

-   Repository: For example in AbstractBaseRepository and InventoryRepository to have an intermediary to manage the data.

-   Strategy: It is not explicitly implemented, but the use of composition with abstractions allows this pattern to be applied in the future.

-   Dependency Injection: As I said, composition with abstractions is being used, which allows changing the behavior of a service based on the specific implementation of the abstraction.

## Good practices

-   Use of meaningful names for classes and methods.
-   Use of composition over inheritance to reduce coupling and improve program scalability.
