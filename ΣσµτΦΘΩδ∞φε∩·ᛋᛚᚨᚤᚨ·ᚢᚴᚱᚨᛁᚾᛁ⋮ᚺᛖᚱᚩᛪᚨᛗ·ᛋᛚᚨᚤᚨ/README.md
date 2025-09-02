# Discovering Patterns – Simple Probabilistic Prediction Engine

**Created:** ~2024

**Language/Tech:** C#, Windows Forms

## Overview
**Discovering Patterns** is an experimental C# application that attempts to model a basic “neural network”-like prediction system using probability and weighted averages.  
Instead of implementing a full backpropagation neural net, the program takes a dataset of mixed numeric and categorical features, along with a partially filled “predicting” row, and estimates the missing value based on similarities to the training data.

The application supports predicting:
- **Categorical values** (e.g., gender, political stance, species) using probability distributions.
- **Numeric values** (e.g., salary, measurements) using weighted averages.

## Features
- Accepts **training data** and **prediction input** via text boxes.
- Handles **mixed data types**:
  - Numeric features (`decimal[]`)
  - Categorical features (`string[]`)
- Predicts missing value in a row by:
  - **Categorical target:**  
    - Identifies all unique categories in the target column.
    - For each other feature, calculates how strongly the input matches each category based on proximity (numeric) or equality (categorical).
    - Aggregates probabilities across features.
  - **Numeric target:**  
    - For each other feature, finds the closest training value to the input.
    - Weights known target values inversely by distance from the input.
    - Averages weighted contributions to produce a prediction.
- Displays probability breakdowns for categorical predictions.
- Simple Windows Forms UI with:
  - **Training Data** input box
  - **Prediction Input** box (leave the target cell blank)
  - **Results** output box

## How to Use
1. Enter training data in the **Data** box (`textBox2`), one row per line, values separated by spaces.
2. Enter the prediction row in the **Predict** box (`textBox3`), leaving the target cell blank but preserving spacing.
3. Click **Start** to run the prediction.
4. View:
   - Probability distribution for each possible category (categorical target).
   - Predicted numeric value (numeric target).

**Example:**
Training Data:

M F F M

42 31 23 20

banker fisherman engineer programmer

10000 1200 3112 3878

Prediction Input: M banker 6000

## Technical Notes
- The “AI” method is essentially a **k‑nearest‑neighbor‑inspired** approach with:
  - Inverse distance weighting for numeric features.
  - Exact match probability for categorical features.
- No actual neural network layers or backpropagation — the “neural network” label here is conceptual.
- Designed for experimentation with small datasets; not optimized for large‑scale ML.

## Known Limitations
- No normalization or scaling of numeric features.
- No handling of missing values beyond the single target cell.
- Sensitive to input formatting (spaces, line breaks).
- Not a true machine learning model — no training phase, no learned weights.

## Screenshot
<img width="1276" height="727" alt="image" src="https://github.com/user-attachments/assets/ca5f1711-08c0-40c1-8251-a293dc2f8332" />
