# Sorting Layer Character Manager for Unity 2D (v2019.07.01)

It's a simple asset, it lets you manage the layers belonging to parts of a 2D character. That is, it is a Sorting Layers manager for 2D characters. I realized that this would make it easier for me to work with the "Anima2D" asset, having to clean up layer by layer of a character wasted a lot of time, so I ended up making this tool simple and useful. I will update the pertinent information to this asset over time, I hope I have helped. 

Author: Ary Guilherme Pires Caramez, portfolio: https://www.artstation.com/arycaramez.

Unity Version: 2019.3.0a7.

Asset Anima2D Version: 1.1.7 2019-05-23.

# Operation:

Step 1: Create some sorting layers to be managed as desired in your project.

Step 2: Create an object to store the sprites of the character's parts. Let's call him "father."

Step 3: Add to the 'father' object the control component 'CharPartsControl'.

Step 4: In the 'CharPartsControl' component, select a 'sorting layer', the number of the 'Layer Base', and create a list of tags that will serve to manage the layers of the parts of your character and define a hierarchy for the value of ' layer 'of each tag
(Ex: "sortingLayer = 'midground', layerBase = (-100), tags = {(tag = head, layer = (- 1)), (tag = arms, layer = (- 3)), ...}; ").

Step 5: Include the sprites in to the 'father' object and organize them. Let's call them 'children'.

Step 6: Add to the 'childen' objects the component 'PartControl'.

Step 7: In the 'PartControl' component, reference the renderer control that manages the sorting layer of the sprite, and select one of the tags created for the children and do it with all (ex: "PartControl(tag='arms'); obj.renderer={sortingLayer="midground",layerIndex=(-3)};").

Step 8: Return to the 'father' object and apply the settings, and you will be able to manage all the layers of your character without complications.

Obs: I will make a video tutorial.
