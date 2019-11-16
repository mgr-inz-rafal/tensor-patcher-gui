using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tensor_patcher_gui {
    class ButtonTag {
        public int X;
        public int Y;
        public int Index;
        public byte? CaveByte;

        public ButtonTag(int x, int y, int index = -1, byte? caveByte = null) {
            X = x;
            Y = y;
            Index = index;
            CaveByte = caveByte;
        }
    };
}
