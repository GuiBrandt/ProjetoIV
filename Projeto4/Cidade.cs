using System;

namespace Projeto4
{
    /// <summary>
    /// Classe para um registro de cidade
    /// </summary>
    class Cidade : IComparable<Cidade>
    {
        /// <summary>
        /// Nome da cidade
        /// </summary>
        public string Nome { get; private set; }

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
    }
}
