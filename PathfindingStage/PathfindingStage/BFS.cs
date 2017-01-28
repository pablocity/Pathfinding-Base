using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapNavi
{
    // Written by Paweł Woliński in June 2016
    //*
    // Prosty sposób obliczania drogi tylko na podstawie liczby połączeń niezależnie od kosztu (odległości) każdego z nich
    class BFS
    {
        Queue<Node> queue;
        int currentLevel = 0;

        Queue<Node> routeQueue;
        List<Node> route;

        public Dictionary<string, int> Search(Node startPoint, Node endPoint)
        {
            queue = new Queue<Node>();
            currentLevel = 0;
            
            Console.WriteLine("Punkt początkowy to " + startPoint.Name + "\n\nCel to " + endPoint.Name + "\n");

            queue.Enqueue(startPoint);

            while (queue.Count != 0)
            {
                Node current = queue.Dequeue();
                if (current == endPoint)
                {
                    Dictionary<string, int> goal = new Dictionary<string, int>();
                    goal.Add(current.Name, current.Distance);
                    return goal;
                }
                currentLevel = current.Distance + 1;

                for (int i = 0; i < current.Successors.Count; i++)
                {
                    if (current.Successors[i].Distance == 0)
                    {
                        queue.Enqueue(current.Successors[i]);
                        current.Successors[i].Distance = currentLevel;
                        current.Successors[i].Ancestor = current;
                    }
                }
            }

            return new Dictionary<string, int>(); 
            
        }

        public List<Node> GetRoute(Node endPoint)
        {
            routeQueue = new Queue<Node>();
            route = new List<Node>();
            routeQueue.Enqueue(endPoint);
            route.Add(endPoint);

            for (int i = 0; i < endPoint.Distance; i++)
            {
                Node ancestor = routeQueue.Dequeue().Ancestor;
                route.Add(ancestor);
                routeQueue.Enqueue(ancestor);
            }

            foreach (Node s in route)
            {
                Console.WriteLine(s.Name);
            }

            return route;
        }


        public void ShowOutput(Dictionary<string, int> output)
        {
            if (output != null)
            {
                foreach (string n in output.Keys)
                    Console.WriteLine("Dotarłeś do " + n + "\n");
                foreach (int i in output.Values)
                    Console.WriteLine("Liczba połączeń do celu: " + i + "\n");
            }
        }
    }
}
