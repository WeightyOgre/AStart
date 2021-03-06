﻿using System;
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
                //move up
                return 1;
            }

            if (currentKeyboardState.IsKeyDown(Keys.S) == true)
            {
                //move down
                return 2;
            }

            if (currentKeyboardState.IsKeyDown(Keys.A) == true)
            {
                //move left
                return 3;
            }

            if (currentKeyboardState.IsKeyDown(Keys.D) == true)
            {
                //move right
                return 4;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Z) == true)
            {
                //zoom in
                return 5;
            }

            if (currentKeyboardState.IsKeyDown(Keys.X) == true)
            {
                //zoom out
                return 6;
            }

            return 0;
        }

    }
}
