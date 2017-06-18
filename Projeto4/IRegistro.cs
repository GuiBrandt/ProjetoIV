using System;
using System.IO;

namespace Projeto4
{
    /// <summary>
    /// Interface para registros, usada para ler objetos de arquivos
    /// </summary>
    interface IRegistro
    {
        void Escrever(BinaryWriter writer);
        void Ler(BinaryReader reader);
    }
}
