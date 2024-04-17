using System;
using System.Collections.Generic;
using System.Text;

class Graph
{
    private Dictionary<string, Dictionary<string, int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, Dictionary<string, int>>();
    }

    public void AddEdge(string source, string destination, int weight)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new Dictionary<string, int>();
        }

        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new Dictionary<string, int>();
        }

        adjacencyList[source][destination] = weight;
        adjacencyList[destination][source] = weight; 
    }

    public void PrintGraph()
    {
        foreach (var node in adjacencyList)
        {
            foreach (var edge in node.Value)
            {
                Console.WriteLine($"{node.Key} - {edge.Key} = {edge.Value} km");
            }
        }
    }

    public List<string> ShortestPath(string start, string end)
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        Dictionary<string, string> previous = new Dictionary<string, string>();
        List<string> nodes = new List<string>();

        List<string> path = null;

        foreach (var vertex in adjacencyList)
        {
            if (vertex.Key == start)
            {
                distances[vertex.Key] = 0;
            }
            else
            {
                distances[vertex.Key] = int.MaxValue;
            }

            nodes.Add(vertex.Key);
        }

        while (nodes.Count != 0)
        {
            nodes.Sort((x, y) => distances[x] - distances[y]);

            string smallest = nodes[0];
            nodes.Remove(smallest);

            if (smallest == end)
            {
                path = new List<string>();
                while (previous.ContainsKey(smallest))
                {
                    path.Add(smallest);
                    smallest = previous[smallest];
                }

                break;
            }

            if (distances[smallest] == int.MaxValue)
            {
                break;
            }

            foreach (var neighbor in adjacencyList[smallest])
            {
                int alt = distances[smallest] + neighbor.Value;
                if (alt < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alt;
                    previous[neighbor.Key] = smallest;
                }
            }
        }

        return path;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Graph graph = new Graph();

       
        graph.AddEdge("Київ", "Житомир", 140);
        graph.AddEdge("Київ", "Чернігів", 150);
        graph.AddEdge("Житомир", "Хмельницький", 220);
        graph.AddEdge("Житомир", "Рівне", 150);
        graph.AddEdge("Рівне", "Луцьк", 90);
        graph.AddEdge("Рівне", "Хмельницький", 160);
        graph.AddEdge("Хмельницький", "Вінниця", 100);
        graph.AddEdge("Вінниця", "Черкаси", 210);
        graph.AddEdge("Черкаси", "Київ", 190);
        graph.AddEdge("Черкаси", "Полтава", 330);
        graph.AddEdge("Полтава", "Суми", 150);
        graph.AddEdge("Суми", "Чернігів", 180);
        graph.AddEdge("Суми", "Харків", 210);
        graph.AddEdge("Харків", "Полтава", 130);
        graph.AddEdge("Харків", "Дніпро", 230);
        graph.AddEdge("Дніпро", "Запоріжжя", 190);
        graph.AddEdge("Запоріжжя", "Миколаїв", 290);
        graph.AddEdge("Миколаїв", "Одеса", 180);

        Console.WriteLine("Граф з усіма обласними центрами та відстанями до сусідніх областей:");
        graph.PrintGraph();

        
        string startCity = "Київ";
        string endCity = "Одеса";
        List<string> shortestPath = graph.ShortestPath(startCity, endCity);

        if (shortestPath != null)
        {
            shortestPath.Reverse();
            Console.WriteLine($"\n\nНайкоротший шлях між {startCity} та {endCity}:");
            Console.WriteLine(string.Join(" -> ", shortestPath) + $" = {shortestPath.Count - 1} km");
        }
        else
        {
            Console.WriteLine($"Немає шляху між {startCity} та {endCity}");
        }
    }
}
