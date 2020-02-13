This style guide is a modified version of [Microsoft's C# style guide](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/inside-a-program/coding-conventions), [Microsoft's Framework design guidelines](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/names-of-type-members), 
[raywenderlich's style guide](https://github.com/raywenderlich/c-sharp-style-guide#nomenclature)
and the [IDesign C# Coding Standard 2.4](http://www.idesign.net/Downloads/GetDownload/1985).

Table of Contents

Naming conventions

Capitalisation conventions

Commenting conventions

Language guidelines


# Naming conventions

- ✔️ DO Use easily readable identifier names

  For example, `HorizontalAlignment` is easier to read than `AlignmentHorizontal`.

- ✔️ DO prefer meaningful variables over short variable names 

  For example, `CanScrollHorizontally` is better than `ScrollableX`.

- ❌ DO NOT use underscores, hyphens or any other nonalphanumeric characters

- ❌ DO NOT use Hungarian notation

- ✔️ DO name boolean variables with an affirmative phrase (e.g. `CanJump` instead of `CantJump`)

## Using abbreviations and acronyms

- ❌ DO NOT use abbreviations or contractions in identifier names

  For example, `CloseWindow` instead of `CloseWin`

- ❌ DO NOT use any acronyms that are not widely accepted. Even if they are, refrain from using them unless necessary.

- Treat acronyms as words. 

Good:
```c#
string url;
```

Bad:
```c#
string URL;
```

## Avoiding Language-specific names

- ❌ DO NOT use language-specific keywords for type names

  For example, use `GetLength` over `GetInt`.

## Classes, Structs and Interfaces

- ✔️ DO use nouns or nouns phrases for class and struct names

- ✔️ DO use verbs or verb phrases for method names

- ❌ DO NOT include a prefix in class names (e.g. "G")

- ✔️ DO prefix interface names with the letter `i` to make it clear that the type is an interface


# Capitalisation conventions

| Identifier | Casing | Example |
| ---------- | ------ | -------:|
| Type       | Pascal | `public class GameController { ... }` |
| Interface  | Pascal | `public interface IEnumerable { ... }` |
| Method     | Pascal | `public void EndGame() { ... }` |
| Field      | Pascal | `public struct UInt32 { public const Min = 0; }` | 
| Parameter  | Camel  | `public void DisplayScore(int playerScore) { ... }` |


# Layout conventions

## Declarations

One declaration per line.

Good:

```c#
float x;
float y;
```

Bad:

```c#
float x, y;
```

- For clarity, use parentheses to make clauses clear

```c#
if ((foo > bar) && (foo > baz)) 
{
    // do something
}
```

## Classes

One class in every source file, except for inner classes.

## Spacing

### Indentation 

✔️ DO Use 4 spaces for indentation:

Good:
```c#
public void SetName(string name) 
{
    playerName = name;
}
```

Bad:
```c#
public void SetName(string name) 
{
  playerName = name;
}
```

### Line length

Lines should not exceed 100 characters.

## Brace style

- As it is a C# convention, every brace should be on its own line.

Good:
```c#
class GameController 
{
    void EndGame() 
    {
        if (condition) 
        {
            // do something
        } 
        else 
        {
            // do something else 
        }
    }
}
```

Bad:
```c#
class GameController {
    void EndGame() {
        if (condition) {
            // do something
        } else {
            // do something else 
        }
    }
}
```

- ✔️ DO Always include braces for conditionals, even if the body only consists of one line

Good:
```c#
if (gameOver)
{
    EndGame();
}
```

Bad:
```c#
if (gameOver) EndGame();
```

## Vertical spacing

There should be exactly one blank line between the end of a method and the start of the next method.

Good:

```c#
public void foo() 
{
    // ...
}

public void bar() 
{
    // ...
}
```

Bad:

```c#
public void foo() 
{
    // ...
}
public void bar() 
{
    // ...
}
```

Bad:

```c#
public void foo() 
{
    // ...
}


public void bar() 
{
    // ...
}
```

# Commenting conventions

- Add one space between the last forward slash and the comment message. For example:
 
```c#
// This is an example of a good comment
```

- Always place a comment on a separate line, not at the end of a line of code

# Language guidelines

- ❌ DO NOT use type inference. For example:
```c#
var message = "start game"; // bad
string message = "start game"; // good
```

## Unsigned data type

In general, use int instead of unsigned types because `int` is popular in c#, so it is easier to work with other libraries when an int is used.

## Arrays

- When initialising arrays on the declaration line, use the concise syntax:
```c#
string[] fruits = {"apples", "bananas", "pears"}
```

## Static members
Call static members by class name: `ClassName.StaticMember`

## Switch statements
Do not include the `default` case if it is never reached

Good:
```c#
switch (option)
{
    case 1:
        break;
    case 2:
        break;
}
```

Bad:
```c#
switch (option)
{
    case 1:
        break;
    case 2:
        break;
    default:
        break;
}
```

## Language

Use British English spelling.

Good:
```c#
string colour = "blue";
```

Bad:
```c#
string color = "blue";
```

# Programming practices

- Avoid methods that have more 5 arguments. If more than 5 arguments are needed, use structures

- Avoid self-explanatory comments

- With the exceptions of 0 and 1, avoid hard-coding numeric values. Declare constants instead.
