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
        protected float          _zoom; // Camera Zoom
        public Matrix             _transform; // Matrix Transform
        public Vector2          _pos; // Camera Position
        protected float         _rotation; // Camera Rotation

        const float worldWidth = 1920;
        const float worldHeight = 1080;
 
        public void Camera2d()
        {
            _zoom = 0.0f;
            _rotation = 0.0f;
            _pos = Vector2.Zero;
        }

        // Sets and gets zoom
        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } // Negative zoom will flip image
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        // Auxiliary function to move the camera
        public void Move(Vector2 amount)
        {
            _pos += amount;
        }
        // Get set position
        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.0f, graphicsDevice.Viewport.Height * 0.0f, 0));
            return _transform;
        }

        public void UpdateCameraInput(GraphicsDevice graphicsDevice)
        {
            KeyboardState currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();



            if (Keyboard.GetState().IsKeyDown(Keys.W) == true)
            {
                if (_pos.Y <= 0)
                {

                }
                else
                {
                    _pos.Y = Pos.Y + -1;
                }

            }
            if (Keyboard.GetState().IsKeyDown(Keys.S) == true)
            {
                if ((graphicsDevice.Viewport.Height / Zoom) >= worldHeight - _pos.Y)
                {

                }
                else
                {
                    _pos.Y = Pos.Y + 1;
                }

            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) == true)
            {

                if (_pos.X <= 0)
                {

                }
                else
                {
                    _pos.X = Pos.X - 1;
                }
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D) == true)
            {
                if ((graphicsDevice.Viewport.Width / Zoom) >= worldWidth - _pos.X)
                {

                }
                else
                {
                    _pos.X = Pos.X + 1;
                }
            }

            //zoom in
            if (Keyboard.GetState().IsKeyDown(Keys.X) == true)
            {
                if (Zoom <= 5.0f)
                {
                    Zoom = Zoom += 1.1f;
                }
            }

            //zoom out
            if (Keyboard.GetState().IsKeyDown(Keys.Z) == true)
            {
                if (Zoom >= 1.1f)
                {
                    Zoom = Zoom -= 0.1f;
                }
            }
        }

    }
}
