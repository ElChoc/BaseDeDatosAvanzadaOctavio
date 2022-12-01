using System;


namespace Graph_Things
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Graph g = new Graph();

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
    }
}