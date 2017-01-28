using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapNavi;

namespace PathfindingStage
{

    //TODO kolorowanie drogi
    //TODO czyszczenie zasobów niezarządzanych
    //TODO flood-fill algorithm - generowanie losowych przeszkód

    public partial class Form1 : Form
    {
        Graphics graphics;
        Map map;
        BFS bfs;

        List<Node> lastRoute = null;
        
        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
            map = new Map();
            bfs = new BFS();
        }

        private void showRoute_Click(object sender, EventArgs e)
        {
            MapGenerator.GenerateMap(graphics, ref map);
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Node clicked = map.getNodeAtPoint(e.X, e.Y);

            if (clicked != null && clicked.IsObstacle == false)
            {
                if (lastRoute != null)
                {
                    ShowRoute(lastRoute, false);
                    lastRoute = null;
                }

                if (map.selectedLocation == null)
                {
                    
                    map.SelectNode(graphics, clicked); // sprawdzić czy nie jest już zaznaczony
                }
                else
                {
                    bfs.Search(map.selectedLocation, clicked);
                    lastRoute = bfs.GetRoute(clicked);
                    map.Unselect(graphics, map.selectedLocation);
                    ShowRoute(lastRoute, true);
                    ClearMap(ref map);
                }
            }
            else
                MessageBox.Show("Nie możesz tego zaznaczyć");

        }

        public void ShowRoute(List<Node> route, bool action)
        {
            if (action)
            {
                for (int i = 0; i < route.Count; i++)
                {
                    
                    GUI.SelectNode(graphics, route[i], Brushes.GreenYellow, 15);
                    if (i == 0)
                        GUI.SelectNode(graphics, route[i], Brushes.Crimson);
                    if (i == route.Count-1)
                        GUI.SelectNode(graphics, route[i], Brushes.Green);
                }
            }
            else
            {
                foreach (Node n in route)
                {
                    GUI.UnselectNode(graphics, n);
                }
            }
            
        }

        public void ClearMap(ref Map map)
        {
            foreach (Node n in map.places)
            {
                n.Ancestor = null;
                n.Distance = 0;
                n.FullValue = 0;
                n.TotalCost = 0;
            }
        }
    }
}
