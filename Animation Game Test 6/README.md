# Animation Game Test 06 (AGT06)

**Created:** 2022–2023  
**Language/Tech:** C# (.NET, Windows Forms)

## Overview
**Animation Game Test 06** is a particle‑based simulation sandbox that models a 3D grid world with moving entities, collision detection, and mass‑based momentum exchange.  
The surviving build contains the particle engine and collision system from a much larger original vision that also included atomic data, chemical bonding, and VSEPR structure generation using custom high‑precision math.

The simulation projects the 3D space onto a 2D bitmap in real time, allowing you to watch particles move, collide, and interact according to simple physical rules.

## Features
- **3D particle space**:
  - Positions stored as decimal triples.
  - Velocity per axis (x, y, z) in decimal form.
  - Mass derived from atomic number + neutron count.
  - Color per particle for rendering.
- **Spatial representation**:
  - `space3D[x,y,z]` array holds particle IDs at each coordinate.
  - `bitmap_layers[x,y]` tracks stacked particles in the 2D projection.
- **Rendering**:
  - Orthographic‑style projection from 3D to 2D bitmap coordinates.
  - Depth ordering so nearer particles overwrite farther ones in the same pixel.
- **Collision detection**:
  - Axis‑aligned, grid‑based — checks the next cell in the direction of travel.
  - Boundary checks against simulation size.
- **Collision response**:
  - Elastic collision along each axis.
  - Velocity exchange scaled by relative mass.
  - Per‑axis clamping to ±1 000 000 000 to prevent runaway speeds.
- **Movement**:
  - Time‑stepped updates based on nanosecond‑scale counters.
  - Per‑axis movement triggers when enough time has elapsed for one grid step.
  - Erases old position from `space3D`/`bitmap_layers` and inserts at new position.

## How to Use
1. Launch the application.
2. Enter:
   - Initial 3D position (x, y, z).
   - Velocity components for each axis.
   - Atomic data (protons, neutrons, electrons).
   - RGB color values.
3. Click the control to add the particle.
4. The simulation will:
   - Place the particle in the 3D grid.
   - Project it into the 2D view.
   - Begin updating positions and handling collisions in real time.

## Example
**Initial conditions**:
- Position: `10 10 10`
- Velocity: `1 0 0`
- Atomic data: `6 6 6` (example values)
- Color: `255 0 0`

**Observed behavior**:
- Particle moves along +X axis.
- Bounces off walls or other particles.
- Exchanges velocity with other particles based on mass.

## Technical Notes
- **Update loop**:
  - Asynchronous loop increments a `current_time` counter.
  - Checks each particle to see if it should move along any axis.
  - Handles collisions before updating position.
- **Projection math**:
  - `x2D = (sizeX - z) + x`
  - `y2D = ((sizeX - y) + z + x) / 1.5`
- **Mass and momentum**:
  - Mass = protons + neutrons.
  - Momentum exchange uses mass ratio to scale velocities.
- **Extensibility**:
  - Original design included covalent/ionic bonding arrays and VSEPR geometry generation.
  - Could be expanded to continuous‑space physics, more complex collision shapes, and chemical interaction rules.

## Known Limitations
- Discrete grid movement — no sub‑cell positions in this build.
- Naïve collision detection — only checks the immediate next cell.
- No diagonal collision handling beyond per‑axis checks.
- No persistence — simulation state lost on close.
- Bonding and VSEPR logic are stubbed but not implemented in this version.

## Screenshot
<img width="1662" height="830" alt="image" src="https://github.com/user-attachments/assets/a5dde090-7b66-4b63-b142-a64ecf4e10e0" />


## Credits
- **Developer:** Ilia Viacheslavovich Landakov  
- Inspired by particle physics, atomic modeling, and determinism.
