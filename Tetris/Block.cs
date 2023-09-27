﻿using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum BlockType
    {
        I,
        L,
        J,
        S,
        Z,
        O,
        T
    }

    public class Block
    {
        public BlockType BlockShape { get; set; }
        public Image Texture { get; private set; }
        public int[,] CurrentMatrix { get; private set; }
        public int[,][] Rotations { get; private set; }

        public Block()
        {
            Random random = new Random();
            BlockShape = (BlockType)random.Next(0, Enum.GetValues(typeof(BlockType)).Length);
            AssignTextureAndMatrix();
        }

        public void DisplayBlock(PictureBox[,] gameGrid, int startX, int startY)
        {
            for (int y = 0; y < CurrentMatrix.GetLength(0); y++)
            {
                for (int x = 0; x < CurrentMatrix.GetLength(1); x++)
                {
                    int gridX = startX + x;
                    int gridY = startY + y;

                    if (CurrentMatrix[y, x] == 1 && gridX >= 0 && gridX < 10 && gridY >= 0 && gridY < 20)
                    {
                        PictureBox pictureBox = gameGrid[gridX, gridY];
                        pictureBox.Image = Texture;
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                }
            }
        }

        private void AssignTextureAndMatrix()
        {
            switch (BlockShape)
            {
                case BlockType.I:
                    Texture = Properties.Resources.TileCyan;
                    CurrentMatrix = new int[,]
                    {
                        { 0, 1, 0 },
                        { 0, 1, 0 },
                        { 0, 1, 0 },
                        { 0, 1, 0 }
                    };
                    break;
                case BlockType.J:
                    Texture = Properties.Resources.TileBlue;
                    CurrentMatrix = new int[,]
                    {
                        { 0, 0, 1 },
                        { 0, 0, 1 },
                        { 0, 1, 1 },
                    };
                    break;
                case BlockType.L:
                    Texture = Properties.Resources.TileOrange;
                    CurrentMatrix = new int[,]
                    {
                        { 1, 0, 0 },
                        { 1, 0, 0 },
                        { 1, 1, 0 },
                        
                    };
                    break;
                case BlockType.O:
                    Texture = Properties.Resources.TileYellow;
                    CurrentMatrix = new int[,]
                    {
                        { 1, 1},
                        { 1, 1},
                    };
                    break;
                case BlockType.S:
                    Texture = Properties.Resources.TileGreen;
                    CurrentMatrix = new int[,]
                    {
                        { 0, 1, 1 },
                        { 1, 1, 0 },
                    };
                    break;
                case BlockType.T:
                    Texture = Properties.Resources.TilePurple;
                    CurrentMatrix = new int[,]
                    {
                        { 1, 1, 1 },
                        { 0, 1, 0 },
                    };
                    break;
                case BlockType.Z:
                    Texture = Properties.Resources.TileRed;
                    CurrentMatrix = new int[,]
                    {
                        { 1, 1, 0 },
                        { 0, 1, 1 },
                    };
                    break;
                default:
                    break;
            }
        }
    }
}

