# Physics Freefall Simulation

**Created:** 2022

**Language/Tech:** C# (.NET, Windows Forms)

## Overview
**Physics Freefall Simulation** is an educational physics program that models the motion of an object in free fall under a variable gravitational field.  
Unlike simple constant‑g calculators, this simulation recalculates gravitational acceleration at each time step based on the object’s current distance from the center of the attracting body. It can also compute escape velocity, density, and determine whether an object meets the conditions to be a black hole.

## Features
- **Variable gravity modeling**:
  - Gravitational acceleration recalculated each step using:
    g_current = (r / (r + d))^2 * g_surface
    where *r* is the body’s radius, *d* is the current height above the surface, and *g* is the surface gravity.
- **Iterative simulation**:
  - Runs in user‑selected increments (seconds or milliseconds).
  - Uses standard kinematic equations for each step.
  - Handles the final partial step with a quadratic equation for precise impact time.
- **Astrophysical calculations**:
  - **Surface gravity** from mass and radius: g = G*M / r^2
  - **Escape velocity**: v_e = sqrt(2GM / R)
  - **Density**: ρ = M / V ,   V = (4/3) * π * r^3
  - Black hole check: escape velocity > speed of light.
- **Customizable parameters**:
  - Mass and radius of the central body.
  - Initial height and velocity of the falling object.
  - Time step resolution.
- **Detailed output**:
  - Step‑by‑step position, velocity, and acceleration.
  - Final impact time and velocity.
  - Theoretical vs. simulated results.

## Example Output
**Scenario**: Dropping from 100 m above Earth’s surface.

Typical formula for free fall: d = ½ g t² We use iteration since g changes with altitude.

Final partial step solved via quadratic: t = 0.5160708196213155 seconds

Impact velocity: ~78.45 m/s


## How to Use
1. Launch the application.
2. Enter:
   - Mass and radius of the central body.
   - Initial height above the surface.
   - Initial velocity (optional).
   - Time step (seconds or milliseconds).
3. Click **Simulate**.
4. View:
   - Iterative step data.
   - Final impact time and velocity.
   - Escape velocity, density, and black hole check.

## Technical Notes
- **Physics engine**:
  - Iterative loop recalculates *g* each step.
  - Uses constant‑acceleration kinematics for each interval.
  - Quadratic solver for final fractional step.
- **Units**:
  - SI units throughout (meters, seconds, kilograms).
- **Extensibility**:
  - Could be expanded to include air resistance, orbital motion, or non‑spherical bodies.

## Known Limitations
- Assumes spherical symmetry and uniform density.
- No atmospheric drag.
- Numerical precision limited by chosen time step.

## Screenshot
<img width="1919" height="1135" alt="image" src="https://github.com/user-attachments/assets/7378ac9d-0fc4-4018-8300-1f68c71b9685" />

## Credits
- **Developer:** Ilia Viacheslavovich Landakov  
- Inspired by classical mechanics and astrophysics.
