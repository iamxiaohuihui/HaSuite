﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XNA = Microsoft.Xna.Framework;
using MapleLib.WzLib.WzStructure.Data;
using HaCreator.MapEditor.Instance.Shapes;

namespace HaCreator.MapEditor.Instance.Misc
{
    public class MiscDot : MapleDot
    {
        private MiscRectangle parentItem;

        public MiscDot(MiscRectangle parentItem, Board board, int x, int y)
            : base(board, x, y)
        {
            this.parentItem = parentItem;
        }

        public override XNA.Color Color
        {
            get { return UserSettings.MiscColor; }
        }

        public override XNA.Color InactiveColor
        {
            get { return MultiBoard.MiscInactiveColor; }
        }

        public override ItemTypes Type
        {
            get { return ItemTypes.Misc; }
        }

        protected override bool RemoveConnectedLines
        {
            get { return false; }
        }

        public MiscRectangle ParentRectangle { get { return parentItem; } set { parentItem = value; } }
    }
}
