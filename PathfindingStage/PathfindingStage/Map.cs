using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing;
using PathfindingStage;

namespace MapNavi
{
    // Klasa reprezentuje obiekt mapy

    public class Map
    {

        public List<Node> places; // Lista wszystkich miejsc (node'ów) na mapie


        // Szerokość i wysokość mapy
        public int X { get; private set; }
        public int Y { get; private set; }

        public bool ObstaclePenetration = false;

        public Node selectedLocation = null;

        public Map()
        {
            //TODO Dodać współrzędne jako parametr konstruktora
            X = 14;
            Y = 9;
            places = new List<Node>();
        }

        // Tworzy połączenie między miejscami i oddelegowuje zadanie narysowani ich do klasy GUI
        public void CreateEdges(int cost, Node secondLocation, bool twoWay)
        {
            if (secondLocation != null)
            {

                //Line propEdge;


                Edge tempEdge = new Edge(selectedLocation, secondLocation, cost);
                tempEdge.twoWay = false; //
                selectedLocation.Successors.Add(secondLocation);
                selectedLocation.Edges.Add(tempEdge);

                
                tempEdge.twoWay = true; //
                tempEdge.isDrawn = true; // Zmienne służące do odtworzenia obrazu mapy podczas deserializacji
                secondLocation.Successors.Add(selectedLocation);
                secondLocation.Edges.Add(new Edge(secondLocation, selectedLocation, cost));

                //GUI.DrawEdge(secondLocation, selectedLocation, c, out propEdge, twoWay);

                Edge temporaryEdge = new Edge(secondLocation, selectedLocation, cost);
                //temporaryEdge.graphicEdge = propEdge;


                secondLocation = null;
                selectedLocation = null;

            }
            
        }


        // Tworzy wierzchołek jeśli nie wykracza po za konkretny obszar (eliminuje możliwość dodania wierzchołka, który jest w połowie w ścianie)
        //Współrzędne wpisane na sztywno ale spokojnie można by zamiast nich pobrać x, y konkretnych ścian i na nich operować,
        //w tym wypadku niepotrzebne bo nie ma możliwości rozszerzania okna, oraz nie pozwala na nachodzenie na siebie miejsc
        public void CreateNodes(int x, int y, string name, Graphics graphics)
        {

            Node node = new Node(name);

            node.X = x;
            node.Y = y;

            node.shape = new Rectangle(new Point(x, y), new Size(50, 50));

            this.places.Add(node);

            GUI.CreateNode(graphics, node);
             
        }


        // Zaznacza konkretne miejsce
        public void SelectNode(Graphics graphics, Node toSelect)
        {
            if (toSelect != null)
            {
                selectedLocation = toSelect;

                GUI.SelectNode(graphics, toSelect, Brushes.Green);
            }

        }

        public void Unselect(Graphics graphics, Node toUnselect)
        {
            if (toUnselect != null && selectedLocation != null)
            {
                selectedLocation = null;
                GUI.UnselectNode(graphics, toUnselect);
            }
        }


        // Wyszukuje miejsce na mapie o podanych współrzędnych
        public Node getNodeAtPoint(int x, int y)
        {
            foreach (Node placeOnMap in places)
            {   

                if (x >= ((placeOnMap.X + 25) - (placeOnMap.shape.Width / 2)) && x <= ((placeOnMap.X + 25) + (placeOnMap.shape.Width/2))
                    && y >= ((placeOnMap.Y + 25) - (placeOnMap.shape.Height / 2)) && y <= ((placeOnMap.Y + 25) + (placeOnMap.shape.Height)/2))
                {
                    return placeOnMap;
                }
                
            }

            return null;
        }

        public void CalculateSuccessors()
        {

            foreach (Node n in places)
            {
                Node north = getNodeAtPoint((n.X + 25), (n.Y + 25) - 50);
                Node south = getNodeAtPoint((n.X + 25), (n.Y + 25) + 50);
                Node west = getNodeAtPoint((n.X + 25) - 50, (n.Y + 25));
                Node east = getNodeAtPoint((n.X + 25) + 50, (n.Y + 25));

                Node northEast = getNodeAtPoint((n.X + 25) + 50, (n.Y + 25) - 50);
                Node northWest = getNodeAtPoint((n.X + 25) - 50, (n.Y + 25) - 50);
                Node southEast = getNodeAtPoint((n.X + 25) + 50, (n.Y + 25) + 50);
                Node southWest = getNodeAtPoint((n.X + 25) - 50, (n.Y + 25) + 50);

                if (north != null) n.Successors.Add(north);
                if (south != null) n.Successors.Add(south);
                if (west != null) n.Successors.Add(west);
                if (east != null) n.Successors.Add(east);
                if (northEast != null) n.Successors.Add(northEast);
                if (northWest != null) n.Successors.Add(northWest);
                if (southEast != null) n.Successors.Add(southEast);
                if (southWest != null) n.Successors.Add(southWest);
            }

            System.Windows.Forms.MessageBox.Show("Successors were successfully calculated");
            /*
            foreach (Node s in getNodeAtPoint(212, 69).Successors)
            {
                Console.WriteLine(s.Name);
            }
            */
        }


    }
}
