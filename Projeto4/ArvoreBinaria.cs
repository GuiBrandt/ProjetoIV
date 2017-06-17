using System;

namespace Projeto4
{
    /// <summary>
    /// Classe para uma árvore binária
    /// </summary>
    /// <typeparam name="Tipo">Tipo de valor armazenado na árvore</typeparam>
    class ArvoreBinaria<Tipo> where Tipo : IComparable<Tipo>
    {
        /// <summary>
        /// Nó raiz da árvore
        /// </summary>
        public NoArvore<Tipo> Raiz { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public ArvoreBinaria()
        {
            Raiz = null;
        }

        /// <summary>
        /// Adiciona um nó à arvore ordenadamente
        /// </summary>
        /// <param name="no">Nó a ser adicionado</param>
        public void Adicionar(NoArvore<Tipo> no)
        {
            if (Raiz == null)
                Raiz = no;

            NoArvore<Tipo> anterior = Raiz, atual = null;

            do
            {
                if (anterior.Info.CompareTo(no.Info) < 0)
                    atual = anterior.Esquerda;
                else
                    atual = anterior.Direita;

                anterior = atual;
            }
            while (atual != null);
        }

        /// <summary>
        /// Adiciona um valor à arvore ordenadamente
        /// </summary>
        /// <param name="valor">Valor a ser adicionado</param>
        public void Adicionar(Tipo valor)
        {
            Adicionar(new NoArvore<Tipo>(valor));
        }

        /// <summary>
        /// Remove um valor da árvore
        /// </summary>
        /// <param name="valor">Valor a ser removido</param>
        public void Remover(Tipo valor)
        {
            Raiz = Remover(Raiz, valor);
        }

        /// <summary>
        /// Remove recursivamente um valor da árvore
        /// </summary>
        /// <param name="raiz">Raíz</param>
        /// <param name="valor">Valor a ser removido</param>
        private NoArvore<Tipo> Remover(NoArvore<Tipo> raiz, Tipo valor)
        {
            if (raiz == null)
                return raiz;

            // Se for menor, remove da esquerda
            if (valor.CompareTo(raiz.Info) < 0)
                raiz.Esquerda = Remover(raiz.Esquerda, valor);

            // Se for maior, remove da direita
            else if (valor.CompareTo(raiz.Info) > 0)
                raiz.Direita = Remover(raiz.Direita, valor);

            // Se for igual, remove este nó
            else
            {
                if (raiz.Esquerda == null)
                    return raiz.Direita;
                else if (raiz.Direita == null)
                    return raiz.Esquerda;

                // Pega o menor dos maiores nós e substitui o valor da raíz pelo valor dele,
                // removendo-o da árvore
                NoArvore<Tipo> menor = Menor(raiz.Direita);
                raiz.Info = menor.Info;
                raiz.Direita = Remover(raiz.Direita, menor.Info);
            }

            return raiz;
        }

        /// <summary>
        /// Obtém o menor nó de uma árvore com a raiz dada
        /// </summary>
        /// <param name="raiz">Raíz da árvore</param>
        /// <returns>Retorna o menor nó na árvore com a raíz passado</returns>
        private NoArvore<Tipo> Menor(NoArvore<Tipo> raiz)
        {
            NoArvore<Tipo> atual;
            for (atual = raiz.Esquerda; atual.Esquerda != null; atual = atual.Esquerda);

            return atual;
        }

        /// <summary>
        /// Verifica se um nó com determinado valor existe na árvore
        /// </summary>
        /// <param name="valor">Valor a ser procurado</param>
        public bool Existe(Tipo valor)
        {
            NoArvore<Tipo> atual = Raiz;
            while (atual != null && atual.Info.CompareTo(valor) != 0)
            {
                if (atual.Info.CompareTo(valor) < 0)
                    atual = atual.Esquerda;
                else
                    atual = atual.Direita;
            }

            return atual != null;
        }

        /// <summary>
        /// Percorre a árvore recursivamente em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="raiz">Raíz da árvore a ser percorrida</param>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        private void PercorrerPreOrdem(NoArvore<Tipo> raiz, Action<Tipo> callback)
        {
            callback(raiz.Info);
            PercorrerPreOrdem(raiz.Esquerda, callback);
            PercorrerPreOrdem(raiz.Direita, callback);
        }

        /// <summary>
        /// Percorre a árvore em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        public void PercorrerPreOrdem(Action<Tipo> callback)
        {
            PercorrerPreOrdem(Raiz, callback);
        }

        /// <summary>
        /// Percorre a árvore recursivamente em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="raiz">Raíz da árvore a ser percorrida</param>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        private void PercorrerPosOrdem(NoArvore<Tipo> raiz, Action<Tipo> callback)
        {
            PercorrerPosOrdem(raiz.Esquerda, callback);
            PercorrerPosOrdem(raiz.Direita, callback);
            callback(raiz.Info);
        }

        /// <summary>
        /// Percorre a árvore em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        public void PercorrerPosOrdem(Action<Tipo> callback)
        {
            PercorrerPosOrdem(Raiz, callback);
        }

        /// <summary>
        /// Percorre a árvore recursivamente em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="raiz">Raíz da árvore a ser percorrida</param>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        private void PercorrerEmOrdem(NoArvore<Tipo> raiz, Action<Tipo> callback)
        {
            PercorrerEmOrdem(raiz.Esquerda, callback);
            callback(raiz.Info);
            PercorrerEmOrdem(raiz.Direita, callback);
        }

        /// <summary>
        /// Percorre a árvore em pré-ordem e chama um callback para cada elemento percorrido
        /// </summary>
        /// <param name="callback">Função a ser chamada para cada elemento percorrido</param>
        public void PercorrerEmOrdem(Action<Tipo> callback)
        {
            PercorrerEmOrdem(Raiz, callback);
        }
    }
}
