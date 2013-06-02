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
        protected int viewportWidth;
        protected int viewportHeight;

        //world variables
        protected float worldWidth;
        protected float worldHeight;
        protected float minWorldWidth;
        protected float minWorldHeight;

        //test 
        int test;
        int test2;

        public Camera2D(float Zoom, float cameraSpeed, float maxZoom, float minZoom, float zoomSpeed, float worldWidth, float worldHeight, float minWorldWidth, float minWorldHeight, int viewportWidth, int viewportHeight)
        {
            //camera 
            this.Zoom = Zoom;
            this.cameraSpeed = cameraSpeed;
            this.maxZoom = maxZoom;
            this.minZoom = minZoom;
            this.zoomSpeed = zoomSpeed;
            this.viewportWidth = viewportWidth;
            this.viewportHeight = viewportHeight;

            //world
            this.worldWidth = worldWidth;
            this.worldHeight = worldHeight;
            this.minWorldWidth = minWorldWidth;
            this.minWorldHeight = minWorldHeight;
            Test = 0;
            Test2 = 0;
        }

        // Sets and gets test
        public int Test
        {
            get { return test; }
            set { test = value; } // Negative zoom will flip image
        }

        // Sets and gets test2
        public int Test2
        {
            get { return test2; }
            set { test2 = value; } // Negative zoom will flip image
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
                                         Matrix.CreateTranslation(new Vector3(worldWidth * 0.0f, worldHeight * 0.0f, 0));
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
                    Test2 -= Convert.ToInt32(cameraSpeed);
                }
        }

        public void moveCameraDown()
        {
            //move down
            if ((viewportHeight / Zoom) < worldHeight - pos.Y)
            {
                pos.Y = Pos.Y + cameraSpeed;
                Test2 += Convert.ToInt32(cameraSpeed);
            }
        }

        public void moveCameraLeft()
        {
            //move left
                if (pos.X > minWorldWidth)
                {
                    pos.X = Pos.X - cameraSpeed;
                    Test -= Convert.ToInt32(cameraSpeed);
                }
        }

        public void moveCameraRight()
        {
            //move right
                if ((viewportWidth / Zoom) < worldWidth - pos.X)
                {
                    pos.X = Pos.X + cameraSpeed;
                    Test += Convert.ToInt32(cameraSpeed);
                }
        }

        public void zoomIn()
        {
            //zoom in
                if (Zoom <= maxZoom)
                {
                    Zoom = Zoom += zoomSpeed;
                }
                updatePosition();
        }

        public void zoomOut()
        {
            //zoom out
                if (Zoom >= minZoom)
                {
                    Zoom = Zoom -= zoomSpeed;
                }

                updatePosition();    

        }

        public void updatePosition()
        {
            //auto updates camera after a zoom out.
            while ((viewportWidth / Zoom) > (worldWidth - pos.X))
            {
                pos.X--;
                Test--;
            }
            while ((viewportHeight / Zoom) > worldHeight - pos.Y)
            {
                pos.Y--;
                Test2--;
            }
            while (pos.X < minWorldWidth)
            {
                pos.X++;
                Test++;
            }
            while (pos.Y < minWorldHeight)
            {
                pos.Y++;
                Test2++;
            }
        }

    }
}
