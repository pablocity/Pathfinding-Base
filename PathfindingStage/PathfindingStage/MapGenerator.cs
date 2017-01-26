using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MapNavi;

namespace PathfindingStage
{
    public class MapGenerator
    {
        
        public static void GenerateMap(Graphics graphics, ref Map mapToGenerate)
        {
            int a = 0;
            for (int i = 160; i < 160 + (mapToGenerate.X * 53); i+=53)
            {
                for (int j = 15; j < 15 + (mapToGenerate.Y * 53); j+=53)
                {
                    a++;
                    mapToGenerate.CreateNodes(i, j, "Punkt nr. " + a, graphics);
                    
                }
            }
        }

        private void AddObstacles()
        {

        }
    }
}
