Code in this library works to adhere to the following standards, with the understanding that rare particular circumstances may require a different approach.

## Overall

- Generally, favor verbosity in names.
- Generally, favor more short lines of code over fewer long lines of code.
    - An exception is made for fluent concatenation of method calls, as in Linq.
- Generally, favor more comments than fewer.
- Generally, follow Microsoft's [C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions), with the following additions and changes.

## Project Layout

- One folder per namespace.
    - Child namespaces should be plural, i.e. `ParquetClassLibrary.Utilities`.
- One namespace per folder.
- One namespace per file, unless you are embedding namespaces to hide internal classes.
- One class per file, except for internal classes or static classes that collect method extensions.
    - If you have a class of type `CustomType` and it is frequently collected in arrays, extension methods of the form
    ```cs
    Method(this CutomType[] inArrayArgument)
    ```
    should be located in a class named `CustomTypeArrayExtensions` at the bottom of the file in which `CustomType` is defined.

## File Format
- Spaces, not tabs.
    - 4 spaces for each indentation level.
- If continuation lines are not indented automatically, indent them until they match logically with the line they continue, as follows:
    ```cs
    var leastYValue = Spaces
                      .Select(space => space.Position.Y)
                      .Min();
    ```

## File Layout
- One blank line between using directives and namespace declarations.
- One blank line between class definitions.
- One blank line between every property, field, and method.
- Generally, one statement or definition per line.
    - Long statements should be broken up into multiple lines to aid readability.
    - Linq statements should be broken up across multiple lines to aid readability as follows:
    ```cs
    var greatestXValue = Spaces
                         .Select(space => space.Position.X)
                         .Max();
    ```
    - Whenever possible, the ternary operator `?:` should be broken up across multiple lines in this fashion:
    ```cs
    return useCapitalLeters
        ? "Hello, World!"
        : "hello, world!";
    ```
- Using directives before the outermost namespace, unless you are embedding the namespace reference to hide it from client code.
- Use the `#region` macro liberally to collect related code elements.
    - In particular, if a class is defined as `someClass : ISomeInterface`, then the implementation of that interface should be grouped together in a region as `#region ISomeInterface Implementation`
    - Many Parquet classes are separated in this way:
    ```cs
    public class SomeClass : IInterface1, IInterface2
    {
        #region Class Defaults
        // Any constants, readonly static variables, or default values.
        #endregion

        #region Characteristics
        // Fields representing state that does NOT change while that game is running.
        #endregion

        #region Status
        // Fields representing state that DOES change while that game is running.
        #endregion

        #region Initialization
        // Constructors.
        #endregion

        #region IInterface1 Implementation
        // Methods implementing IInterface1
        #endregion

        #region IInterface2 Implementation
        // Methods implementing IInterface2
        #endregion

        #region Utilities
        // ToString() and other general purpose helper methods.
        #endregion
    }
    ```
## Comment Conventions
- Comments go on separate lines, not on the same line.
- Comments go above the line or block they are commenting on, not below it.
- Comments should be full sentences whenever possible.
- Fill out the XML comment section for all methods and properties, even private ones.  Paige relies heavily on these.
- Think of `#region` titles as a type of comment.
## Other Conventions
- Write each logical condition in an `if` statement on a separate line as follows:
    ```cs
    if (null != someVariable
        && null != someOtherVariable
    {
        // Do something.
    }
    ```
- If a method or property can be simplified into a single statement without compromising its safety or legibility, write it in expression-bodied form.  For example:
    ```cs
    public bool IsEmpty
        => EntityID.None == Floor
        && EntityID.None == Block
        && EntityID.None == Furnishing
        && EntityID.None == Collectible;
    ```
## Finally
I am always open to constructive criticism on these guidelines, and for considering special cases.