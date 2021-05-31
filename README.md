# SolastaLevel20

Attempt to bring all Solasta official heroes classes to level 20.

## Classes:
	- Cleric
		. 11: Turn Undead (CR 2)
		. 12: Ability Score Increase or Feat Choice
		. 14: Turn Undead (CR 3)
		. 16: Ability Score Increase or Feat Choice
		. 17: Turn Undead (CR 4)
		. 17: Divine Domain Feature [PLANNED]
		. 18: Channel Divinity (3/rest)
		. 19: Ability Score Increase or Feat Choice
		. 20: Divine Intervention Improvement [PLANNED]

	- Fighter
		. 11: Extra Attack (2)
		. 12: Ability Score Increase or Feat Choice
		. 13: Indomitable (2)
		. 14: Ability Score Increase or Feat Choice
		. 15: Martial Archetype Feature [PLANNED]
		. 16: Ability Score Increase or Feat Choice
		. 17: Action Surge (2), Indomitable (3)
		. 18: Martial Archetype Feature [PLANNED]
		. 19: Ability Score Increase or Feat Choice
		. 20: Extra Attack (3)

	- Paladin
		. 11: Improved Divine Smite
		. 12: Ability Score Increase or Feat Choice
		. 14: Cleasing Touch [PLANNED]
		. 15: Sacred Oath Feature [PLANNED]
		. 16: Ability Score Increase or Feat Choice
		. 18: Aura Improvements [PLANNED]
		. 19: Ability Score Increase or Feat Choice
		. 20: Sacred Oath Feature [PLANNED]

	- Ranger
		. 11: Ranger Archetype Feature [PLANNED]
		. 12: Ability Score Increase or Feat Choice
		. 14: Favored Enemy Choice (2), Vanish
		. 15: Ranger Archetype Feature [PLANNED]
		. 16: Ability Score Increase or Feat Choice
		. 18: Feral Senses [PLANNED]
		. 19: Ability Score Increase or Feat Choice
		. 20: Foe Slayer [PLANNED]

	- Rogue
		. 10: Ability Score Increase or Feat Choice
		. 11: Reliable Talent [PLANNED]
		. 12: Ability Score Increase or Feat Choice
		. 13: Roguish Archetype Feature [PLANNED]
		. 14: Blindsense [PLANNED]
		. 15: Slippery Minds [PLANNED]
		. 16: Ability Score Increase or Feat Choice
		. 17: Roguish Archetype Feature [PLANNED]
		. 18: Elusive [PLANNED]
		. 19: Ability Score Increase or Feat Choice
		. 20: Stroke of Luck [PLANNED]

	- Wizard
		. 12: Ability Score Increase or Feat Choice
		. 14: Overchannel [PLANNED]
		. 16: Ability Score Increase or Feat Choice
		. 18: Spell Mastery [PLANNED]
		. 19: Ability Score Increase or Feat Choice
		. 20: Signature Spells [PLANNED]

## Spells:

These spells were added at higher levels but still need to hack the Character Panel to offer them.

	- Cleric:
		. 06: Contagion
		. 06: Dispel Evil and Good
		. 06: Flame Strike
		. 06: Greater Restoration
		. 06: Insect Plague
		. 06: Mass Cure Wounds
		. 06: Raise Dead

	- Paladin:
		. 04: Banishement
		. 04: Death Ward
		. 05: Dispel Evil and Good
		. 05: Raise Dead

	- Ranger:
		. 04: Conjure Elemental
		. 04: Freedom of Movement
		. 04: Stoneskin


## Features:

	- As close as possible to SRD if it makes sense in a cRPG. [PLANNED]

## Current Patches:

	- Game Manager - Safe entry point to extend / patch the game databases
	- Characters Panel - Patched hard-coded test for level 10 on LevelUp button
	- New Adventure Panel - Patched to remove constrainsts on min/max heroes levels when starting an adventure
	- User Loccation Settings Modal - Patched to allow higher-level dungeons to be created

# How to Compile

0. Install all required development pre-requisites:
	- [Visual Studio 2019 Community Edition](https://visualstudio.microsoft.com/downloads/)
	- [.NET "Current" x86 SDK](https://dotnet.microsoft.com/download/visual-studio-sdks)
1. Download and install [Unity Mod Manager (UMM)](https://www.nexusmods.com/site/mods/21)
2. Execute UMM, Select Solasta, and Install
3. Download and install [SolastaModApi](https://www.nexusmods.com/solastacrownofthemagister/mods/48) using UMM
4. Create the environment variable *SolastaInstallDir* and point it to your Solasta game home folder
	- tip: search for "edit the system environment variables" on windows search bar
5. Use "Install Release" or "Install Debug" to have the Mod installed directly to your Game Mods folder

NOTE Unity Mod Manager and this mod template make use of [Harmony](https://go.microsoft.com/fwlink/?linkid=874338)

# How to Debug

1. Open Solasta game folder
	* Rename Solasta.exe to Solasta.exe.original
	* Rename UnityPlayer.dll to UnityPlayer.dll.original
	* Add below entries to *Solasta_Data\boot.config*:
		```
		wait-for-managed-debugger=1
		player-connection-debug=1
		```
2. Download and install [7zip](https://www.7-zip.org/a/7z1900-x64.exe)
3. Download [Unity Editor 2019.4.19](https://download.unity3d.com/download_unity/ca5b14067cec/Windows64EditorInstaller/UnitySetup64-2019.4.19f1.exe)
4. Open Downloads folder
	* Right-click UnitySetup64-2019.4.1f1.exe, 7Zip -> Extract Here
	* Navigate to Editor\Data\PlaybackEngines\windowsstandalonesupport\Variations\win64_development_mono
		* Copy *UnityPlayer.dll* and *WinPixEventRuntime.dll* to clipboard
	* Navigate to the Solasta game folder
		* Rename *UnityPlayer.dll* to *UnityPlayer.dll.original*
		* Paste *UnityPlayer.dll* and *WinPixEventRuntime.dll* from clipboard
5. You can now attach the Unity Debugger from Visual Studio 2019, Debug -> Attach Unity Debug

# How to publish (first time)

1. Create a new repo on GitHub on Browser UI
2. Run CREATE_SOLASTA_MOD.PS1 on my computer to get template and first commit to Repo
3. Develop / Test the Mod
4. Create new hidden Mod on Nexus page with minimum required entries. Get Nexus URL
5. Edit version entries on CSPROJ, Info.json, and Repository.json (I always start with 0.0.1)
6. Edit Info.json and fix Nexus URL
7. Release Mod on GitHub using Vx.y.z as TAG/RELEASE convention (I always start with V0.0.1)
8. Update Nexus page with download file and set mod to unhidden

# How to publish (update)

1. Develop / Test the Mod
2. Edit version entries on CSPROJ, Info.json, and Repository.json
3. Update DownloadURL on Repository.json
4. Release Mod on GitHub using Vx.y.z as TAG/RELEASE convention
5. Update Nexus page with new release