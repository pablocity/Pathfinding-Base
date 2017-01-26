using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MapNavi
{
    [Serializable]
    public class Node
    {
        public int Distance; //
        public Node Ancestor; //

        public int TotalCost; //
        public int FullValue; // Zmienne używane w algorytmie

        public string Name { get; private set; }

        Random random = new Random();

        public List<Node> Successors = new List<Node>();
        public List<Edge> Edges = new List<Edge>();

        // Zmienne do graficznego przedstawienia node'a

        public int X { get; set; }
        public int Y { get; set; }

        public Rectangle shape;


        public Node(string name)
        {
            Distance = 0;
            Ancestor = null;
            Name = name;
            TotalCost = 0;
            FullValue = 0;
            
        }
       
        // Przeciążona metoda Equals pomocna przy porównywaniu w algorytmie (porównuje na podstawie właściwości Name obiektu)
        public override bool Equals(object obj)
        {
            Node objN = obj as Node;
            if (objN != null)
            {
                if (this.Name == objN.Name)
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
            
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
