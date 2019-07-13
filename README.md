# Sorting Layer Character Manager for Unity 2D

It's a simple asset, it lets you manage the layers belonging to parts of a 2D character. That is, it is a Sorting Layers manager for 2D characters. I realized that this would make it easier for me to work with the "Anima2D" asset, having to clean up layer by layer of a character wasted a lot of time, so I ended up making this tool simple and useful. I will update the pertinent information to this asset over time, I hope I have helped.

Unity Version: 2019.3.0a7.

Asset Anima2D Version: 1.1.7 2019-05-23.

# Operation:

The script is applied to the child object of the character object, the name of that object is "mesh", it contains the sprites of the character that make up the body of it. The script is responsible for organizing in which layer each part of the character will belong and the Sorting Layer that the whole character will belong to, each part of the character is separated by its type, arm, leg ... All this is executed through button that can be pressed in the "Inspector".
