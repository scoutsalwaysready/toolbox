
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class P
{
	class Edge
	{
		public int From;
		public int To;
		public float Weight;
	}

	// Expect file format:
	// A graph G = {V, E} serialized as:
	// 
	// Number of V
	// Number of E
	// `E` edges with `src, dst, Weight`
	class Graph
	{

		public Graph()
		{
			this.Vertices = new Dictionary<int, List<Edge>>();
		}

		// Vertex number index inTo edges.
		public Dictionary<int, List<Edge>> Vertices;

		public static Graph Read(StreamReader stream)
		{
			int.Parse(stream.ReadLine());
			int E = int.Parse(stream.ReadLine());

			var graph = new Graph();

			for(int i = 0; i < E; ++i)
			{
				string[] r = stream.ReadLine().Split(' ');

				var edge = new Edge()
				{
					From = int.Parse(r[0]),
					To = int.Parse(r[1]),
					Weight = float.Parse(r[2]),
				};

				if(!graph.Vertices.ContainsKey(edge.From))
				{
					graph.Vertices[edge.From] = new List<Edge>();
				}
				graph.Vertices[edge.From].Add(edge);
			}

			return graph;
		}

		public override string ToString()
		{
			var sb = new StringBuilder();
			foreach(var v in this.Vertices)
			{
				foreach(var kvp in v.Value)
				{
					sb.AppendFormat("{0} -> {1} @{2}\n", kvp.From, kvp.To, kvp.Weight);
				}
			}
			return sb.ToString();
		}
	}

	static float ShortestPath(Graph graph, int From, int To)
	{
		var candidates = new SortedSet<Edge>(Comparer<Edge>.Create((a, b) => a.Weight.CompareTo(b.Weight)));
		var visited = new HashSet<Edge>();

		foreach(var edge in graph.Vertices[From])
		{
			candidates.Add(edge);
			visited.Add(edge);
		}

		while(candidates.Count != 0)
		{
			var edge = candidates.Min;
			candidates.Remove(edge);

			if(edge.To == To) return edge.Weight;

			foreach(var nextEdge in graph.Vertices[edge.To])
			{
				if(!visited.Contains(nextEdge))
				{
					nextEdge.Weight += edge.Weight;
					candidates.Add(nextEdge);
					visited.Add(nextEdge);
				}
			}
		}

		return -1;
	}

	static void Main()
	{
		Graph graph = Graph.Read(new StreamReader("./tinyEWD.txt"));
		// Console.WriteLine(graph);
		Console.WriteLine(ShortestPath(graph, 0, 6));
	}
}
