# Custom C++ Syntax Examples

### Main Function Syntax
Main functions can either be `int main()` or `int void()`. Both start with a block.

```cpp
int main() {
    // Variables and operations
    int x = 10;
    int b = 20;
    int z = x + b;

    // Print in line
    print(z);

    // Print with a new line
    print.line("the result: ", z);
}
```

### Array Usage
Array initialization, access, and iteration.

```cpp
int main() {
    int x[] = {1, 2, 3, 4};

    // Accessing array elements
    print(x[0]);

    // Iterating through array using foreach
    foreach(int s in x) {
        print.line(s);
    }
}
```

Output:
```
1
2
3
4
```

### If Statement
Conditional statements with printing.

```cpp
int main() {
    int a = 10;
    int b = 3;

    if (a > b) {
        print("a is bigger ", a, " b value ", b);
    }
}
```

### Do-While Loop
Example of a `do-while` loop structure.

```cpp
int main() {
    int a = 10;
    int b = 0;

    do {
        a = a + 10;
        print(b, " , ");
        b = b + 1;
    } while (b < 10);
}
```

### Output of the Do-While Loop
```
0 , 1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 ,