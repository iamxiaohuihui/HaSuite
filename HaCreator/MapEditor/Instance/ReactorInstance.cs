﻿using HaCreator.MapEditor.Info;
using MapleLib.WzLib.WzStructure.Data;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNA = Microsoft.Xna.Framework;

namespace HaCreator.MapEditor.Instance
{
    public class ReactorInstance : BoardItem, IFlippable
    {
        private ReactorInfo baseInfo;
        private int reactorTime;
        private bool flip;
        private string name;

        public ReactorInstance(ReactorInfo baseInfo, Board board, int x, int y, int reactorTime, string name, bool flip)
            : base(board, x, y, -1)
        {
            this.baseInfo = baseInfo;
            this.reactorTime = reactorTime;
            this.flip = flip;
            this.name = name;
            if (flip)
                X -= Width - 2 * Origin.X;
        }

        public override void Draw(SpriteBatch sprite, XNA.Color color, int xShift, int yShift)
        {
            XNA.Rectangle destinationRectangle = new XNA.Rectangle((int)X + xShift - Origin.X, (int)Y + yShift - Origin.Y, Width, Height);
            //if (baseInfo.Texture == null) baseInfo.CreateTexture(sprite.GraphicsDevice);
            sprite.Draw(baseInfo.GetTexture(sprite), destinationRectangle, null, color, 0f, new XNA.Vector2(0f, 0f), Flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 1f);
            base.Draw(sprite, color, xShift, yShift);
        }

        public override MapleDrawableInfo BaseInfo
        {
            get { return baseInfo; }
        }

        public bool Flip
        {
            get
            {
                return flip;
            }
            set
            {
                if (flip == value) return;
                flip = value;
                int xFlipShift = Width - 2 * Origin.X;
                if (flip) X -= xFlipShift;
                else X += xFlipShift;
            }
        }

        public int UnflippedX
        {
            get
            {
                return flip ? (X + Width - 2 * Origin.X) : X;
            }
        }

        public override ItemTypes Type
        {
            get { return ItemTypes.Reactors; }
        }

        public override System.Drawing.Bitmap Image
        {
            get
            {
                return baseInfo.Image;
            }
        }

        public override int Width
        {
            get { return baseInfo.Width; }
        }

        public override int Height
        {
            get { return baseInfo.Height; }
        }

        public override System.Drawing.Point Origin
        {
            get
            {
                return baseInfo.Origin;
            }
        }

        public int ReactorTime
        {
            get { return reactorTime; }
            set { reactorTime = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
