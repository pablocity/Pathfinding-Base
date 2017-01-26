using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MapNavi;

namespace PathfindingStage
{
    public class GUI
    {
        public static void CreateNode(Graphics graphics, Node node)
        {
            if (node != null)
            {
                graphics.FillRectangle(Brushes.Crimson, node.shape);
                //graphics.Dispose();
            }
        }
    }
}
