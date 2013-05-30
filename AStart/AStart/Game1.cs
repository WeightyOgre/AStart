using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AStart
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D aTexture;
        Vector2 aTexturePosition;

        Texture2D backgroundTexture;
        Vector2 backgroundTexturePosition;

        Camera2D cam = new Camera2D();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            aTexturePosition = new Vector2(0, 0);
            cam.Pos = new Vector2(0,0);
            cam.Zoom += 1f; 
            backgroundTexturePosition = new Vector2(0, 0);

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aTexture = Content.Load<Texture2D>("blank20x20");
            backgroundTexture = Content.Load<Texture2D>("background1920x1080");
            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {

            UpdateCameraInput();

            base.Update(gameTime);
        }

        protected void UpdateCameraInput()
        {
            KeyboardState currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            

            if (Keyboard.GetState().IsKeyDown(Keys.W) == true)
            {
                if (cam._pos.Y < 0)
                {

                }
                else
                {
                    cam._pos.Y = cam.Pos.Y + -1;
                }
                
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) == true)
            {
                if (cam._pos.Y > 1280)
                {

                }
                else
                {
                    cam._pos.Y = cam.Pos.Y + 1;
                }
                
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                
                if (cam._pos.X < 0)
                {
                    
                }
                else
                {
                    cam._pos.X = cam.Pos.X - 1;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                if (cam._pos.X > 1920)
                {

                }
                else
                {
                    cam._pos.X = cam.Pos.X + 1;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.X) == true)
            {
                cam.Zoom = cam.Zoom += 0.1f; 
            }
            //zoom out
            if (Keyboard.GetState().IsKeyDown(Keys.Z) == true)
            {
                if (cam.Zoom < 1.1f)
                {

                }
                else
                {
                    cam.Zoom = cam.Zoom -= 0.1f;
                }
            }
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin(SpriteSortMode.BackToFront,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        cam.get_transformation(GraphicsDevice));

            // Draw Everything
            // You can draw everything in their positions since the cam matrix has already done the maths for you 

            spriteBatch.Draw(aTexture, aTexturePosition, Color.Black);
            spriteBatch.Draw(aTexture, new Vector2(500.0f, 200.0f), Color.Red);
            spriteBatch.Draw(backgroundTexture, backgroundTexturePosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}