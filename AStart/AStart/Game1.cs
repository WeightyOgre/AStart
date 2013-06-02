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
        Texture2D backgroundTexture;

        Camera2D cam;

        //handles all game input
        Input input;

        Color aColor;
        Color anotherColor;
        Color yetAnotherColor;

        //text output for testing purposes
        SpriteFont Font1;

        MouseState mouseState;

        Vector2 mouseTexturePosition;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            //screen resolution
            int viewportWidth = 1920;
            int viewportHeight = 1080;
            
            //pass the camera2d constructor the following values for behaviour
            //camera 
            float Zoom = 1f;
            float cameraSpeed = 1f;
            float maxZoom = 5.0f;
            float minZoom = 1.1f;
            float zoomSpeed = 1.1f;

            //world
            float worldWidth = 1920;
            float worldHeight = 1080;
            float minWorldWidth = 0;
            float minWorldHeight = 0;

            //create the camera passing in the values
            cam = new Camera2D(Zoom, cameraSpeed, maxZoom, minZoom, zoomSpeed, worldWidth, worldHeight, minWorldWidth, minWorldHeight, viewportWidth, viewportHeight);

            //create the input object
            input = new Input();

            //set up the viewport to match screen resolution and set to full screen
            graphics.PreferredBackBufferWidth = viewportWidth;
            graphics.PreferredBackBufferHeight = viewportHeight;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            this.IsMouseVisible = true;

            aColor = new Color();
            anotherColor = new Color();
            yetAnotherColor = new Color();

            mouseTexturePosition = new Vector2(0,0);
            
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            aTexture = Content.Load<Texture2D>("blank20x20");
            backgroundTexture = Content.Load<Texture2D>("background1920x1080");

            Font1 = Content.Load<SpriteFont>("SpriteFont1");
        }

        protected override void Update(GameTime gameTime)
        {
            cam.moveCamera(input.getCameraInput());

            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }
                       
            updateMouse();

            base.Update(gameTime);
        }

        public void updateMouse()
        {
            mouseState = Mouse.GetState();

            //left mouse click
            if (mouseState.LeftButton == ButtonState.Pressed && mouseState.RightButton == ButtonState.Released)
            {
                aColor = Color.Black;
                Rectangle mouseClickArea = new Rectangle(Convert.ToInt32(mouseState.X / cam.Zoom), Convert.ToInt32(mouseState.Y /cam.Zoom), Convert.ToInt32(20/cam.Zoom),Convert.ToInt32(20/cam.Zoom));
                
                Rectangle textureRectangle = new Rectangle(Convert.ToInt32(mouseTexturePosition.X),Convert.ToInt32(mouseTexturePosition.Y),aTexture.Width,aTexture.Height);
                if (mouseClickArea.Intersects(textureRectangle))
                {
                    mouseTexturePosition.X = mouseState.X/cam.Zoom;
                    mouseTexturePosition.Y = mouseState.Y/cam.Zoom;
                }
            }
            //right mouse click
            else if (mouseState.RightButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Released)
            {
                anotherColor = Color.Black;
            }
            //both right mouse button and left mouse button
            else if (mouseState.RightButton == ButtonState.Pressed && mouseState.LeftButton == ButtonState.Pressed)
            {
                yetAnotherColor = Color.Black;
            }
            else
            {
                aColor = Color.Red;
                anotherColor = Color.Red;
                yetAnotherColor = Color.Red;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        cam.get_transformation());

            spriteBatch.Draw(backgroundTexture, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(aTexture, new Vector2(500, 200), aColor);
            spriteBatch.Draw(aTexture, new Vector2(540, 200), anotherColor);
            spriteBatch.Draw(aTexture, new Vector2(580, 200), yetAnotherColor);
            spriteBatch.Draw(aTexture, mouseTexturePosition, Color.Black);
            spriteBatch.End();

            SpriteBatch testBatch = new SpriteBatch(GraphicsDevice);
            testBatch.Begin();
            testBatch.DrawString(Font1,
                                "Mouse X value = " + (mouseState.X / cam.Zoom) +
                                " Mouse Y = " + (mouseState.Y / cam.Zoom),
                                new Vector2(100, 100),
                                Color.Black);
            testBatch.End();


            base.Draw(gameTime);
        }
    }
}
