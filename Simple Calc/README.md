# Simple Calc – High‑Precision Real Number Calculator

**Created:** 2022  
**Language/Tech:** C#, .NET (Windows Forms), System.Numerics

## Overview
**Simple Calc** is a custom calculator capable of performing arithmetic on extremely large real numbers with high precision, including fractional parts up to 30 decimal places.  
The program introduces a custom numeric type, `InfiNum`, built on the `string` class and leveraging `BigInteger` for core operations. This allows calculations beyond the limits of standard C# numeric types, which either cap at fixed ranges (e.g., `byte`, `uint`) or lack fractional support (`BigInteger`).

Originally developed as a research project for the All‑Russian Competition of Student Research Projects, this calculator was designed to demonstrate both algorithmic innovation and practical application in high‑precision computation.

## Features
- **Custom numeric type `InfiNum`** for arbitrary‑length real numbers with 30 decimal places.
- Supports:
  - Addition
  - Subtraction
  - Multiplication
  - Division
  - Exponentiation
  - Root extraction (custom iterative algorithm)
- Choice of numeric type for operations:
  - `Decimal` (built‑in)
  - `BigInteger` (built‑in)
  - `InfiNum` (custom)
- Graphical interface with:
  - Two input fields for operands
  - Checkboxes to select numeric type
  - Buttons for each arithmetic operation
- Displays results in the interface after computation.

## How to Use
1. Enter two real numbers into the input fields.
2. Select the numeric type:
   - **Decimal** for standard precision
   - **BigInteger** for large integers
   - **InfiNum** for high‑precision large real numbers
3. Click the button for the desired operation.
4. The result will appear at the top of the interface.

**Example:**  
- Input: `45.9` and `76`  
- Type: `InfiNum`  
- Operations: Add → Multiply → Root → Subtract → Divide → Power

## Technical Notes
- `InfiNum` stores numbers as strings, strips the decimal point for internal operations, and reinserts it after computation.
- Arithmetic is performed using `BigInteger` on the integer representations of the numbers.
- The root function uses a custom iterative method to approximate results.
- The program successfully computed: 99.999999999999 ^ 99999 in 412 hours, producing a result with **199,627 characters** (including the decimal point).

## Known Limitations
- Performance decreases significantly with extremely large exponents or roots.
- Long computations may require hours or days to complete.

## Screenshot
<img width="738" height="725" alt="image" src="https://github.com/user-attachments/assets/4a1a8cbd-860c-414c-b8ab-6c360356ae9e" />


## Credits
- **Developer:** Ilya Vyacheslavovich Landakov  
- **Mentor:** Marina Ivanovna Zhuravlyova (Informatics Teacher, MBOU Lyceum No. 1, Voronezh)  
- **Scientific Consultant:** Oksana Valerievna Kuripta (Associate Professor, Voronezh State Technical University)

## References
- *Pro C# 8 with .NET Core 3: Foundational Principles and Practices in Programming*, Andrew Troelsen & Phil Japikse, 2020.
  
