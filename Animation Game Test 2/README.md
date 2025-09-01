# Animation Game Test 2 – Random Picture Generator

**Created:** December 2020  
**Language/Tech:** C#, .NET GUI

## Overview
A desktop program that generates random pixel‑based images from a user‑selected color palette. Includes customization options for colors, size, orientation, and magnification.

## Features
- Choose colors from a preset list or add two custom RGB values.
- Resize the generated picture.
- Save generated images to disk.
- Magnify the image by a chosen factor.
- Adjust generation orientation (vertical or horizontal).
- Experimental “Animation Game Test 3” mode:
  - Unlimited colors
  - Set percentage probability for each color
  - Control randomness loop timing (in ticks)

## How to Use
1. Select colors from the list or enter custom RGB values in the gray textboxes.
2. Choose image size and orientation.
3. Click **Generate** to create the picture.
4. Optionally, adjust magnification (note: high values may slow performance).
5. Save the image if desired.

**Example code for Test 3 mode:**
0 0 0/255 255 25540 60*7000
Generates a black‑and‑white image with 40% black, 60% white, each pixel held for 7000 ticks.

## Notes
- Magnification above ~20 may cause long processing times.
- Known glitch: rapidly selecting/unselecting colors during generation may produce black pixels — a side effect of the color removal process.

## Screenshot

<img width="1919" height="1134" alt="image" src="https://github.com/user-attachments/assets/ea5d4673-3c16-470a-9b45-247ce0d1430b" />
