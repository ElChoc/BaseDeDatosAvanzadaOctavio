using System;
using System.IO;
using System.Collections.Generic;

static int Node_delete(Graph* graph, int distance)
{
    int res = 0;
    for (int i = 0; i < graph->nodes; i++)
    {
    Node* first = graph->head[i];
    Node* n = first;
    while (first && first->distance == distance)
    {
    first = first->next;
    free(n);
    res++;
    n = first;
    }
    while (n && n->next)
    {
    Node* next = n->next;
    if (next->distance == distance)
    {
    n->next = next->next;
    free(next);
    res++;
    }
    n = n->next;
    }
    graph->head[i] = first;
    }
    return res;
    }



    0->d: 2, w: 3->d: 2, w: 3->d: 4, w: 5->Null
    1->d: 7, w: 6->d: 4, w: 6->d: 5, w: 4->Null
    2->d: 2, w: 7->d: 2, w: 7->d: 8, w: 9->Null
    3->d: 10, w: 13->d: 10, w: 13->d: 11, w: 7->Null
    0->d: 2, w: 3->d: 2, w: 3->Null
    1->d: 7, w: 6->d: 5, w: 4->Null
    2->d: 2, w: 7->d: 2, w: 7->d: 8, w: 9->Null
    3->d: 10, w: 13->d: 10, w: 13->d: 11, w: 7->Null


    #include 
    #include 
    typedef struct Node Node;

    typedef struct Graph
    {
        // An array of pointers to Node to represent an adjacency list
        size_t nodes;
        Node* head[];
    }
    Graph;

    // Data structure to store adjacency list nodes of the graph
    struct Node
    {
        int distance;
        int weight;
        Node* next;
    };

    static void graph_print(Graph* graph)
    {
        for (int i = 0; i < graph->nodes; i++)
        {
            printf("%d -> ", i);
            for (Node* n = graph->head[i]; n; n = n->next)
            {
                printf("d: %d, w: %d -> ", n->distance, n->weight);
            }
            printf("Null\n");
        }

    }

    static int Node_delete(Graph* graph, int distance)
    {
        int res = 0;
        for (int i = 0; i < graph->nodes; i++)
        {
            Node* first = graph->head[i];
            Node* n = first;
            while (first && first->distance == distance)
            {
                first = first->next;
                free(n);
                res++;
                n = first;
            }
            while (n && n->next)
            {
                Node* next = n->next;
                if (next->distance == distance)
                {
                    n->next = next->next;
                    free(next);
                    res++;
                }
                n = n->next;
            }
            graph->head[i] = first;
        }
        return res;
    }

    static Node* node_create(int distance, int weight, Node* next)
    {
        Node* n = malloc(sizeof(Node));
        n->distance = distance;
        n->weight = weight;
        n->next = next;
        return n;
    }
    static void node_delete(Node* n)
    {
        if (n)
        {
            node_delete(n->next);
            free(n);
        }
    }
    static Graph* graph_create(int nodes)
    {
        Graph* g = malloc(sizeof(size_t) + nodes * sizeof(Node));
        g->nodes = nodes;
        return g;
    }

    static void graph_delete(Graph* graph)
    {
        for (int i = 0; i < graph->nodes; i++)
        {
            node_delete(graph->head[i]);
        }
        free(graph);
}

    int main(void)
    {
        Graph* graph = graph_create(4);
        Node* n;

        n = node_create(4, 5, NULL);
        n = node_create(2, 3, n);
        n = node_create(2, 3, n);
        graph->head[0] = n;

        n = node_create(5, 4, NULL);
        n = node_create(4, 6, n);
        n = node_create(7, 6, n);
        graph->head[1] = n;

        n = node_create(8, 9, NULL);
        n = node_create(2, 7, n);
        n = node_create(2, 7, n);
        graph->head[2] = n;

        n = node_create(11, 7, NULL);
        n = node_create(10, 13, n);
        n = node_create(10, 13, n);
        graph->head[3] = n;

        graph_print(graph);
        Node_delete(graph, 4);
        graph_print(graph);
        graph_delete(graph);

        return 0;
    }
