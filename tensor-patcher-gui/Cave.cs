using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tensor_patcher_gui {
    class Cave {
        public byte[] mapData;
        private String name;

        public Cave(String name) {
            this.Name = name;
        }

        public string Name { get => name; set => name = value; }
    }
}
