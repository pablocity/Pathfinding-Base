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
                Brush brush = Brushes.LightGray;
                graphics.FillRectangle(brush, node.shape);
                //brush.Dispose();
            }
        }

        public static void SelectNode(Graphics graphics, Node node, Brush color, int fill = 0)
        {
            // fill nie może być większe od 50
            if (fill != 0)
            {
                Rectangle r = node.shape;
                r.Width -= fill;
                r.Height -= fill;
                r.X += fill / 2;
                r.Y += fill / 2;
                graphics.FillRectangle(color, r);
            }
            else
                graphics.FillRectangle(color, node.shape);

        }

        public static void UnselectNode(Graphics graphics, Node node)
        {
            graphics.FillRectangle(Brushes.LightGray, node.shape);
        }
    }
}
