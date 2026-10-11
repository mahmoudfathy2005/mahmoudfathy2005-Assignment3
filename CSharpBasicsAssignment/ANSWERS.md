# Part G — Short Answer

## Question 1 — CSharpBasicsAssignment.csproj

The `CSharpBasicsAssignment.csproj` file contains project settings that tell .NET how to build the application.

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

### Explanation

* **OutputType**

  ```xml
  <OutputType>Exe</OutputType>
  ```

  Specifies that the project is an executable application.

* **TargetFramework**

  ```xml
  <TargetFramework>net9.0</TargetFramework>
  ```

  Specifies that the project targets .NET 9.

* **ImplicitUsings**

  ```xml
  <ImplicitUsings>enable</ImplicitUsings>
  ```

  Automatically adds common `using` directives so that they do not have to be written manually in every C# file.

* **Nullable**

  ```xml
  <Nullable>enable</Nullable>
  ```

  Enables nullable reference type analysis. This helps the compiler warn about possible `null` reference problems.

---

## Question 2 — Do #region / #endregion change the compiled output?

No.

`#region` and `#endregion` are preprocessor directives used mainly to organize code in the editor and allow sections of code to be collapsed or expanded.

For example:

```csharp
#region Types

// code

#endregion
```

They do not change the program's behavior or compiled logic by themselves.

---

## Question 3 — When would you reach for /// XML doc comments instead of a plain //?

I would use `///` XML documentation comments when documenting public or reusable code such as:

* Classes
* Methods
* Properties
* APIs

For example:

```csharp
/// <summary>
/// Calculates the sum of two numbers.
/// </summary>
int Add(int a, int b)
{
    return a + b;
}
```

XML documentation can be understood by IDEs and can also be used by documentation-generation tools.

A normal `//` comment is more suitable for regular explanations or notes inside the code.

For example:

```csharp
// Calculate the total price
decimal total = price * quantity;
```

---

## Question 4 — Why does C# have no true global variables?

C# does not provide true global mutable variables that exist independently of a type or scope.

C# organizes variables inside scopes and types, which helps keep data organized and controlled.

When shared data is needed, one possible approach is a `static` field inside a class:

```csharp
class AppSettings
{
    public static string AppName = "My Application";
}
```

The field can then be accessed through the class:

```csharp
Console.WriteLine(AppSettings.AppName);
```

This is not a true global variable because the variable still belongs to the `AppSettings` type.
