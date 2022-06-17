# yoursolution-validate

> Hier öffnet das Zeichen '(' einen Ausdruck und das Zeichen ')' schließt ihn

```c#
YourSolution.Validate("(This looks great!)", "()"); // => True
YourSolution.Validate("(This looks bad!", "()"); // => False
```

```c#
// Hier öffnen '(' und '[' einen Ausdruck. ')' und ']' schließen ihn
YourSolution.Validate("(This [looks] great!)", "()[]"); // => True
YourSolution.Validate("(This [looks) bad!]", "()[]"); // => False
```

```c#
// Hier öffnen '(', '[' und '{' einen Ausdruck. ')', ']' und '}' schließen ihn
YourSolution.Validate("(This {[looks], [great]}!)", "()[]{}"); // => True
YourSolution.Validate("(This {[looks], [bad])!", "()[]{}"); // => False
```