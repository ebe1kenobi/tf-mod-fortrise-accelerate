# Accelerate

<img width="882" height="247" alt="image" src="https://github.com/user-attachments/assets/d65e06ba-3834-4584-b1de-4211813a7fa5" />

Speeds up the dead time of a game night: faster gameplay, automatic level pick and
a shortened results screen.

A mod for **FortRise 5** (>= 5.3.3). The FortRise 4 version (`tf-mod-fortrise-accelerate`) is no longer maintained: fixes and new features only land in this repository.

## Installation

1. Install FortRise 5 and start the game through `FortRise.exe`.
2. Copy `release/accelerate` (or the shipped folder) into `<TowerFall>/FortRise/Mods/`.

Settings are under **Options > Mods > Accelerate**.
Data and log files live in `<TowerFall>/FortRise/Saves/Accelerate/` and `<TowerFall>/FortRise/Logs/`.

## Usage

Everything is in the mod settings; there is no variant and no dedicated key.

<img width="730" height="294" alt="image" src="https://github.com/user-attachments/assets/4247ddd4-8299-4114-9c86-45796a500829" />

## Settings

| Setting | Purpose |
|---------|---------|
| Accelerate | turn the speed-up on |
| Acceleration | speed factor, 1 to 20 (5 by default) |
| Select Random Level Auto | pick the tower automatically, skipping the map screen |
| Accelerate the match result screen | jump straight to the end-of-match menu |

## What is actually sped up

**Not the fight.** The mod raises `Engine.TimeRate` in exactly three places, and all three
are the moments where nobody is playing:

| When | What you were waiting for |
|---|---|
| The round results screen | the scores climbing one point at a time |
| Building the end-of-match screen | the transition into it |
| Confirming a rematch | the wind-down before the next match |

A game night loses more time to those three screens put together than to any round, and
none of them is a moment where speed changes the outcome. `Acceleration` is a plain
multiplier: at 5 those screens run five times faster.

`Accelerate the match result screen` goes further and **opens the end-of-match menu
immediately**, tweening the results in behind it, instead of waiting for the screen to
play out before offering the choice.

## The automatic tower pick

`Select Random Level Auto` skips the map screen in **versus** — co-op is left alone. It is
not a coin toss each time: the mod **shuffles all the available towers once and then walks
that order**, so no tower comes up twice before every one has been played.

The list is reshuffled when it stops matching what the map screen offers — a tower pack
installed or removed, a different roster of unlocks — and when the walk reaches the end.
Comparing the shuffled order against what is actually on screen is what keeps it honest:
a remembered order that no longer matches the buttons would pick towers that are not there.

Independently of that setting, the map screen always opens with the **fourth** button
highlighted rather than whatever the game would have selected.

Each pick is written to the log with its coordinates and title, which is the only way to
check afterwards that the cycle really is a cycle.

## Build / deployment

| Script | Purpose |
|--------|---------|
| `script/release.bat` | build, then assemble into `release/` |
| `script/deploy.bat` | copy `release/` into the TowerFall `Mods` folder |
| `script/release_deploy.bat` | both, one after the other |

Paths (game folder, module name) are set in `script/config.bat`.