/*
namespace Graph_Things
{
    public class Graph
    {
        private int vertices, edges;
        private String text;
        private int[,] adjacenceMatrix, incidencyMatrix, mstMatrix;
        private int[][] distanceMatrix;
        public Graph()
        {
            LoadFile();
            PrintAM();
            PrintIM();
            PrintDM();
            PrintMSTM();
        }

        private void LoadFile()
        {
            Console.Write("Entre com o nome do arquivo: ");
            string file = Console.ReadLine();
            try
            {
                using (StreamReader sr = new StreamReader(file + ".txt"))
                {
                    text = sr.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error in load file.");
                Console.WriteLine(e.ToString());
            }
            if (text != null)
            {
                string[] verticesStrings = text.Split(';');
                vertices = Convert.ToInt16(verticesStrings[0]);
                adjacenceMatrix = new int[vertices, vertices];
                int count = 1;
                for (int line = 0; line < vertices; line++)
                {
                    for (int col = 0; col < vertices; col++)
                    {
                        if (verticesStrings[count] != "\n")
                            adjacenceMatrix[line, col] = Convert.ToInt16(verticesStrings[count]);
                        else
                            col--;
                        count++;
                    }
                }
                CalculateEdges();
                CreateIM();
                CreateDM();
                CreateMSTM();
            }

        }

        private void CreateIM()
        {
            incidencyMatrix = new int[vertices, edges];
            int edgeIndex = 0;
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < vertices; col++)
                {
                    if (adjacenceMatrix[line, col] == 1)
                    {
                        incidencyMatrix[line, edgeIndex] = 1;
                        incidencyMatrix[col, edgeIndex] = 1;
                        edgeIndex++;
                    }
                }
            }
        }

        private void CreateDM()
        {
            distanceMatrix = new int[vertices][];
            for (int i = 0; i < vertices; i++)
            {
                distanceMatrix[i] = Dijkstra(i);
            }
        }

        private void CreateMSTM()
        { // Cria a matriz da arvore geradora minima
            mstMatrix = new int[vertices, vertices];
            int[] pred = Prim();
            for (int i = 1; i < pred.Length; i++)
            {
                mstMatrix[i, pred[i]] = distanceMatrix[i][pred[i]];
                mstMatrix[pred[i], i] = distanceMatrix[pred[i]][i];
            }
        }

        private int TakeMin(List<int> queue, int[] dist)
        {
            int lesser = 0;
            foreach (int vertex in queue)
            {
                lesser = vertex;
                break;
            }

            foreach (int vertex in queue)
            {
                if (dist[lesser] > dist[vertex])
                    lesser = vertex;
            }
            return lesser;
        }
        private int EdgeWeight(int a, int b)
        {
            if (a == -1 || b == -1)
            {
                return 9999;
            }
            else
                return adjacenceMatrix[a, b];
        }

        private int ExtractDictionary(Dictionary<int, int> dict)
        {
            int lesser = 0;

            List<int> list = new List<int>(dict.Keys);

            foreach (int vertex in list)
            {
                lesser = vertex;
                break;
            }


            foreach (int vertex in list)
            {
                if (dict[lesser] > dict[vertex])
                    lesser = vertex;
            }

            return lesser;
        }

        public void PrintAM()
        {
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < vertices; col++)
                {
                    Console.Write(adjacenceMatrix[line, col].ToString() + ";");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void PrintMSTM()
        {
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < vertices; col++)
                {
                    Console.Write(mstMatrix[line, col].ToString() + ";");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void PrintIM()
        {
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < edges; col++)
                {
                    Console.Write(incidencyMatrix[line, col].ToString() + ";");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void PrintDM()
        {
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < vertices; col++)
                {
                    Console.Write(distanceMatrix[line][col].ToString() + ";");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void CalculateEdges()
        {
            edges = 0;
            for (int line = 0; line < vertices; line++)
            {
                for (int col = 0; col < vertices; col++)
                {
                    if (adjacenceMatrix[line, col] == 1)
                        edges++;
                }
            }
        }

        public int[,] GetMatrix()
        {
            return adjacenceMatrix;
        }

        public int[] GetGraph()
        {
            int[] graph = new int[2];
            graph[0] = vertices;
            graph[1] = edges;
            return graph;
        }

        public int[] Dijkstra(int start)
        {
            int infinite = 9999;
            List<int> queue = new List<int>();
            int[] pred = new int[vertices];
            int[] dist = new int[vertices];
            for (int vertex = 0; vertex < pred.Length; vertex++)
            {
                pred[vertex] = -1;
                if (vertex != start)
                    dist[vertex] = infinite;
                queue.Add(vertex);
            }
            while (queue.Count > 0)
            {
                int u = TakeMin(queue, dist);
                queue.Remove(u);
                int[] neighbors = ReturnNeighbors(u);
                for (int v = 0; v < neighbors.Length; v++)
                {
                    if (neighbors[v] >= 1)
                    {
                        int aux = neighbors[v] + dist[u];
                        if (aux < dist[v])
                        {
                            dist[v] = aux;
                            pred[v] = u;
                        }
                    }
                }
            }
            return dist;

        }

        public int[] ReturnNeighbors(int vertex)
        {
            int[] neighbors = new int[vertices];
            for (int i = 0; i < neighbors.Length; i++)
            {
                neighbors[i] = adjacenceMatrix[vertex, i];
            }
            return neighbors;
        }

        public int[] Prim()
        { // Só funciona para grafos conexos / Porque o VERTICE escolhido eh o 0, entao se o 0 nao estiver conexo.../ 
            Dictionary<int, int> queue = new Dictionary<int, int>();
            List<int> explored = new List<int>();
            int[] pred = new int[vertices];
            for (int vertex = 0; vertex < pred.Length; vertex++)
            {
                pred[vertex] = -1;
            }
            queue.Add(0, 0); // Adicionando qualquer véritice. Peso inicial 0. Dic(vertex,weight) ~~ (key,value)

            while (queue.Count > 0)
            {
                int v = ExtractDictionary(queue);
                queue.Remove(v);
                explored.Add(v);
                int[] neighbors = ReturnNeighbors(v);
                for (int u = 0; u < neighbors.Length; u++)
                {
                    if (neighbors[u] >= 1)
                    {
                        if (!explored.Contains(u) && EdgeWeight(pred[u], u) > EdgeWeight(v, u))
                        {
                            if (queue.ContainsKey(u))
                                queue[u] = EdgeWeight(v, u);
                            else
                                queue.Add(u, EdgeWeight(v, u));
                            pred[u] = v;
                        }
                    }
                }
            }

            /*			Console.WriteLine ("Predecessores:  ");
                        for (int vertex = 0; vertex < pred.Length; vertex++) {
                            Console.WriteLine ("Predecessor de " + vertex.ToString () + " eh " + pred [vertex]);
                        }
            return pred;
        }

    }
}*/