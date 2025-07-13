1. Stat system. Not too complicated, the player should have health and a Hunger Meter. TEST by having ActiveScript Reduce and raise stats via PUBLIC FUNCTIONS. We should be able to see the effects on the screen with some basic UI.

2. Make the flashcard storage system. A place to store flashcards, and a way for the user to put in their own flashcards. Features include: Place to store flashcards (flashcards should have data for Title, photo path, description, reward, punishment, and either the options for multiple choice, the answer for fill the blank, or the answer for true or false), modularity to add different ways of inserting new flashcards, ability to delete flashcards, ability to have multiple flashcard groups, and (optional) a way to add flashcards via the user. TEST by having ActiveScript place contents into flashcards via PUBLIC FUNCTIONS and print flashcard info to debug.

3. Setup Card Quizzing: Card can quiz you with multiple choice or fill the blank or true or false (things the game can immediately check if correct or not). Card can give rewards and give punishments based on the answer given (restricted to gain/lose hunger or health for now). Card will need to be able to display text and an image taken from the flashcard data itself. Include a public function that, when run it displays the card fully up at the camera, the back of the card showing, with a click from the user, the card is revealed, and then you are quizzed, which runs its own function, and disappears. TEST by having ActiveScript run both PUBLIC FUNCTIONS, one where it does the whole animations and such, and one that just does the quiz, which should just make the card appear without the dramatics.

4. Create a tile prefab, including a script on it that contains public functions that other code can run for:
a) Flipping the tile over without the dramatics of it coming close to the camera.
b) Revealing the tile (AKA it goes close to the screen, and after a click it turns around, if there is a card attached, run that card's reveal function, otherwise (or after the card finishes its thing) run any events for the tile itself, AKA all the dramatics)
c) Flipping back over to hide it.
d) Setting a tile's data (AKA what cards are on it, its own effect, anything that would be revealed). 

Ensure this is designed with good modularity so it's easy to use in the game ecosystem and easy to make edits to. TEST by having ActiveScript test each of a), b), c), d) with PUBLIC FUNCTIONS.

5. Basic Map Grid. A setup that lets you spawn a grid of tiles and have full control over that grid arrangement, AKA how big is the map and where are the tiles (all tiles snapped to grid). The contents of each tile should be an enum so we have the ability to put more there than just "on" or "off" but still easy to use (we need tile types for start and goal as well). TEST by having ActiveScript generate a few maps via PUBLIC FUNCTIONS, it should be able to control size of map and where tiles go, it should also be able to specify exact locations for anything including start spot, treasure, cards, tile events, etc, or leave it blank for full randomness, AKA any info it doesn’t set is random.

6. Set up player and player movement system. Player just needs to be basic square box, ensure movement functions are modular so we can add animation code to them later, and ensure that the PUBLIC FUNCTION for movement takes number of tiles the player can move in the turn as an argument so later we can set the amount of tiles the player can move in one turn (so dice can be used). The player should start on a blank tile. When the player lands on another tile, it should lower hunger and then trigger that tile's function. The player should be allowed to move again once the tile is done triggering (including all its cards), unless the player has lost all hunger or all health, in which case a game over screen should show. TEST by having ActiveScript generate a basic 4x4 grid with the player starting in the center, it should be possible to move around and trigger tiles, be tested by the cards within, and lose due to full loss of hunger or health.

7. Final Setup. Tie everything together to make it a game, ensure there is a way to win, put in the objective. In this version of the game, the player starts somewhere on the board, they must explore the board to find the treasure, and then return to the start area. Add a simple scoring feature where score is given for getting questions right, a big bonus for finding the treasure, and a multiplier of x2 for finishing the whole thing. TEST by having ActiveScript generate a test board and then play the game!!! Ensure you can win or lose, ensure the goal and return work, and ensure the scoring works. Experiment to see if there are more fun ways to score the player.





FUTURE BUILD FEATURES: Create item cards, Create environment tiles, dice.
