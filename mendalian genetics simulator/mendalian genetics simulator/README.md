# Mendelian Genetics Simulator

**Created:** ~2019–2020  
**Language/Tech:** C#, Windows Forms

## Overview
**Mendelian Genetics Simulator** is an interactive and analytical genetics tool that models inheritance patterns using Gregor Mendel’s principles.  
It combines a hands‑on allele selection interface with a statistical simulation engine that can generate all possible offspring combinations, count unique genotypes and phenotypes, and calculate both observed and theoretical probabilities.

## Features
### Interactive Mode
- **Multi‑trait simulation** — supports several independent traits (e.g., R/r, Y/y, G/g, C/c, P/p, A/a, T/t).
- **Allele selection UI**:
  - Uppercase = dominant allele, lowercase = recessive allele.
  - Two “slots” per parent per trait.
  - Automatic enforcement of valid genotypes — only two alleles allowed; selecting a third unchecks the second.
- **Real‑time genotype display** — labels update instantly.
- **Dynamic phenotype images**:
  - Dominant phenotype shown for homozygous dominant or heterozygous genotypes.
  - Recessive phenotype shown for homozygous recessive genotypes.
  - “Not enough data” message if selections are incomplete.
- **Bilingual interface** — toggle between English and Russian.

### Simulation/Analysis Mode
- **Generates all possible offspring combinations** from selected parental genotypes.
- **Counts unique genotypes and phenotypes**.
- **Calculates probabilities**:
  - Observed frequency (from simulated seeds).
  - Theoretical probability (fraction of total combinations).
  - Percentage representation.
- **Sorted and raw data views**:
  - Sorted by genotype or phenotype.
  - Raw list of each simulated offspring with genotype and phenotype.

**Example Output:**
Out of 4 seeds there are 4 unique genotypes and 4 unique phenotypes.

All the data, sorted:

genotype - times - theoretical probability - 100%

RryYggcCppaATt - 1/4 - 512/16384 - 25%

rRYyggcCppaAtt - 1/4 - 512/16384 - 25%

rrYyggccPpaAtt - 1/4 - 256/16384 - 25%

RRyyggccPpaAtt - 1/4 - 128/16384 - 25%


phenotype - times - theoretical probability - 100%

RYgCpAT - 1/4 - 1152/16384 - 25%

RYgCpAt - 1/4 - 1152/16384 - 25%

rYgcPAt - 1/4 - 384/16384 - 25%

RygcPAt - 1/4 - 384/16384 - 25%


All the data:

genotype - times - theoretical probability - 100%

RRyyggccPpaAtt - 1/4 - 128/16384 - 25%

rrYyggccPpaAtt - 1/4 - 256/16384 - 25%

rRYyggcCppaAtt - 1/4 - 512/16384 - 25%

RryYggcCppaATt - 1/4 - 512/16384 - 25%


phenotype - times - theoretical probability - 100 %

RygcPAt - 1/4 - 384/16384 - 25%

rYgcPAt - 1/4 - 384/16384 - 25%

RYgCpAt - 1/4 - 1152/16384 - 25%

RYgCpAT - 1/4 - 1152/16384 - 25%


Raw data:


 1.    Genotype: RRyyggccPpaAtt.  Phenotype: RygcPAt

 2.    Genotype: rrYyggccPpaAtt.  Phenotype: rYgcPAt

 3.    Genotype: rRYyggcCppaAtt.  Phenotype: RYgCpAt

 4.    Genotype: RryYggcCppaATt.  Phenotype: RYgCpAT


## How to Use
1. **Interactive Mode**:
   - Select alleles for each parent in the UI.
   - View genotype labels and phenotype images update in real time.
2. **Simulation Mode**:
   - After setting parental genotypes, run the simulation.
   - Review sorted genotype/phenotype tables and raw offspring list.
   - Compare observed vs. theoretical probabilities.

## Technical Notes
- **State tracking arrays** (`memXX`, `gXX`) manage allele selection order and values.
- **Validation logic** ensures only valid genotypes are possible.
- **Phenotype determination** is based on dominance rules.
- **Simulation engine**:
  - Generates gametes for each parent.
  - Combines gametes to form all possible offspring genotypes.
  - Maps genotypes to phenotypes.
  - Tallies counts and calculates probabilities.

## Known Limitations
- Models only simple dominant/recessive inheritance.
- Trait set is fixed in the current version.
- No linkage, incomplete dominance, or polygenic traits.

## Screenshot
<img width="1919" height="1100" alt="image" src="https://github.com/user-attachments/assets/833e4826-df44-4216-8c39-acb04204864b" />

## Credits
- **Developer:** Iia Viacheslavovich Landakov  
- Inspired by classical Mendelian genetics experiments.
