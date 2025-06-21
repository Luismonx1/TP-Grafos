using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Grafos
{
    internal class Metodos
    {
        public Metodos() { }

        Menu menu = new Menu();

        public double CalcDensidade(Grafo grafo)
        {
            double DensidadeGrafo = (double)grafo.quantArestas / (grafo.quantVertices * (grafo.quantVertices - 1.0));

            return DensidadeGrafo;
        }

        public void ImprimirListaAdjacencia(Grafo grafo)
        {
            List<List<int>> listaAdj = new List<List<int>>();

            for (int i = 0; i < grafo.quantVertices; i++)
            {
                listaAdj.Add(new List<int>());
            }

            foreach (Aresta aresta in grafo.ListaArestas)
            {
                listaAdj[aresta.Inicio].Add(aresta.Fim);
            }

            for (int i = 0; i < grafo.quantVertices; i++)
            {
                Console.Write($"Vértice {i}");
                foreach (int proximo in listaAdj[i])
                {
                    Console.Write($" -> {proximo}");
                }
                Console.WriteLine();
            }
        }

        public void ImprimirMatrizAdjacencia(Grafo grafo)
        {
            grafo.matrizAdjacencia = new int[grafo.quantVertices, grafo.quantVertices];

            for (int i = 0; i < grafo.quantVertices; i++)
            {
                for (int j = 0; j < grafo.quantVertices; j++)
                {
                    grafo.matrizAdjacencia[i, j] = 0;
                }
            }

            foreach (Aresta aresta in grafo.ListaArestas)
            {
                grafo.matrizAdjacencia[aresta.Inicio, aresta.Fim] = 1;
            }

            Console.WriteLine("Matriz de Adjacência:");
            for (int i = 0; i < grafo.quantVertices; i++)
            {
                for (int j = 0; j < grafo.quantVertices; j++)
                {
                    Console.Write($"{grafo.matrizAdjacencia[i, j]}");
                }
                Console.WriteLine();
            }
        }

        public void ImprimirArestasAdjacentes(Grafo grafo)
        {
           menu.Resultado();
            Console.Write("Informe o vértice de início da aresta:");
            int inicio = int.Parse(Console.ReadLine());
            Console.Write("Informe o vértice de fim da aresta:");
            int fim = int.Parse(Console.ReadLine());

            foreach (Aresta aresta in grafo.ListaArestas)
            {
                if (!((aresta.Inicio == inicio) && (aresta.Fim == fim)) && (aresta.Inicio == inicio || aresta.Fim == inicio || aresta.Inicio == fim || aresta.Fim == fim))
                {
                    Console.WriteLine($"Aresta de {aresta.Inicio} para {aresta.Fim} com peso {aresta.Peso}");
                }
            }
        }

        public void ImprimirVerticesIncidentesArestas(Grafo grafo)
        {
            menu.Resultado();
            bool encontrou = false;
            Console.Write("Informe o vértice de início da aresta: ");
            int inicio = int.Parse(Console.ReadLine());
            Console.Write("Informe o vértice de fim da aresta: ");
            int fim = int.Parse(Console.ReadLine());

            foreach (Aresta aresta in grafo.ListaArestas)
            {
                if (aresta.Inicio == inicio && aresta.Fim == fim)
                {
                    encontrou = true;
                    break;
                }
            }

            if (encontrou)
            {
                Console.WriteLine($"\nVértices incidentes à aresta ({inicio} → {fim}):");
                Console.WriteLine($"- Vértice de origem: {inicio}");
                Console.WriteLine($"- Vértice de destino: {fim}");
            }
            else
            {
                Console.WriteLine("\nAresta não encontrada no grafo.");
            }
        }

        public void SubstituirPesoAresta(Grafo grafo)
        {
            menu.Resultado();
            bool encontrou = false;
            Console.Write("Informe o vértice de início da aresta: ");
            int inicio = int.Parse(Console.ReadLine());
            Console.Write("Informe o vértice de fim da aresta: ");
            int fim = int.Parse(Console.ReadLine());
            Console.Write("Informe o novo peso da aresta: ");
            double novoPeso = double.Parse(Console.ReadLine());

            foreach (Aresta aresta in grafo.ListaArestas)
            {
                if (aresta.Inicio == inicio && aresta.Fim == fim)
                {
                    aresta.Peso = novoPeso;
                    encontrou = true;
                    Console.WriteLine($"\nPeso da aresta ({inicio} → {fim}) atualizado para {novoPeso}.");
                    break;
                }
            }

            if (encontrou == false)
            {
                Console.WriteLine("\nAresta não encontrada no grafo.");
            }
        }

        public void BuscaEmProfundidade()
        {
            menu.Resultado();

        }
    }
}
