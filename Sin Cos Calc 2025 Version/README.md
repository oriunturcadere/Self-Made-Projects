# Sin/Cos Calculator 2025

**Created:** 2024 
**Language/Tech:** C# (.NET MAUI), Custom Arbitrary‑Precision Math Library (`InfiNum`)

## Overview
**Sin/Cos Calculator 2025** is a high‑precision trigonometric computation tool built with .NET MAUI.  
It uses a custom arbitrary‑precision numeric type (`InfiNum`) and geometric algorithms to calculate:

1. **New coordinates** after rotating a point around a center by a given angle (cos/sin mode).
2. **The angle between two points** relative to a center (angle‑finding mode).

The application is designed for extreme precision, allowing the user to set the number of decimal places for calculations.

## Features
- **Two calculation modes**:
  - **Find new position**: Given a center, a current position, and an angle, compute the rotated coordinates.
  - **Find angle**: Given a center and two points, compute the angle between them.
- **Arbitrary precision**:
  - User‑defined number of decimal places after the decimal point.
  - Internal calculations use `InfiNum` for high‑precision arithmetic.
- **Custom trigonometric algorithms**:
  - Iterative geometric methods for cos/sin on the unit circle.
  - Handles special cases (0°, ±90°, ±180°) directly for speed and accuracy.
  - Reduces angles outside ±360° to within range.
- **Support for non‑unit circles**:
  - Automatically scales calculations for arbitrary radii.
- **Interactive UI**:
  - Built with .NET MAUI for cross‑platform support.
  - Simple form layout with labeled input fields and checkboxes to toggle modes.

## How to Use
1. **Set precision**:
   - Enter the number of decimal places in **Precision**.
2. **Choose mode**:
   - **Find new position**: Check “Find new position” (Cos mode).
   - **Find angle**: Check “Find angle” (Cosneg1 mode).
3. **Enter inputs**:
   - **Center**: X and Y coordinates.
   - **Current position**: X and Y coordinates.
   - **Angle turn** (for Cos mode): Degrees to rotate.
   - **New position** (for angle mode): X and Y coordinates of the rotated point.
4. **Click “Go”**:
   - Results appear in the **New position** fields (Cos mode) or **Angle turn** field (angle mode).

## Example
**Find new position**:
- Precision: `10`
- Center: `(0, 0)`
- Current position: `(1, 0)`
- Angle turn: `90°`
- Output: `(0, 1)`

**Find angle**:
- Precision: `10`
- Center: `(0, 0)`
- Point 1: `(1, 0)`
- Point 2: `(0, 1)`
- Output: `90°`

## Technical Notes
- **`InfiNum`**:
  - Custom arbitrary‑precision number type supporting addition, subtraction, multiplication, division, powers, roots, and comparisons.
- **Angle calculations**:
  - `GetCosSin`: Iteratively rotates a point in 60° and half‑angle steps to reach the target angle.
  - `GetDegreeAngle`: Uses `GetCosSin` to find the angles of two points relative to the center, then computes their absolute difference.
- **Precision handling**:
  - `zeroAFTp` and related fields control tolerance thresholds for comparisons.
- **Special cases**:
  - Direct coordinate swaps for ±90° and ±180° to avoid iterative computation.
  - Angle normalization to the range [‑360°, 360°].

## Known Limitations
- Algorithms are “not 100% precise” for certain angles due to iterative approximation.
- Performance decreases with extremely high precision settings.
- No built‑in error handling for invalid numeric input.

## Screenshot
<img width="1417" height="813" alt="image" src="https://github.com/user-attachments/assets/7db0e8fa-9238-44f2-98c9-ddae809171ab" />

## Credits
- **Developer:** Ilia Viacheslavovich Landakov  
- Built as part of an exploration into high‑precision trigonometry and geometry.
