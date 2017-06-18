using System;
using System.IO;
using System.Text;

namespace Projeto4
{
    /// <summary>
    /// Classe para manutenção do arquivo de cidades
    /// </summary>
    class ArquivoRegistro<Tipo> : IDisposable where Tipo : IRegistro, new()
    {
        FileStream _stream;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="filename">Nome do arquivo</param>
        /// /// <param name="mode">Modo de abertura do arquivo</param>
        public ArquivoRegistro(string filename, FileMode mode)
        {
            _stream = File.Open(filename, mode, FileAccess.ReadWrite);
        }

        /// <summary>
        /// Escreve uma cidade no arquivo
        /// </summary>
        /// <param name="registro">Registro a ser escrito</param>
        public void Escrever(Tipo registro)
        {
            using (BinaryWriter writer = new BinaryWriter(_stream, Encoding.Default, true))
                registro.Escrever(writer);
        }

        /// <summary>
        /// Lê uma cidade do arquivo
        /// </summary>
        public Tipo LerUm()
        {
            // Se estiver no fim do arquivo, retorna nulo
            if (_stream.Position == _stream.Length)
                return default(Tipo);


            Tipo resultado = new Tipo();
            using (BinaryReader reader = new BinaryReader(_stream, Encoding.Default, true))
                resultado.Ler(reader);

            return resultado;
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
