# PolyPop
Polypop is a topdown shooter game where the objective is to stay alive for as long as possible. Players will be able to navigate across 'islands' to avoid enemies that spawn and chase the player down.

*Intially called Chamber, game name may still be revised in the future.

### How to play?
WASD to move, Click to shoot

### Link to game

- https://play.unity.com/mg/other/polypop-f

## Development Information

Developed by **Kai Chu**

**Current Production Milestone** : First playable

**Link to Game Design Document (GDD)**
- https://docs.google.com/document/d/1uWymNMycJhL1wYhqx9ahRy-Za9BnhF1pWNBBXWnrhhM/edit?usp=sharing

**Link to Classes and Component UML Diagram for GameScene** (Also found in the \Image\Polypop - GameScene UML Diagram) 
- https://lucid.app/lucidchart/85d6d474-f7a8-4492-91fa-a7a88a927107/edit?viewport_loc=-362%2C-340%2C5593%2C2753%2CHWEp-vi-RSFO&invitationId=inv_36af79f3-cbf9-42c7-8e78-6acce73204e2


## Game Development Features
Key components of the game development to showcase knowledge.

- Automatic correction of bullet direction depending on player terrain level and enemy location.
  - Solution involves the use of box colliders existing on a plane above all entities. Raycasts are shot from the player when bullets are fired, using the collider plane,  we can calculate if an entity was hit and where it was located in the actual game.
- Navmesh navigation to guide enemies and move player in 'game' boundaries. 
  - This involves the seperation of walkable and non-walkable paths on the island. Performed by seperating the island into several objects depending on terrain in Blender.
- Enemy, Weapon, and Bullet Game Objects are Scriptable Objects making managing and development easier down the line. 
- Singleton structured HighscoreManager script to create only one Highscore object that obtains and manages stored game data.
  - Management of Unity PlayerPrefs.
- Development of Class and Components UML Diagram for Game Scene
- Usage of UI Components in Unity creating canvases for
  - Menu scenes, Game Overlays (Minimap, Scoreboard), Dynamic Shops, Scoreboards
- Creation of Models in Blender
  - Island, Trees, Crystals, Mine Entrance, Rocks
  
For more detail of game design/development please refer to GDD.