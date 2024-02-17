This repository contains a collection of C# scripts tailored for Unity 2D game development. Each script serves a specific purpose in managing various aspects of the game's functionality.

1.  **Player.cs**: Defines player character behavior, including movement using Rigidbody2D, animator parameter updates for animations, and interaction with collidable objects.

2. **CameraMotor.cs**: Controls camera movement in the scene, ensuring it follows a target within specified bounds along the X and Y axes.

3. **Portal.cs**: Defines portal behavior, allowing the player to teleport to another scene upon collision. Target scene is specified within the script.

4. **Chest.cs**: Defines chest behavior, allowing it to be collected by the player, updating its sprite upon collection, and displaying collected coins with floating text.

5. **Colletable.cs**: Serves as a base class for collectible objects, handling collision detection with the player and marking objects as collected.

6. **Collidable.cs**: Defines a base class for objects capable of colliding with others, offering functionality for collision detection and handling.

7. **FloatingText.cs**: Manages floating text objects in the game, including creation, activation, deactivation, and updating of position and duration.

8. **FloatingTextManager.cs**: Manages creation and display of floating text in the game world, offering customization options such as message, font size, color, and motion.

9. **GameManager.cs**: Serves as the central manager for game logic and state, handling resources, player data, saving/loading game state, displaying floating text, and teleporting the player through portals.

   
