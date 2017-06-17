using System;
using System.IO;

namespace Projeto4
{
    /// <summary>
    /// Classe para manutenção do arquivo de cidades
    /// </summary>
    class ArquivoCidades : IDisposable
    {
        FileStream _stream;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="filename">Nome do arquivo</param>
        public ArquivoCidades(string filename)
        {
            _stream = new FileStream(filename, FileMode.OpenOrCreate);
        }

        /// <summary>
        /// Escreve uma cidade no arquivo
        /// </summary>
        /// <param name="cidade">Cidade a ser escrita</param>
        public void Escrever(Cidade cidade)
        {
            using (BinaryWriter writer = new BinaryWriter(_stream))
                writer.Write(cidade.Nome);
        }

        /// <summary>
        /// Lê uma cidade do arquivo
        /// </summary>
        public Cidade LerUm()
        {
            // Se estiver no fim do arquivo, retorna nulo
            if (_stream.Position == _stream.Length)
                return null;

            using (BinaryReader reader = new BinaryReader(_stream))
                return new Cidade(reader.ReadString());
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
