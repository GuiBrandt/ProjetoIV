﻿using System.IO;

namespace Projeto4
{
    /// <summary>
    /// Classe para as arestas do grafo
    /// </summary>
    class Aresta<Tipo> : IRegistro where Tipo : IRegistro, new()
    {
        /// <summary>
        /// Índice do vértice de origem
        /// </summary>
        public Tipo Origem { get; private set; }

        /// <summary>
        /// Índice do vértice de destino
        /// </summary>
        public Tipo Destino { get; private set; }

        /// <summary>
        /// Valor da aresta
        /// </summary>
        public int Valor { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Aresta()
        {
            Origem = default(Tipo);
            Destino = default(Tipo);
            Valor = 0;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="origem">Vértice do qual parte a aresta</param>
        /// <param name="destino">Vértice para o qual a aresta se dirige</param>
        /// <param name="valor">Valor da aresta</param>
        public Aresta(Tipo origem, Tipo destino, int valor)
        {
            Origem = origem;
            Destino = destino;
            Valor = valor;
        }

        /// <summary>
        /// Escreve a aresta para uma stream binária
        /// </summary>
        /// <param name="writer">BinaryWriter para a stream</param>
        public void Escrever(BinaryWriter writer)
        {
            Origem.Escrever(writer);
            Destino.Escrever(writer);
            writer.Write(Valor);
        }

        /// <summary>
        /// Lê os valores da aresta de uma stream binária
        /// </summary>
        /// <param name="reader"></param>
        public void Ler(BinaryReader reader)
        {
            Origem = new Tipo();
            Origem.Ler(reader);

            Destino = new Tipo();
            Destino.Ler(reader);

            Valor = reader.ReadInt32();
        }
    }
}
