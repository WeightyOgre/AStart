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

        Camera2D cam;

        //handles all game input
        Input input;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            input = new Input();
        }

        protected override void Initialize()
        {
            //pass the camera2d constructor the following values for behaviour
            //camera 
            float Zoom = 1f;
            float cameraSpeed = 1f;
            float maxZoom = 5.0f;
            float minZoom = 1.1f;
            float zoomSpeed = 2.1f;

            //world
            float worldWidth = 1920;
            float worldHeight = 1080;
            float minWorldWidth = 0;
            float minWorldHeight = 0;
            cam = new Camera2D(Zoom, cameraSpeed, maxZoom, minZoom, zoomSpeed, worldWidth, worldHeight, minWorldWidth, minWorldHeight, GraphicsDevice);

            aTexturePosition = new Vector2(0, 0);
                         
            backgroundTexturePosition = new Vector2(0, 0);

            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aTexture = Content.Load<Texture2D>("blank20x20");
            backgroundTexture = Content.Load<Texture2D>("background1920x1080");
        }

        protected override void Update(GameTime gameTime)
        {
            cam.moveCamera(input.getCameraInput());
            //cam.updatePosition();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Texture,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        cam.get_transformation());

            spriteBatch.Draw(aTexture, new Vector2(500, 200), Color.Red);
            spriteBatch.Draw(aTexture, aTexturePosition, Color.Black);
                        
            spriteBatch.Draw(backgroundTexture, backgroundTexturePosition, Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
