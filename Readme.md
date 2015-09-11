********************************************************
 THE 4CHAN CUP AUTOMATED AUTISM TASK FORCE SAVE CHECKER
********************************************************

The ***autoATF*** is an automated save/export checker and comparer.

This tool allows managers to check their team against the current tournament ruleset to ensure they are compliant. Any inconsistencies are highlighted allowing the user to adjust their team back within regulation.

It also contains a compare function that allows managers to verify the differences between two saves or exports. This can be useful for managers who wish to ensure their daily export does not contain any changes that would lead to it being disqualified.

* autoATF currently supports both ***EDIT.bin*** save files, and ***TEXPORT.bin*** team export files.

* autoATF is a Windows application and will not function under Linux or MacOS. It's assumed that if you have PES, you have a Windows install available.

* autoATF is Open Source and respects your freedums.

# Modes
autoATF has two modes, ***checker*** and ***compare***.

***Checker Mode*** is where the autoATF will take a team and apply the current tournament's ruleset against it. If any inconsistencies are found, they will be flagged as errors, and the exact problem displayed to the user. If a team returns zero errors, then they are fully compliant and ready for tournament use.

You can enter Checker Mode by only providing a single .bin file within autoATF.ini - at the **input.bin** option.

***Compare Mode*** is where the autoATF will take two exports/saves and compare a team that is within each. This allows the user to check if there are any differences between the two saves.

You can enter Compare Mode by providing a second .bin file within autoATF.ini - at the **compare.bin** option.

autoATF will alert the user as to what mode it is entering upon startup.

# How To Use

autoATF supports both ***save*** files (EDIT.bin) and ***export*** files (TEXPORT.bin). You can provide either to the autoATF via the ini file, and the program will detect which it is and unpack accordingly.

The files must be located within the same directory as autoATF.

Remember that if you want to use Checker Mode, you must leave the compare.bin option blank. Having a filename there will put the program into Compare Mode.

## Checker Mode
If you provide a ***save*** file to the autoATF, you will be prompted to enter the name of the team you wish to check. Enter the board name without slashes and hit enter.

The program will then fetch that team from the save and check it. Each player will be listed in turn as it is checked, and any errors listed. A total error count is stated at the end.

autoATF will then reset and allow you to enter another team name.

If you provide an ***export*** file to the autoATF, you will not be prompted for a team name, as there is only one team available - the one in the export. The program will automatically start checking this team and list errors like before.

## Compare Mode
If you provide two .bin files to the autoATF, via the compare.bin option in the ini file, the program will attempt to compare them.

You can provide any combination of save or export (two saves, two exports, save and an export, etc).

If you provide two ***saves***, you will be prompted to enter the name of the team you wish to check. Enter the board name without slashes and hit enter.

The program will then fetch that team from the pair of saves and directly compare them. Any differences between the players will be listed.

If you provide an ***export*** at all, you will not be prompted for a team name, as there is only one team available to check - the one in the export(s).

If you provide two ***exports*** with different teams, autoATF will display an error.

# Limitations

The autoATF currently does not support checking any aspect of a team's tactical setup. This includes formation, tactics, free kick takers, etc. The user will have to ensure these details are correct manually.

# Future Development
* Tactics checker
* GUI
* Linux version