using System;
using System.IO;
using System.Text;

namespace Projeto4
{
    /// <summary>
    /// Classe para manutenção do arquivo de arestas
    /// </summary>
    class ArquivoArestas : IDisposable
    {
        FileStream _stream;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="filename">Nome do arquivo</param>
        /// <param name="mode">Modo de abertura do arquivo</param>
        public ArquivoArestas(string filename, FileMode mode)
        {
            _stream = File.Open(filename, mode, FileAccess.ReadWrite);
        }

        /// <summary>
        /// Escreve uma aresta no arquivo
        /// </summary>
        /// <param name="aresta">Aresta a ser escrita</param>
        public void Escrever(Aresta aresta)
        {
            using (BinaryWriter writer = new BinaryWriter(_stream, Encoding.Default, true))
            {
                writer.Write(aresta.IndiceOrigem);
                writer.Write(aresta.IndiceDestino);
                writer.Write(aresta.Valor);
            }
        }

        /// <summary>
        /// Lê uma aresta do arquivo
        /// </summary>
        public Aresta LerUm()
        {
            // Se estiver no fim do arquivo, retorna nulo
            if (_stream.Position == _stream.Length)
                return null;

            using (BinaryReader reader = new BinaryReader(_stream, Encoding.Default, true))
                return new Aresta(reader.ReadInt32(), reader.ReadInt32(), reader.ReadInt32());
        }

        /// <summary>
        /// Fecha o arquivo
        /// </summary>
        public void Fechar()
        {
            _stream.Close();
        }

        /// <summary>
        /// Fecha o arquivo
        /// </summary>
        public void Dispose()
        {
            Fechar();
        }
    }
}
