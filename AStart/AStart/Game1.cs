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

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
        }

        protected override void Initialize()
        {
            
            
            cam = new Camera2D();

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

            cam.UpdateCameraInput(GraphicsDevice);

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
                        cam.get_transformation(GraphicsDevice));

            spriteBatch.Draw(aTexture, new Vector2(500, 200), Color.Red);
            spriteBatch.Draw(aTexture, aTexturePosition, Color.Black);
                        
            spriteBatch.Draw(backgroundTexture, backgroundTexturePosition, Color.White);
            
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
