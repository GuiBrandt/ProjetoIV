using System;
using System.IO;

namespace Projeto4
{
    /// <summary>
    /// Classe para um registro de cidade
    /// </summary>
    class Cidade : IComparable<Cidade>, IRegistro
    {
        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Cidade()
        {
            Nome = "";
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="nome">Nome da cidade</param>
        public Cidade(string nome)
        {
            Nome = nome;
        }

        /// <summary>
        /// Compara esta cidade com outra
        /// </summary>
        /// <param name="other">Cidade com a qual comparar</param>
        /// <returns>Retorna menor que 0 se for menor, 0 se for igual e maior que 0 se for maior</returns>
        public int CompareTo(Cidade other)
        {
            return Nome.CompareTo(other.Nome);
        }

        /// <summary>
        /// Verifica igualdade entre duas cidades
        /// </summary>
        /// <param name="other">Cidade com a qual comparar</param>
        /// <returns>Verdadeiro se forem iguais, falso se não</returns>
        public override bool Equals(object other)
        {
            if (other == null || other.GetType() != typeof(Cidade))
                return false;

            return CompareTo((Cidade)other) == 0;
        }

        /// <summary>
        /// Converte a cidade em string
        /// </summary>
        /// <returns>O nome da cidade</returns>
        public override string ToString()
        {
            return Nome;
        }

        /// <summary>
        /// Escreve a cidade para uma stream binária
        /// </summary>
        /// <param name="writer">BinaryWriter para a stream</param>
        public void Escrever(BinaryWriter writer)
        {
            writer.Write(Nome);
        }

        /// <summary>
        /// Lê os valores da cidade de uma stream binária
        /// </summary>
        /// <param name="reader"></param>
        public void Ler(BinaryReader reader)
        {
            Nome = reader.ReadString();
        }
    }
}
