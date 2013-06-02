using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace AStart
{
    class Input
    {
        KeyboardState currentKeyboardState;
        
        public int getCameraInput()
        {
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.W) == true)
            {
                //flips game state between game and menu
                return 1;
            }

            if (currentKeyboardState.IsKeyDown(Keys.S) == true)
            {
                //flips game state between game and menu
                return 2;
            }

            if (currentKeyboardState.IsKeyDown(Keys.A) == true)
            {
                //flips game state between game and menu
                return 3;
            }

            if (currentKeyboardState.IsKeyDown(Keys.D) == true)
            {
                //flips game state between game and menu
                return 4;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Z) == true)
            {
                //flips game state between game and menu
                return 5;
            }

            if (currentKeyboardState.IsKeyDown(Keys.X) == true)
            {
                //flips game state between game and menu
                return 6;
            }

            return 0;
        }

    }
}
