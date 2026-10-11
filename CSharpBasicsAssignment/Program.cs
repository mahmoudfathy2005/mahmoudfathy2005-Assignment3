// === PART A: Project & Structure ===
// .csproj:
// Defines project settings such as output type, target framework,
// implicit usings, and nullable reference type settings.
//
// Program.cs:
// Contains the main C# program code and top-level statements.
//
// obj/:
// Contains intermediate files generated during the build process.
//
// bin/:
// Contains the final compiled output of the application.

//  namespace CSharpBasicsAssignment;

// File-scoped namespace removes one level of indentation
// because the whole file automatically belongs to this namespace.

// This project uses the classic .sln solution format.
// The newer .slnx format has a simpler XML-based structure
// and can be easier to read and maintain.


namespace CSharpBasicsAssignment;

class Program
{
    static void Main()
    {
        RunTypesDemo();
        RunValueVsReferenceDemo();
        RunScopeDemo();
        AnotherMethod();
        RunMethodScopeDemo();
        RunBlockScopeDemo();
        Operators();
        Bitwiseoperators();
        


    }


    //=== PART B: Variables, Types & Casting ===

    static void RunTypesDemo()
    {
        Console.WriteLine("=== PART B: Variables, Types & Casting ===");

        int age = 25;
        long population = 1000000L;
        double height = 175.5;
        decimal salary = 15000.75m;
        bool isStudent = true;
        char grade = 'A';
        string name = "Ali";
        var score = 95;

        Console.WriteLine($"age = {age}, Type = {age.GetType()}");
        Console.WriteLine($"population = {population}, Type = {population.GetType()}");
        Console.WriteLine($"height = {height}, Type = {height.GetType()}");
        Console.WriteLine($"salary = {salary}, Type = {salary.GetType()}");
        Console.WriteLine($"isStudent = {isStudent}, Type = {isStudent.GetType()}");
        Console.WriteLine($"grade = {grade}, Type = {grade.GetType()}");
        Console.WriteLine($"name = {name}, Type = {name.GetType()}");
        Console.WriteLine($"score = {score}, Type = {score.GetType()}");


        int number = 100;
        long longNumber = number;

        char letter = 'A';
        int asciiValue = letter;
        // No explicit cast is required because long can safely represent
        // every int value, and char can be implicitly converted to int.


        double doubleValue = 9.78;
        int intValue = (int)doubleValue; // Explicit cast from double to int =>9     truncates

        int intValue2 =Convert.ToInt32(doubleValue); // => 10   rounds

        Console.WriteLine($"int {intValue}");
        Console.WriteLine($"Convert {intValue2}");

        // Casting with (int) truncates the fractional part.
        // Convert.ToInt32 rounds the value to the nearest integer.

        int r1 = 5 / 2; // => 2
        double r2 = 5.0 / 2; // => 2.5

        Console.WriteLine(($"5 / 2 = {r1}, 5.0/2 = {r2}"));
        // When both operands are integers, integer division is used,
        // so the fractional part is discarded. A double operand produces floating-point division.

        // Boxing and unboxing
        int original = 42;

        object boxed = original;

        Console.WriteLine($"After boxing: {boxed}");

        int unboxed = (int)boxed;

        Console.WriteLine($"After unboxing: {unboxed}");

        // Parsing strings to numbers

        string valid = "42";
        int parsedInt = int.Parse(valid);
        Console.WriteLine($"Parsed value: {parsedInt}");

        string invalid = "abc";
        bool success = int.TryParse(invalid, out int result);
        Console.WriteLine($"TryParse succeeded: {success}");


        float floatValue = 3.14f;
        //decimal decimalValue = floatValue; // Implicit conversion from float to decimal

        decimal decimalValue2 =(decimal)floatValue; // Explicit conversion from float to decimal
        Console.WriteLine($"float to decimal: {decimalValue2}");

        // refuse implicit bescause has the diffrent base and lose information
        // 




    }

