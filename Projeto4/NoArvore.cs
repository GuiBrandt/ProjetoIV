namespace Projeto4
{
    /// <summary>
    /// Classe para os nós de uma árvore binária
    /// </summary>
    /// <typeparam name="Tipo">Tipo de valor que será armazenado no nó da árvore</typeparam>
    class NoArvore<Tipo>
    {
        /// <summary>
        /// Valor do nó
        /// </summary>
        public Tipo Info { get; set; }

        /// <summary>
        /// Nó à esquerda deste
        /// </summary>
        public NoArvore<Tipo> Esquerda { get; set; }

        /// <summary>
        /// Nó à direita deste
        /// </summary>
        public NoArvore<Tipo> Direita { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="info">Valor do nó</param>
        /// <param name="esq">Nó à esquerda deste</param>
        /// <param name="dir">Nó à direita deste</param>
        public NoArvore(Tipo info, NoArvore<Tipo> esq, NoArvore<Tipo> dir)
        {
            Info = info;
            Esquerda = esq;
            Direita = dir;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="info">Valor do nó</param>
        public NoArvore(Tipo info) : this(info, null, null) {}
    }
}
