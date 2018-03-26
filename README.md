# DazContentInstaller
Daz Freeware Zip Installer. This tool will process archived Daz installers and 
dynamically place contents in correct "data" or "runtime" directory.

### How to Install:
Place executable inside of folder on your PC. The program will generate a folder structure and 
unpack some needed libraries local to itself. i.e. if you just double click it on your desktop, 
you will end up with a pile of random folders / files on your desktop.

### Works With The Following Archive Formats:
 - .zip
 - .rar
 - .7z
 
### Runtime Compatibility:
Expects to find a runtime within your runtime directory called "runtime" (Poser) or "data" (Daz). 
The contents of the installer is searched from the top directories down, to find a folder matching 
either of those. This folder and its sub contents are then copied into your runtime folder at the 
corresponding "runtime" or "data" directory.

### Software Requirments:
 - Windows PC (XP or newer)
 - Microsoft .NET framework 4.5 or newer.
 