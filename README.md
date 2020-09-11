# Audiot

Audiot is a reasonably advanced GUI tool for midi generation.  It allows for dynamic and isolated virtual device creation.  Each device can be bound to a channel and XML-configuration (relative to a hardware or software device). MIDI note and control change messages can be built utilizing relative device values.

## Use
![alt text](https://raw.githubusercontent.com/kbdnr/Audiot/master/InUse.gif "Audiot In Use")
[Demo Track](https://spednar.bandcamp.com/track/proj-2)

### General
The system currently requires the selection of a valid midi device for input/output.  Once selected - choosing 'Start' will enable use of the system.

### Input Specification
The system allows for the user to specify chord progression values, color values, inversion values, "stab" length, number of repeats, and per-stab octaves.  The ranges and accepted values work as
- Prog - Number within chord progression, for a pentatonic scale you will have n % 5 "steps". Ex "1,2,2,3,4,5" or the default of "1,2,3,4,5" when left blank
- Color - Allows for a 4th note coloring for a given triad - ideally for adding 9th-style values Ex. "9,11,13"
- Inversion - Allows for the specification of triad inversion. Values accepted 0,1,2.
- Length - "Stab" length in milliseconds Ie "1000,500,250,125,75"
- Repeat - Number of times to repeat generated block of output (a performance counter is shown in the top right corner for remaining "stabs")
- Octave - Specify the root octave of a given triad. Value values of -4 to 4 (it is easy to encounter invalid values here)

### Melodic Walking / String Emulation
Aside from showing the triad values of the generated progressions, each of the four sliders are able to be interacted with as a "string".  You can strum an individual note value or the entire group depending on the mouse positioning.

The ```Play Melody``` option allows for the current scale values to be walked independently on the specified "string".

### Control Change View
When selected, the Device module will rotate to show a control change area. Here a user is able to chose named values for specific control change parameters based on loaded configurations.

Included Configurations
- Blofeld (our favorite)
- Minitaur
- SH-01a

Configurations can be found in ```AudiotLogic/ControlConfigs/```

Selection of the 'Autopatch' option will randomize the control change values within specified ranges, allowing for new synth patches to easily be explored.

### Build
- Restore NuGet dependencies
- Select "Audiot" as the startup program
- Build/Run

### Limitations
There are a lot, but hopefully making this repository public will encourage more support or personal modification possible.
