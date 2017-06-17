using System;
using System.Collections.Generic;

namespace Projeto4
{
    /// <summary>
    /// Classe para as arestas do grafo
    /// </summary>
    public class Aresta
    {
        /// <summary>
        /// Índice do vértice de origem
        /// </summary>
        public int IndiceOrigem { get; private set; }

        /// <summary>
        /// Índice do vértice de destino
        /// </summary>
        public int IndiceDestino { get; private set; }

        /// <summary>
        /// Valor da aresta
        /// </summary>
        public int Valor { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="origem">Vértice do qual parte a aresta</param>
        /// <param name="destino">Vértice para o qual a aresta se dirige</param>
        /// <param name="valor">Valor da aresta</param>
        public Aresta(int origem, int destino, int valor)
        {
            IndiceOrigem = origem;
            IndiceDestino = destino;
            Valor = valor;
        }
    }

    /// <summary>
    /// Classe para um grafo de vértices de um tipo genérico
    /// </summary>
    /// <typeparam name="Tipo">Tipo do vértice do grafo</typeparam>
    class Grafo<Tipo> where Tipo : IComparable<Tipo>
    {
        private List<Tipo> _vertices;

        /// <summary>
        /// Array de vértices do grafo
        /// </summary>
        public Tipo[] Vertices
        {
            get
            {
                return _vertices.ToArray();
            }
        }

        public List<Aresta> _arestas;

        /// <summary>
        /// Array de arestas do grafo
        /// </summary>
        public Aresta[] Arestas
        {
            get
            {
                return _arestas?.ToArray();
            }
        }

        /// <summary>
        /// Construtor
        /// </summary>
        public Grafo()
        {
            _vertices = new List<Tipo>();
            _arestas = new List<Aresta>();
        }

        /// <summary>
        /// Adiciona um vértice ao grafo
        /// </summary>
        /// <param name="vertice">Vértice a ser adicionado ao grafo</param>
        public void AdicionarVertice(Tipo vertice)
        {
            _vertices.Add(vertice);
        }

        /// <summary>
        /// Remove um vértice do grafo
        /// </summary>
        /// <param name="vertice">Vértice que será removido</param>
        public void RemoverVertice(Tipo vertice)
        {

        }

        /// <summary>
        /// Adiciona uma aresta ao grafo
        /// </summary>
        /// <param name="aresta">Aresta a ser adicionada ao grafo</param>
        public void AdicionarAresta(Aresta aresta)
        {
            _arestas.Add(aresta);
        }

        /// <summary>
        /// Adiciona uma aresta ao grafo
        /// </summary>
        /// <param name="origem">Cidade de origem</param>
        /// <param name="destino">Cidade de destino</param>
        /// <param name="valor">Valor da aresta</param>
        public void AdicionarAresta(int origem, int destino, int valor)
        {
            AdicionarAresta(new Aresta(origem, destino, valor));
        }

        /// <summary>
        /// Obtém uma aresta entre vértices de origem e destino
        /// </summary>
        /// <param name="origem">Vértice de origem</param>
        /// <param name="destino">Vértice de destino</param>
        public Aresta ArestaEntre(int origem, int destino)
        {
            return _arestas.Find((Aresta a) => { return a.IndiceOrigem == origem && a.IndiceDestino == destino; });
        }
    }
}