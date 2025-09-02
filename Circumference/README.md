# Circumference – High‑Precision Circumference Calculator via Polygon Approximation

**Created:** April 2022  
**Language/Tech:** C#, Windows Forms, System.Numerics

## Overview
**Circumference** is a Windows desktop application that calculates the circumference of a circle and the value of π (Pi) to high precision using a polygon‑approximation method.  
The program uses a custom numeric type, `InfiNum`, to perform arbitrary‑precision arithmetic on large real numbers, enabling calculations with hundreds or thousands of digits after the decimal point.

The method is based on inscribing a regular polygon inside a circle and iteratively increasing the number of sides (powers of 2) to approximate the circumference. The application compares the computed value of π to a reference value and reports the number of correct digits.

## Features
- **Custom arbitrary‑precision arithmetic** via the `InfiNum` class.
- Calculates:
  - Circumference length from polygon approximation.
  - Value of π from computed circumference.
  - Length of a single polygon side.
  - Circumference length using a reference π value.
  - Number of correct digits in computed π.
- User‑configurable:
  - Circle radius.
  - Number of polygon sides (as a power of 2).
  - Precision (digits after the decimal point).
- **Bilingual interface** – switch between English and Russian labels/tooltips.
- Input validation with error messages for invalid radius, side count, or insufficient precision.

## How to Use
1. Enter the **radius** of the circle.
2. Enter the **number of sides** as a power of 2 (e.g., `30` → 2³⁰ sides).
3. Enter the **precision** (number of digits after the decimal point).
4. Select your preferred language (English or Russian).
5. Click **Calculate**.
6. View results:
   - Circumference length (computed).
   - Computed π value.
   - Length of one polygon side.
   - Number of correct digits in π.
   - Circumference length using reference π.

**Tip:** For accurate results, set the precision higher than the exponent of the number of sides (e.g., for 2³⁰ sides, use >30 digits after the decimal).

## Technical Notes
- **Algorithm:**  
  - Starts with two points on the circle.
  - Iteratively bisects polygon sides to increase side count.
  - Uses the Pythagorean theorem and square root extraction to find new points.
  - Computes side length and multiplies by the number of sides for circumference.
  - Divides circumference by `2 × radius` to approximate π.
- **Precision Handling:**  
  - `InfiNum` stores numbers as strings, pads fractional parts to the desired precision, and uses `BigInteger` for integer math.
  - Supports addition, subtraction, multiplication, division, powers, roots, and comparisons at arbitrary precision.

## Known Limitations
- Very high side counts and precision settings can result in long computation times (e.g., 2²⁰⁰ sides with 500 digits took ~1 hour).
- Performance depends heavily on CPU speed and chosen precision.

## Screenshot
<img width="1155" height="671" alt="image" src="https://github.com/user-attachments/assets/55bf0e9a-ffd6-4971-a13c-3850c0a5468b" />


## Credits
- **Developer:** Ilia Viacheslavovich Landakov  
- **Custom Numeric Type:** `InfiNum` – original implementation for arbitrary‑precision real numbers.
