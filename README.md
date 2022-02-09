CS455 Module 1 PR4: Flocking++  
Author: Georgiy Antonovich Bondar

Go to https://keshakot.github.io/CS455_M1.PR4/ to play the game :)

# Behaviors
Flocking: Assets/Scripts/Flocker_Improved.cs  
 
# Game rules:
1. Use WASD or arrow keys to move the character.   
2. Press 't' to teleport.   
3. Press 'r' to reset the game.   
4. Red obstacles will flock to the player, avoiding themselves and obstacles as best as possible.   

# Improvements from DV4:
1. Flockers now use two-tiered prioritization, with obstacle avoidance having priority.    
2. Flockers now find themselves programatically via. the 'Flocker' GameObject tag.   

# Issues/bugs:
1. Flockers will 'step over each other' as they avoid obstacles, since that behavior overrides their separation group. Left this in on purpose, looks kind of neat.   
2. Since BlendedSteering multiplies the net acceleration by maxAcceleration, epsilon (in PrioritySteering) might as well be set to 0.  

