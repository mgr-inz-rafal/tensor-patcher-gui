using System.Collections.Generic;
using System.Drawing;

namespace tensor_patcher_gui {
    public class Constants {
        // Map
        public const int MAP_DIMENSION = 12;
        public const int MAP_DATA_BYTE_COUNT = MAP_DIMENSION * MAP_DIMENSION;
        public const int TOTAL_MAP_COUNT = 51;
        public const int TOTAL_MAP_DATA_SIZE = MAP_DATA_BYTE_COUNT * TOTAL_MAP_COUNT;
        public const int TILE_SIZE = 48;

        // Toolbox
        public const int TOTAL_BRICKS = 14;
        public const int TOTAL_BRICK_ROWS = 2;
        public const int TOOLBOX_TILE_SIZE = 42;

        public static Dictionary<int, Bitmap> brownBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05 },
            { 1, Properties.Resources.brick06 },
            { 2, Properties.Resources.brick07 },
            { 3, Properties.Resources.brick08 },
            { 4, Properties.Resources.brick09 },
            { 5, Properties.Resources.brick10 },
            { 6, Properties.Resources.brick11 },
            { 7, Properties.Resources.brick12 },
            { 8, Properties.Resources.brick13 },
            { 9, Properties.Resources.brick14 },
            { 10, Properties.Resources.brick15 },
            { 11, Properties.Resources.brick16 },
            { 12, Properties.Resources.brick17 },
            { 13, Properties.Resources.brick18 },
        };
        public static Dictionary<int, Bitmap> pinkBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05p },
            { 1, Properties.Resources.brick06p },
            { 2, Properties.Resources.brick07p },
            { 3, Properties.Resources.brick08p },
            { 4, Properties.Resources.brick09p },
            { 5, Properties.Resources.brick10p },
            { 6, Properties.Resources.brick11p },
            { 7, Properties.Resources.brick12p },
            { 8, Properties.Resources.brick13p },
            { 9, Properties.Resources.brick14p },
            { 10, Properties.Resources.brick15p },
            { 11, Properties.Resources.brick16p },
            { 12, Properties.Resources.brick17p },
            { 13, Properties.Resources.brick18p },
        };
        public static Dictionary<int, Bitmap> blueBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05b },
            { 1, Properties.Resources.brick06b },
            { 2, Properties.Resources.brick07b },
            { 3, Properties.Resources.brick08b },
            { 4, Properties.Resources.brick09b },
            { 5, Properties.Resources.brick10b },
            { 6, Properties.Resources.brick11b },
            { 7, Properties.Resources.brick12b },
            { 8, Properties.Resources.brick13b },
            { 9, Properties.Resources.brick14b },
            { 10, Properties.Resources.brick15b },
            { 11, Properties.Resources.brick16b },
            { 12, Properties.Resources.brick17b },
            { 13, Properties.Resources.brick18b },
        };
        public static Dictionary<int, Bitmap> amygdalaBricks = new Dictionary<int, Bitmap> {
            { 0, Properties.Resources.brick05a },
            { 1, Properties.Resources.brick06a },
            { 2, Properties.Resources.brick07a },
            { 3, Properties.Resources.brick08a },
            { 4, Properties.Resources.brick09a },
            { 5, Properties.Resources.brick10a },
            { 6, Properties.Resources.brick11a },
            { 7, Properties.Resources.brick12a },
            { 8, Properties.Resources.brick13a },
            { 9, Properties.Resources.brick14a },
            { 10, Properties.Resources.brick15a },
            { 11, Properties.Resources.brick16a },
            { 12, Properties.Resources.brick17a },
            { 13, Properties.Resources.brick18a },
        };
    
        public static string CaveByteToName(byte? b) {
            switch (b) {
                case 1:
                    return "Docent Trzaskowski";
                case 2:
                    return "Amygdala";
                case 131:
                    return "Round obstacle";
                case 132:
                    return "Square obstacle";
            }
            return "A nice brick";
        }

        public static Dictionary<byte, Bitmap> caveByteMap = new Dictionary<byte, Bitmap> {
            { 5, Properties.Resources.brick05 },
            { 5 + 64, Properties.Resources.brick05a },
            { 5 + 64 + 64, Properties.Resources.brick05b },
            { 5 + 64 + 64 + 64, Properties.Resources.brick05p },
            { 6, Properties.Resources.brick06 },
            { 6 + 64, Properties.Resources.brick06a },
            { 6 + 64 + 64, Properties.Resources.brick06b },
            { 6 + 64 + 64 + 64, Properties.Resources.brick06p },
            { 7, Properties.Resources.brick07 },
            { 7 + 64, Properties.Resources.brick07a },
            { 7 + 64 + 64, Properties.Resources.brick07b },
            { 7 + 64 + 64 + 64, Properties.Resources.brick07p },
            { 8, Properties.Resources.brick08 },
            { 8 + 64, Properties.Resources.brick08a },
            { 8 + 64 + 64, Properties.Resources.brick08b },
            { 8 + 64 + 64 + 64, Properties.Resources.brick08p },
            { 9, Properties.Resources.brick09 },
            { 9 + 64, Properties.Resources.brick09a },
            { 9 + 64 + 64, Properties.Resources.brick09b },
            { 9 + 64 + 64 + 64, Properties.Resources.brick09p },
            { 10, Properties.Resources.brick10 },
            { 10 + 64, Properties.Resources.brick10a },
            { 10 + 64 + 64, Properties.Resources.brick10b },
            { 10 + 64 + 64 + 64, Properties.Resources.brick10p },
            { 11, Properties.Resources.brick11 },
            { 11 + 64, Properties.Resources.brick11a },
            { 11 + 64 + 64, Properties.Resources.brick11b },
            { 11 + 64 + 64 + 64, Properties.Resources.brick11p },
            { 12, Properties.Resources.brick12 },
            { 12 + 64, Properties.Resources.brick12a },
            { 12 + 64 + 64, Properties.Resources.brick12b },
            { 12 + 64 + 64 + 64, Properties.Resources.brick12p },
            { 13, Properties.Resources.brick13 },
            { 13 + 64, Properties.Resources.brick13a },
            { 13 + 64 + 64, Properties.Resources.brick13b },
            { 13 + 64 + 64 + 64, Properties.Resources.brick13p },
            { 14, Properties.Resources.brick14 },
            { 14 + 64, Properties.Resources.brick14a },
            { 14 + 64 + 64, Properties.Resources.brick14b },
            { 14 + 64 + 64 + 64, Properties.Resources.brick14p },
            { 15, Properties.Resources.brick15 },
            { 15 + 64, Properties.Resources.brick15a },
            { 15 + 64 + 64, Properties.Resources.brick15b },
            { 15 + 64 + 64 + 64, Properties.Resources.brick15p },
            { 16, Properties.Resources.brick16 },
            { 16 + 64, Properties.Resources.brick16a },
            { 16 + 64 + 64, Properties.Resources.brick16b },
            { 16 + 64 + 64 + 64, Properties.Resources.brick16p },
            { 17, Properties.Resources.brick17 },
            { 17 + 64, Properties.Resources.brick17a },
            { 17 + 64 + 64, Properties.Resources.brick17b },
            { 17 + 64 + 64 + 64, Properties.Resources.brick17p },
            { 18, Properties.Resources.brick18 },
            { 18 + 64, Properties.Resources.brick18a },
            { 18 + 64 + 64, Properties.Resources.brick18b },
            { 18 + 64 + 64 + 64, Properties.Resources.brick18p },
            { 131, Properties.Resources.obstacle00 },
            { 132, Properties.Resources.obstacle01 },
            { 1, Properties.Resources.ludek1 },
            { 2, Properties.Resources.amygdala7 },
            { 0, Properties.Resources.brick_blank },
        };
    }
}
