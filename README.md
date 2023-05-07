# PixelsSorted
PixelsSorted is a command line based pixel sorter.

*Pixel sorting is the act of sorting each row or collumn of an image. E.g by hue, saturation, brightness.*

## Getting Started
The sorter can be used in 2 different ways: By running the executable, or via program arguments. If program arguments are supplied, the sorter will only execute once and sort a single image (subject to change). Vice versa, when none are supplied, the application will continue to run and request input until closed. 

### To sort an image using the default settings:

*Run the executable and enter the file path to your image. The image will be saved in the same directory as the executable (also subject to change)*

##### *OR*

*Start your command line shell of choice in the same directory as the PixelsSorted.exe. Then run "PixelsSorted.exe \<path-to-image\>"*

The syntax for sorting images is as follows, "\<path-to-image\> \<args\>" and by default, the sorter will sort vertically, smallest to largest, by hue. For a list of all the optional arguments please see below.

## Optional Arguments
Arguments can be passed in any order and are not case sensitive(v2.1+).

Note: Any additional arguments for the same setting will override previous arguments.
E.g: "image.png -sat -h -hue", the image will be sorted by hue and not by saturation

### Sorting Values:
-hue: Sorts pixels based on their hue
 
-sat: Sorts pixels based on their saturation
 
-brt: sorts pixels based on their brightness

### Sorting Order:
-stl: Sorts pixels in order of smallest value to largest value

-lts: Sorts pixels in order of largest value to smallest value

### Sorting Direction:
-h: Sorts image horizontally (rows of pixels)

-v: Sorts image vertically (columns of pixels)
