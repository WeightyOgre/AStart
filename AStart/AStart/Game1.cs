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
            float zoomSpeed = 0.5f;

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
            graphics.IsFullScreen = true;
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

            if (Keyboard.GetState().IsKeyDown(Keys.Escape) == true)
            {
                this.Exit();
            }
            
            cam.moveCamera(input.getCameraInput());
                      
            updateMouse();

            base.Update(gameTime);
        }

        public void updateMouse()
        {
            switch (input.getMouseInput())
            {
                case 1:
                    aColor = Color.Black;
                    Rectangle mouseClickArea = new Rectangle(cam.camera_World_ConversionX(input.MousePositionX), cam.camera_World_ConversionY(input.MousePositionY), Convert.ToInt32(20 / cam.Zoom), Convert.ToInt32(20 / cam.Zoom));
                
                    Rectangle textureRectangle = new Rectangle(Convert.ToInt32(mouseTexturePosition.X),Convert.ToInt32(mouseTexturePosition.Y),aTexture.Width,aTexture.Height);
                    
                    if (mouseClickArea.Intersects(textureRectangle))
                    {
                        mouseTexturePosition.X = cam.camera_World_ConversionX(input.MousePositionX);
                        mouseTexturePosition.Y = cam.camera_World_ConversionY(input.MousePositionY);
                    }
                    break;
                case 2:
                    anotherColor = Color.Black;
                    break;
                case 3:
                    yetAnotherColor = Color.Black;
                    break;
                default:
                    aColor = Color.Red;
                    anotherColor = Color.Red;
                    yetAnotherColor = Color.Red;
                    break;
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

            //SpriteBatch testBatch = new SpriteBatch(GraphicsDevice);
            //testBatch.Begin();
            //testBatch.DrawString(Font1,
                                //"Mouse X value = " + Convert.ToInt32((mouseState.X / cam.Zoom)) +
                                //"| Test = " + cam.CameraOffsetX +
                                //"| Mouse X + Test =" + Convert.ToInt32((mouseState.X / cam.Zoom) + cam.CameraOffsetX) +
                                //"| Mouse Y = " + Convert.ToInt32((mouseState.Y / cam.Zoom)) +
                                //"| Test2 = " + cam.CameraOffsetY +
                                //"| Mouse Y + Test 2 = " + Convert.ToInt32((mouseState.Y / cam.Zoom) + cam.CameraOffsetY),
                                //new Vector2(100, 100),
                                //Color.Black);
            //testBatch.End();

            base.Draw(gameTime);
        }
    }
}
