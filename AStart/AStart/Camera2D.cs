using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AStart
{
    class Camera2D
    {
        //camera variables
        protected float          zoom; // Camera Zoom
        public Matrix             transform; // Matrix Transform
        public Vector2          pos; // Camera Position
        protected const float rotation = 0.0f; // Camera Rotation
        protected float cameraSpeed;
        protected float maxZoom;
        protected float minZoom;
        protected float zoomSpeed;

        //world variables
        protected float worldWidth;
        protected float worldHeight;
        protected float minWorldWidth;
        protected float minWorldHeight;

        public Camera2D()
        {
            //camera 
            Zoom = 1f;
            cameraSpeed = 1f;
            maxZoom = 5.0f;
            minZoom = 1.1f;
            zoomSpeed = 2.1f;

            //world
            worldWidth = 1920;
            worldHeight = 1080;
            minWorldWidth = 0;
            minWorldHeight = 0;
        }

        // Sets and gets zoom
        public float Zoom
        {
            get { return zoom; }
            set { zoom = value; } // Negative zoom will flip image
        }

        // Get set position
        public Vector2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0)) *
                                         Matrix.CreateRotationZ(rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.0f, graphicsDevice.Viewport.Height * 0.0f, 0));
            return transform;
        }

        public void UpdateCameraInput(GraphicsDevice graphicsDevice)
        {
            KeyboardState currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //move up
            if (Keyboard.GetState().IsKeyDown(Keys.W) == true)
            {
                if (pos.Y > minWorldHeight)
                {
                    pos.Y = Pos.Y - cameraSpeed;
                }
            }
            //move down
            if (Keyboard.GetState().IsKeyDown(Keys.S) == true)
            {
                if ((graphicsDevice.Viewport.Height / Zoom) < worldHeight - pos.Y)
                {
                    pos.Y = Pos.Y + cameraSpeed;
                }
            }
            //move left
            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {
                if (pos.X > minWorldWidth)
                {
                    pos.X = Pos.X - cameraSpeed;
                }
            }
            //move right
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                if ((graphicsDevice.Viewport.Width / Zoom) < worldWidth - pos.X)
                {
                    pos.X = Pos.X + cameraSpeed;
                }
            }
            //zoom in
            if (Keyboard.GetState().IsKeyDown(Keys.X) == true)
            {
                if (Zoom <= maxZoom)
                {
                    Zoom = Zoom += zoomSpeed;
                }
            }
            //zoom out
            if (Keyboard.GetState().IsKeyDown(Keys.Z) == true)
            {
                if (Zoom >= minZoom)
                {
                    Zoom = Zoom -= zoomSpeed;
                }
            }
        }

    }
}
