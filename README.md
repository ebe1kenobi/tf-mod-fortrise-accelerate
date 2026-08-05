# Accelerate

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

## Settings

| Setting | Purpose |
|---------|---------|
| Accelerate | turn the speed-up on |
| Acceleration | speed factor |
| Select Random Level Auto | pick the tower automatically, skipping the map screen |
| Accelerate the match result screen | shorten the end-of-match screen |

## Build / deployment

| Script | Purpose |
|--------|---------|
| `script/release.bat` | build, then assemble into `release/` |
| `script/deploy.bat` | copy `release/` into the TowerFall `Mods` folder |
| `script/release_deploy.bat` | both, one after the other |

Paths (game folder, module name) are set in `script/config.bat`.
