# GOLD Parser – C++-Like Grammar

## 📘 Project Description

This project is a **custom grammar definition** for the **GOLD Parser**, designed to parse a **subset of C++-like syntax**. The goal is to recognize and analyze fundamental structures commonly used in C++ programming, including:

- ✅ Variable declarations and assignments  
- ✅ Conditional statements (`if`, `else`)  
- ✅ Loop constructs (`for`, `while`)  
- ✅ Function declarations and return statements  
- ✅ Arithmetic and relational expressions  

The grammar is written using the **GOLD Parsing System’s specification format**, which includes character sets, terminals, non-terminals (rules), and a designated start symbol. It can be used as the foundation for building a:

- Syntax checker  
- Interpreter  
- Simple compiler front-end  

---

## ⚙️ Features

- Support for basic data types: `int`, `float`, `double`, `char`, `void`
- Statement handling including blocks `{ ... }`
- Expression parsing with correct precedence and associativity
- Function support with parameters and return values
- Relational operators: `==`, `!=`, `<`, `>`, `<=`, `>=`
- Arithmetic operators: `+`, `-`, `*`, `/`

---

## 🧪 Example Program

```cpp
int sumPositiveUpTo(int limit) {
    int sum = 0;

    if (limit > 0) {
        for (int i = 1; i <= limit; i++) {
            sum = sum + i;
        }
    }

    return sum;
}
