using System;
using System.Collections.Generic;

namespace Projeto4
{
    /// <summary>
    /// Classe para um grafo de vértices de um tipo genérico
    /// </summary>
    /// <typeparam name="Tipo">Tipo do vértice do grafo</typeparam>
    class Grafo<Tipo> where Tipo : IComparable<Tipo>, IRegistro, new()
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

        public List<Aresta<Tipo>> _arestas;

        /// <summary>
        /// Array de arestas do grafo
        /// </summary>
        public Aresta<Tipo>[] Arestas
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
            _arestas = new List<Aresta<Tipo>>();
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
            // Remove todos os vértices equivalentes ao dado
            _vertices.RemoveAll((Tipo v) => v.Equals(vertice));

            // Remove todas as arestas que entrem ou saiam do vértice dado
            _arestas.RemoveAll((Aresta<Tipo> a) => a.Origem.Equals(vertice) || a.Destino.Equals(vertice));
        }

        /// <summary>
        /// Adiciona uma aresta ao grafo
        /// </summary>
        /// <param name="aresta">Aresta a ser adicionada ao grafo</param>
        public void AdicionarAresta(Aresta<Tipo> aresta)
        {
            _arestas.Add(aresta);
        }

        /// <summary>
        /// Adiciona uma aresta ao grafo
        /// </summary>
        /// <param name="origem">Cidade de origem</param>
        /// <param name="destino">Cidade de destino</param>
        /// <param name="valor">Valor da aresta</param>
        public void AdicionarAresta(Tipo origem, Tipo destino, int valor)
        {
            AdicionarAresta(new Aresta<Tipo>(origem, destino, valor));
        }

        /// <summary>
        /// Obtém uma aresta entre vértices de origem e destino
        /// </summary>
        /// <param name="origem">Vértice de origem</param>
        /// <param name="destino">Vértice de destino</param>
        public Aresta<Tipo> ArestaEntre(int origem, int destino)
        {
            return _arestas.Find((Aresta<Tipo> a) => a.Origem.Equals(origem) && a.Destino.Equals(destino));
        }
    }
}