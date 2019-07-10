# Space-Invaders
C# console game based on classic Space Invaders

Usually in every game, the loop looks like this: 
```
For each frame:
  Handle user input
  Update the game's state
  Render the game's state
```
  GameState class contains all the data about the game. Game Score, Location of player, bullets and invaders.
  
  All the information of the current state of the game is stored in this class, then the state is rendered to the UI by this: 
  ```
  void Render(GameState state)
  ```
  Render will put one frame on the screen, and the game state is one frame. It's sort of like screen is a view and game state is its Model, in architectural terms. 
  
  HandleFrame Method will update the gamestate after each frame. HandleFrame works sort of like this: 
  

    GameState HandleFrame (GameState oldState)
    {
        //Handle user input
        //Update locations of all game objects
        //Update Score and no of invaders escaped
        return new GameState(...);
    }

    
So, inside the game loop:
   
```
  while(true){
        var oldState = State;
        State = HandleFrame(oldState);
        Render(State);
    }
```    
    
   Besides handling and rendering the states inside the loop, it also checks whether the game is over or not depending on the gamestate, and also calculates the time for the thread to sleep to maintain 30FPS.
  
   <b>Other Classes: </b>
   
   <b>GameObjects.cs</b> = Parent Class for all Objects in the game i.e., Hero, Bullet, and Invader
   <b>GameBoard.cs </b> = where all the UI drawing happens except for some cases in Game.cs.
   <b>WelcomeScreen.cs</b> = Game Intro and dialogues 
   
   <b> Future Works: </b>
   1. Implement some ASCII animation when the bullet hits the invader
   2. Add the background music and bullet firing sounds. (.NET Core Console app didn't have built in libraries to play the media. So looking for some third-party libarries to implement this.)
   3. Enemy fires bullets too. (Currently, only the player can fire the bullet, enemies come from the top and try to reach the bottom. Like original Space Invaders game, I want to let enemies fire bullets too.)
   4. Introduce different Fighter jets with different features. 
   5. Make game objects bigger and let them take more grid space. 
