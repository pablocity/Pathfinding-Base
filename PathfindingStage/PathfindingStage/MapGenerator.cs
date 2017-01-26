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
            BFS search = new BFS();
            int a = 0;
            for (int i = 160; i < 160 + (mapToGenerate.X * 52); i+=52)
            {
                for (int j = 17; j < 17 + (mapToGenerate.Y * 52); j+=52)
                {
                    a++;
                    mapToGenerate.CreateNodes(i, j, "Punkt nr. " + a, graphics);
                    
                }
            }
            mapToGenerate.CalculateSuccessors();
            search.Search(mapToGenerate.getNodeAtPoint(160, 17), mapToGenerate.getNodeAtPoint(420, 173));
            search.GetRoute(mapToGenerate.getNodeAtPoint(420, 173));
        }

        private void AddObstacles()
        {

        }
    }
}
