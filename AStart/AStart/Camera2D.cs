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

        GraphicsDevice graphicsDevice;

        public Camera2D(float Zoom, float cameraSpeed, float maxZoom, float minZoom, float zoomSpeed, float worldWidth, float worldHeight, float minWorldWidth, float minWorldHeight, GraphicsDevice graphicsDevice)
        {
            //camera 
            this.Zoom = Zoom;
            this.cameraSpeed = cameraSpeed;
            this.maxZoom = maxZoom;
            this.minZoom = minZoom;
            this.zoomSpeed = zoomSpeed;

            //world
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.minWorldWidth = minWorldWidth;
            this.minWorldHeight = minWorldHeight;

            this.graphicsDevice = graphicsDevice;
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

        public Matrix get_transformation()
        {
            transform =       // Thanks to o KB o for this solution
              Matrix.CreateTranslation(new Vector3(-pos.X, -pos.Y, 0)) *
                                         Matrix.CreateRotationZ(rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                         Matrix.CreateTranslation(new Vector3(graphicsDevice.Viewport.Width * 0.0f, graphicsDevice.Viewport.Height * 0.0f, 0));
            return transform;
        }

        public void moveCamera(int direction)
        {
            switch (direction)
            {
                case 1:
                    moveCameraUp();
                    break;
                case 2:
                    moveCameraDown();
                    break;
                case 3:
                    moveCameraLeft();
                    break;
                case 4:
                    moveCameraRight();
                    break;
                case 5:
                    zoomIn();
                    break;
                case 6:
                    zoomOut();
                    break;
                default:
                    //do nothing
                    break;
            }
        }

        public void moveCameraUp()
        {
            //move up
                if (pos.Y > minWorldHeight)
                {
                    pos.Y = Pos.Y - cameraSpeed;
                }
        }

        public void moveCameraDown()
        {
            //move down
                if ((graphicsDevice.Viewport.Height / Zoom) < worldHeight - pos.Y)
                {
                    pos.Y = Pos.Y + cameraSpeed;
                }
        }

        public void moveCameraLeft()
        {
            //move left
                if (pos.X > minWorldWidth)
                {
                    pos.X = Pos.X - cameraSpeed;
                }
        }

        public void moveCameraRight()
        {
            //move right
                if ((graphicsDevice.Viewport.Width / Zoom) < worldWidth - pos.X)
                {
                    pos.X = Pos.X + cameraSpeed;
                }
        }

        public void zoomIn()
        {
            //zoom in
                if (Zoom <= maxZoom)
                {
                    Zoom = Zoom += zoomSpeed;
                }
        }

        public void zoomOut()
        {
            //zoom out
                if (Zoom >= minZoom)
                {
                    Zoom = Zoom -= zoomSpeed;
                }
        }

    }
}
