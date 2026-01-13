# C# 13 Features - Sample Projects

This repository contains hands-on examples of the new features introduced in **C# version 13** (shipped with .NET 9).  
Each project P198 - P208 illustrates one feature with runnable code.

---

## 🚀 New Features in C# 13

### 1. `params` Collections (`P194_ParamsCollections`)
- **What’s new**: The `params` modifier can now be applied to more collection types, not only arrays.
- **Example**:
  ```csharp
  void PrintItems(params List<int> items)
  {
      foreach (var i in items) Console.WriteLine(i);
  }

  PrintItems(1, 2, 3, 4);
  ```
- **Before**: `params` was limited to arrays (`params int[]`).

---

### 2. New Lock Object (`P195_NewLockObject`)
- **What’s new**: Introduces `System.Threading.Lock`. When used in a `lock` statement, the compiler emits IL that leverages the new lock type instead of `Monitor`.
- **Example**:
  ```csharp
  var myLock = new Lock();
  lock (myLock)
  {
      DoSomething();
  }
  ```

---

### 3. Escape Sequence `\e` (`P196_EscapeSequenceE`)
- **What’s new**: New escape sequence for the ESC character (U+001B).
- **Example**:
  ```csharp
  Console.WriteLine("\e[31mRed Text\e[0m");
  ```
- **Before**: You had to write `\u001b` or `\x1b`.

---

### 4. Method Group Natural Type Improvements (`P197_MethodGroupNaturalType`)
- **What’s new**: Overload resolution for method groups is improved. Inapplicable overloads (wrong arity, constraint failures) are pruned earlier.
- **Example**:
  ```csharp
  delegate void Del(int x);

  void Foo(int x) => Console.WriteLine(x);
  void Foo<T>(T x) { }

  Del d = Foo;  // picks the non-generic overload
  ```

---

### 5. Implicit Indexers in Object Initializers (`P198_ImplicitIndexersInObjectInitializers`)
- **What’s new**: Index initializers now support the “from the end” operator (`^`) inside object/collection initializers.
- **Example**:
  ```csharp
  var numbers = new List<int> { 1, 2, 3, 4, [^1] = 99 };
  // numbers = [1, 2, 3, 99]
  ```

---

### 6. Ref / Unsafe in Async and Iterators (`P199_RefUnsafeInAsyncIterators`)
- **What’s new**: `ref` locals, `ref struct` types, and `unsafe` contexts are now allowed in `async` methods and iterators, with restrictions (they can’t cross `await`/`yield` boundaries).
- **Example**:
  ```csharp
  async Task ExampleAsync()
  {
      Span<int> span = stackalloc int[5];
      ref int r = ref span[0];
      Console.WriteLine(r);
      await Task.Delay(1); // r/span can’t be used after this point
  }
  ```

---

### 7. Allows Ref Struct in Generics (`P200_AllowsRefStruct_Generic`)
- **What’s new**: New constraint `where T : allows ref struct` lets generics accept `ref struct` types.
- **Example**:
  ```csharp
  void Process<T>(T value) where T : allows ref struct
  {
      Console.WriteLine(value.ToString());
  }

  Process(new Span<int>(new int[5]));
  ```

---

### 8. Ref Structs Implement Interfaces (`P201_RefStructInterfaces`)
- **What’s new**: `ref struct` types can now implement interfaces.
- **Example**:
  ```csharp
  public interface IProcessor { void Run(); }

  public ref struct MySpan : IProcessor
  {
      public void Run() => Console.WriteLine("Running in a ref struct");
  }
  ```

---

### 9. Partial Properties and Indexers (`P202_PartialPropertiesIndexers`)
- **What’s new**: Like partial classes and methods, you can now declare **partial properties and indexers**.
- **Example**:
  ```csharp
  // File A
  public partial class MyClass
  {
      partial int MyProp { get; set; }
  }

  // File B
  public partial class MyClass
  {
      partial int MyProp { get; set; } = 42;
  }
  ```

---

### 10. Overload Resolution Priority (`P203_OverloadResolutionPriority`)
- **What’s new**: Library authors can control which overloads the compiler prefers during resolution.
- **Example**:
  ```csharp
  public static class Overloads
  {
      [OverloadResolutionPriority(1)]
      public static void Do(int x) => Console.WriteLine("int");

      public static void Do<T>(T x) => Console.WriteLine("generic");
  }

  Do(5); // picks the int overload
  ```

---

### 11. `field` Keyword (Preview) (`P204_FieldKeyword_Preview`)
- **What’s new**: Preview feature allowing `field` keyword in property accessors to directly refer to the compiler-generated backing field.
- **Example**:
  ```csharp
  public class Person
  {
      public string Name
      {
          get => field;
          set => field = value.ToUpper();
      }
  }
  ```

---

## Repository Structure

- `P198_ParamsCollections` → params collections  
- `P199_NewLockObject` → new `Lock` type  
- `P200_EscapeSequenceE` → escape sequence `\e`  
- `P201_MethodGroupNaturalType` → method group resolution  
- `P202_ImplicitIndexersInObjectInitializers` → implicit indexers  
- `P203_RefUnsafeInAsyncIterators` → ref/unsafe in async/iterators  
- `P204_AllowsRefStruct_Generic` → allows ref struct in generics  
- `P205_RefStructInterfaces` → ref struct interfaces  
- `P206_PartialPropertiesIndexers` → partial properties/indexers  
- `P207_OverloadResolutionPriority` → overload resolution priority  
- `P208_FieldKeyword_Preview` → field keyword (preview)  

---

## Requirements

- .NET 9 SDK  
- C# 13 compiler enabled  

To run any sample:
```bash
cd P194_ParamsCollections
dotnet run
```

---

## References

- [What’s new in C# 13 – Microsoft Docs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-13)  
- [C# 13 Preview Features – .NET Blog](https://devblogs.microsoft.com/dotnet/csharp-13-explore-preview-features/)  
