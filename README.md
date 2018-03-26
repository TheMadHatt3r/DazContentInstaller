# DazContentInstaller
Daz Freeware Zip Installer. This tool will process archived Daz installers and 
dynamically place contents in correct "data", "runtime" or "people" directory.

### How to Install:
Place executable inside of folder on your PC. The program will generate a folder structure and 
unpack some needed libraries local to itself. i.e. if you just double click it on your desktop, 
you will end up with a pile of random folders / files on your desktop.

### Works With The Following Archive Formats:
 - .zip
 - .rar
 - .7z
 
### Runtime Compatibility:
Expects to find a runtime within your runtime directory called "runtime" (Poser) or "data" (Daz) or "people". 
The contents of the installer is searched from the top directories down, to find a folder matching 
either of those. This directory level and its sub contents are then copied into your runtime folder.

### Software Requirments:
 - Windows PC (XP or newer)
 - Microsoft .NET framework 4.5 or newer.

 
### Change Log
1.1.0 - 2018-03-25
 - Added "people" as another key search word along with "data and "runtime"

1.0.0 - 2018-03-25
 - Yay I work!