    struct Point
    {
        public int X;
        public int Y;
    }

    //=== PART C: Value vs Reference Types ===
    static void RunValueVsReferenceDemo()
    {
        Point P1= new Point { X = 1, Y = 2 };
        Point P2 = P1; // Value type assignment creates a copy
        P2.X = 99;
        Console.WriteLine($"P1.x : {P1.X}  , P2.x : {P2.X}");

        // Point is a value type, so assigning p1 to p2 copies the data.
        // Changing p2 does not change p1.

        Order o1 = new Order
        {
            OrderId = 1,
            CustomerName = "Ali",
            Quantity = 3,
            UnitPrice = 100m,
            TotalPrice = 0m,
            IsPaid = false,
            DiscountPercent = 10,
            ShippingCity = "Cairo",
            Priority = 'H',
            ItemCode = 123456789L
        };
        o1.CalculateTotal();

        Order o2 = o1; // Reference type assignment copies the reference

        o2.IsPaid = true;

        Console.WriteLine($"O1.IsPaid : {o1.IsPaid}");
        Console.WriteLine($"O2.IsPaid : {o2.IsPaid}");

        // Order is a reference type, so assigning o1 to o2 copies the reference.

        object boxedOrder = o1; // no boxing occurs here because Order is a reference type

        Order o3 = (Order)boxedOrder;
        Console.WriteLine(
                    $"Same instance: {object.ReferenceEquals(o1, o3)}");

        //Boxing is only relevant for value types. Reference types are always accessed through references, so no boxing occurs when assigning a reference type to an object variable.



        o2.PrintSummary();

        // Value types store their data directly, while reference-type variables store
        // a reference to an object, with the object itself represented on the heap.
        // Assigning a value type copies the actual data, so changing the copy does not
        // affect the original. Assigning a reference type copies the reference, so two
        // variables can refer to the same object. Storing a reference type in an object
        // variable does not create a new object because the same reference is stored.


    }



   // === PART D: Scope & Operators ===


    private static int _fieldValue = 50;

    public static void RunScopeDemo()
    {
        Console.WriteLine("=== D1: Scope ===");

        Console.WriteLine($"Field from RunScopeDemo: {_fieldValue}");
    }

    public static void AnotherMethod()
    {
        Console.WriteLine($"Field from AnotherMethod: {_fieldValue}");
    }


    public static void RunMethodScopeDemo()
    {
        int localNumber = 100;

        Console.WriteLine($"Local variable: {localNumber}");
    }
    // localNumber has method scope and cannot be accessed outside this method.

    public static void RunBlockScopeDemo()
    {
        for (int i = 0; i < 3; i++)
        {
            int insideLoop = i * 10;

            Console.WriteLine(
                $"i = {i}, insideLoop = {insideLoop}");
        }

        // Console.WriteLine(i);
        // Console.WriteLine(insideLoop);
        // i and insideLoop have block scope.
        // Using them here would cause a compile error because they are no longer in scope.
    }

    public static void Operators()
    {
        int total = 100;

        Console.WriteLine($"Initial total: {total}");

        total += 5;
        Console.WriteLine($"After += 5: {total}");

        total -= 10;
        Console.WriteLine($"After -= 10: {total}");

        total *= 2;
        Console.WriteLine($"After *= 2: {total}");

        total /= 5;
        Console.WriteLine($"After /= 5: {total}");

        total %= 7;
        Console.WriteLine($"After %= 7: {total}");

        total += 5;
        total = total + 5;

        // total += 5; is equivalent to:
        // total = total + 5;
    }

    
    public static void Bitwiseoperators() {
        int a = 12; //1100 
        int b = 10; //1010

        Console.WriteLine($"a & b {a & b}");
        Console.WriteLine($"a | b {a | b}");
        Console.WriteLine($"a ^ b {a ^ b}");

        // Bitwise & operates on individual bits of integer values,
        // while logical && works with boolean conditions and short-circuits
        // when the left operand is false.


    }



}



