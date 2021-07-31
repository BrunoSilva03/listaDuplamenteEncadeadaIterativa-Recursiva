using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaDuplamenteEncadeadaAEDE
{
    public class elemento
    {
        public int numero;
        public elemento proximo;
        public elemento anterior;
    }


    public class Lista
    {
        public elemento inicio = null;
        public elemento fim = null;

        public bool pesquisarIterativo(int num)
        {
            elemento auxiliar = inicio;

            while (auxiliar != null)
            {
                if (auxiliar.numero == num)
                {
                    return true;
                }
                else
                {
                    auxiliar = auxiliar.proximo;
                }
            }

            return false;
        }



        public bool pesquisarRecursivo(elemento auxiliar, int num)
        {
            if (auxiliar != null)
            {
                if (auxiliar.numero == num)
                {
                    return true;
                }
                else
                {
                    return pesquisarRecursivo(auxiliar.proximo, num);
                }
            }

            return false;
        }




        public void Inserir(int num)
        {
            if (pesquisarIterativo(num) == true)
            {
                Console.WriteLine("Esse número não pode ser inserido, pois ele já existe na Lista!");
                Console.ReadKey();
            }
            else
            {

                int option = 5;

                Console.Clear();
                Console.WriteLine("Inserir elemento no início: tecle 0");
                Console.WriteLine("Inserir elemento no fim: tecle 1");
                option = int.Parse(Console.ReadLine());

                if ((option != 1) && (option != 0))
                {
                    while ((option != 1) && (option != 0))
                    {
                        Console.Clear();
                        Console.WriteLine("Só os valores '0' e '1' são permitidos. Tente novamente!");
                        Console.WriteLine("Inserir elemento no início: tecle 0");
                        Console.WriteLine("Inserir elemento no fim: tecle 1");
                        option = int.Parse(Console.ReadLine());
                    }
                }

                if (option == 0)
                {

                    elemento novoElemento = new elemento();
                    novoElemento.numero = num;

                    if (inicio == null)
                    {

                        novoElemento.proximo = null;
                        novoElemento.anterior = null;                    //Isso se a lista já estiver vazia


                        inicio = novoElemento;
                        fim = novoElemento;
                    }
                    else
                    {
                        inicio.anterior = novoElemento;
                        novoElemento.proximo = inicio;
                        inicio = novoElemento;
                    }

                }



                if (option == 1)
                {
                    elemento novoElemento = new elemento();
                    novoElemento.numero = num;


                    if (inicio == null)
                    {

                        novoElemento.proximo = null;
                        novoElemento.anterior = null;                    //Isso se a lista já estiver vazia


                        inicio = novoElemento;
                        fim = novoElemento;
                    }
                    else
                    {
                        fim.proximo = novoElemento;
                        novoElemento.anterior = fim;
                        fim = novoElemento;
                    }
                }
            }
        }




        public void remover(int num)
        {
            elemento auxiliar = inicio;
            elemento anterior = inicio;

            while (auxiliar != null)
            {

                if (auxiliar.numero == num)
                {
                    //se auxiliar estiver no meio da lista
                    if (auxiliar != inicio && auxiliar != fim)
                    {
                        anterior = auxiliar.anterior;
                        anterior.proximo = auxiliar.proximo;
                        auxiliar = null;

                    }
                    else
                    {

                        if (auxiliar == inicio)
                        {
                            //se auxiliar == início  
                            if (auxiliar != fim)
                            {
                                inicio = auxiliar.proximo;
                                auxiliar = null;

                            }
                            else
                            {
                                //se tiver só um número na lista, se auxiliar for igual a início e a fim
                                if (auxiliar == fim)
                                {
                                    inicio = null;
                                    fim = null;

                                }
                            }

                        }
                        else
                        {
                            if (auxiliar == fim)       //se auxiliar NÃO for igual a início , mas se for igual a fim
                            {
                                //se auxiliar == fim
                                fim = auxiliar.anterior;
                                auxiliar = null;


                            }

                        }

                    }
                }

                else
                {
                    auxiliar = auxiliar.proximo;
                }
            }




        }


        #region Q4
        //4
        public void exibirIterativo()
        {
            elemento auxiliar = inicio;

            if ((inicio == null) && (fim == null))
            {
                Console.WriteLine("  ");
            }
            else
            {
                while (auxiliar != null)
                {
                    Console.WriteLine("{0} ", auxiliar.numero);
                    auxiliar = auxiliar.proximo;
                }


                Console.WriteLine("\n\nInício: {0}", inicio.numero);
                Console.WriteLine("Fim: {0}", fim.numero);
            }
        }


        public void exibirRecursivo(elemento auxiliar)
        {
            if (inicio == null)
            {
                Console.WriteLine("  ");
            }
            else
            {
                if (auxiliar != null)
                {
                    Console.WriteLine("{0} ", auxiliar.numero);
                    exibirRecursivo(auxiliar.proximo);
                }
            }
        }


        #endregion

        //5
        public void esvaziar()
        {
            inicio = null;
            fim = null;
        }




        //6
        public bool verificaListaVazia()
        {
            if ((inicio == null) && (fim == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Q7

        //7
        public void vaiEvem()
        {
            elemento auxiliar = inicio;
            elemento AntesInicio = inicio;
            int continuar = 3;

            if (verificaListaVazia() == true)
            {
                Console.WriteLine("A lista está vazia, então não tem jeito de percorrê - la");

            }
            else
            {
                while (continuar != 0)
                {

                    Console.Clear();
                    Console.WriteLine("{0} ", auxiliar.numero);
                    Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                    Console.WriteLine("(tecle 0 para sair)");
                    continuar = int.Parse(Console.ReadLine());

                    if ((continuar != 1) && (continuar != 2) && (continuar != 0))
                    {
                        while ((continuar != 1) && (continuar != 2) && (continuar != 0))
                        {
                            Console.Clear();
                            Console.WriteLine("OPÇÃO INVÁLIDA! TENTE NOVAMENTE");
                            Console.WriteLine("{0} ", auxiliar.numero);
                            Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                            Console.WriteLine("(tecle 0 para sair)");
                            continuar = int.Parse(Console.ReadLine());
                        }
                    }
                    else
                    {
                        //seguindo para o anterior
                        if (continuar == 1)
                        {

                            //se o anterior for nulo
                            if (auxiliar.anterior == null)
                            {
                                Console.Clear();
                                Console.WriteLine("Não tem anterior");
                                Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                                Console.WriteLine("(tecle 0 para sair)");
                                continuar = int.Parse(Console.ReadLine());

                                AntesInicio = null;

                                if (continuar == 1)
                                {
                                    while (continuar == 1)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Não tem anterior");
                                        Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                                        Console.WriteLine("(tecle 0 para sair)");
                                        continuar = int.Parse(Console.ReadLine());
                                    }


                                }


                            }
                            else
                            {
                                auxiliar = auxiliar.anterior;
                                Console.Clear();

                            }

                        }


                        //seguindo para o próximo
                        if (continuar == 2)
                        {
                            //se o próximo for null
                            if (auxiliar.proximo == null)
                            {
                                Console.Clear();
                                Console.WriteLine("Não tem próximo");
                                Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                                Console.WriteLine("(tecle 0 para sair)");
                                continuar = int.Parse(Console.ReadLine());


                                if (continuar == 2)
                                {
                                    while (continuar == 2)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Não tem próximo");
                                        Console.WriteLine("\n\nContinuar o percurso para o anterior(tecle 1) ou para o proximo(tecle 2)?");
                                        Console.WriteLine("(tecle 0 para sair)");
                                        continuar = int.Parse(Console.ReadLine());
                                    }



                                }



                            }
                            else
                            {


                                auxiliar = auxiliar.proximo;
                                Console.Clear();


                            }
                        }


                    }
                }

            }
        }

        #endregion

        #region Q8
        //8
        public void inserirAntes(int num)
        {

            if (pesquisarIterativo(num) == true)
            {
                Console.WriteLine("Esse número não pode ser inserido, pois ele já está presente na Lista!");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Digite o número de um elemento específico da lista em que o novo elemento será inserido antes: ");
                int elementoEsp = int.Parse(Console.ReadLine());

                if (pesquisarIterativo(elementoEsp) == false)
                {
                    while (pesquisarIterativo(elementoEsp) == false)
                    {
                        Console.WriteLine("Esse elemento específico não está presente na lista, tente outro!");
                        elementoEsp = int.Parse(Console.ReadLine());
                    }
                }
                else
                {
                    elemento auxiliar = inicio;

                    elemento novoElemento = new elemento();
                    novoElemento.numero = num;

                    while (auxiliar.numero != elementoEsp)
                    {
                        if (auxiliar.numero == elementoEsp)
                        {
                            elemento elEsp = auxiliar;
                            elEsp.anterior = novoElemento;
                           
                        }
                        else
                        {
                            auxiliar = auxiliar.proximo;
                        }
                    }
                }
            }



        }

        #endregion

        #region Q10
        //10
        public int contagemElementosIterativo()
        {
            elemento auxiliar = inicio;
            int tamanho = 0;

            while (auxiliar != null)
            {
                tamanho++;
                auxiliar = auxiliar.proximo;
            }


            return tamanho;
        }



        public int contagemElementosRecursivo(int tamanho, elemento auxiliar)
        {
            if (auxiliar != null)
            {
                tamanho++;
                return contagemElementosRecursivo(tamanho, auxiliar.proximo);
            }

            return tamanho;
        }


        #endregion

        //11
        public int contagemElementosMaioresAnteriorIterativo(int num)
        {
            elemento auxiliar = inicio;
            elemento percorre = inicio;
            elemento ElementoAnterior = inicio;
            int Maiores = 0;

            while ((auxiliar != null) && (auxiliar.numero != num))      //Achando o elemento anterior
            {
                if (auxiliar.numero == num)
                {
                    if (auxiliar == inicio)
                    {
                        Console.WriteLine("Esse elemento não tem um elemento anterior na Lista!");
                        Console.ReadKey();
                    }
                    else
                    {
                        auxiliar = auxiliar.anterior;
                        ElementoAnterior = auxiliar;
                    }
                }
                else
                {
                    auxiliar = auxiliar.proximo;
                }
            }


            while (percorre != null)  //fazendo a contagem
            {
                if (percorre.numero > ElementoAnterior.numero)
                {
                    Maiores++;
                    percorre = percorre.proximo;
                }
                else
                {
                    percorre = percorre.proximo;
                }
            }

            return Maiores;
        }




    }


    class Program
    {
        static void Main(string[] args)
        {
            int opc = 1;
            Console.Title = "LISTA DUPLAMENTE ENCADEADA";
            Lista lst = new Lista();
            while (opc != 0)
            {
                Console.Clear();
                Console.WriteLine("******************MENU PRINCIPAL********************");
                Console.WriteLine("1. pesquisar");
                Console.WriteLine("2. Inserir");
                Console.WriteLine("3. remover");
                Console.WriteLine("4. exibir");
                Console.WriteLine("5. esvaziar Lista");
                Console.WriteLine("6. Verificar se a Lista está vazia");
                Console.WriteLine("7. vai e vem");
                Console.WriteLine("8. Inserir antes de um elemento específico");
                Console.WriteLine("9. Inserir depois de um elemento específico");
                Console.WriteLine("10. contagem de elementos");
                Console.WriteLine("11. contagem de elementos maiores que o anterior");
                Console.WriteLine("12. contagem de elementos maiores que o próximo");
                opc = int.Parse(Console.ReadLine());


                switch (opc)
                {
                    case 1:
                        {
                            Console.Clear();
                            int num;

                            Console.WriteLine("Digite o número que deseja pesquisar: ");
                            num = int.Parse(Console.ReadLine());


                            if (lst.pesquisarIterativo(num) == true)
                            {
                                Console.WriteLine("O número {0} está presente na Lista!", num);
                            }
                            else
                            {
                                Console.WriteLine("O número {0} NÃO está presente na Lista!", num);
                            }
                            Console.ReadKey();




                            Console.Clear();
                            if (lst.pesquisarRecursivo(lst.inicio, num) == true)
                            {
                                Console.WriteLine("O número {0} está presente na Lista!", num);
                            }
                            else
                            {
                                Console.WriteLine("O número {0} NÃO está presente na Lista!", num);
                            }
                            Console.ReadKey();
                        }
                        break;



                    case 2:
                        {
                            Console.Clear();
                            int num;
                            Console.WriteLine("Digite o número que deseja inserir na Lista: ");
                            num = int.Parse(Console.ReadLine());

                            lst.Inserir(num);

                            Console.ReadKey();
                        }
                        break;



                    case 3:
                        {
                            Console.Clear();
                            int num;

                            if (lst.verificaListaVazia() == true)
                            {
                                Console.WriteLine("Como a lista está vazia, não dá para remover nenhum número!");
                                Console.ReadKey();
                            }
                            else
                            {

                                Console.WriteLine("Digite o número que deseja remover da lista: ");
                                num = int.Parse(Console.ReadLine());


                                if (lst.pesquisarIterativo(num) == false)
                                {
                                    Console.WriteLine("Esse número em especial não pode ser removido, por que ele não está na lista!");
                                }
                                else
                                {

                                    lst.remover(num);
                                    Console.Clear();
                                    Console.WriteLine("\nNúmero removido com sucesso!!!!!!!!!!!!!");
                                }
                            }


                            Console.ReadKey();

                        }
                        break;



                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Iterativo: ");
                            lst.exibirIterativo();

                            Console.ReadKey();


                            Console.Clear();
                            Console.WriteLine("Recursivo");
                            lst.exibirRecursivo(lst.inicio);

                            Console.ReadKey();
                        }
                        break;



                    case 5:
                        {
                            Console.Clear();
                            lst.esvaziar();
                            Console.WriteLine("Lista esvaziada com sucesso!!!!!!!");

                            Console.ReadKey();
                        }
                        break;




                    case 6:
                        {
                            Console.Clear();
                            if (lst.verificaListaVazia() == true)
                            {
                                Console.WriteLine("Atualmente a Lista está vazia!");
                            }
                            else
                            {
                                Console.WriteLine("Atualmente a Lista NÃO está vazia!");
                            }


                            Console.ReadKey();
                        }
                        break;


                    case 7:
                        {
                            Console.Clear();
                            lst.vaiEvem();

                            Console.ReadKey();
                        }
                        break;



                    case 8:
                        {
                            Console.Clear();
                            if (lst.verificaListaVazia() == true)
                            {
                                Console.WriteLine("A lista está vazia, então não há algo pra ser inserido antes");
                                Console.ReadKey();
                            }
                            else
                            {

                                Console.WriteLine("Digite o número que deseja inserir na Lista: ");
                                int num = int.Parse(Console.ReadLine());
                                lst.inserirAntes(num);


                            }
                            Console.ReadKey();
                        }
                        break;



                    case 9:
                        {

                        }
                        break;




                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine("Iterativo");
                            Console.WriteLine("A Lista atualmente tem {0} números", lst.contagemElementosIterativo());
                            Console.ReadKey();

                            int tamanho = 0;

                            Console.Clear();
                            Console.WriteLine("Recursivo");
                            Console.WriteLine("A Lista atualmente tem {0} números", lst.contagemElementosRecursivo(tamanho, lst.inicio));
                            Console.ReadKey();
                        }
                        break;



                    case 11:
                        {
                            Console.Clear();
                            int num = 0;

                            Console.WriteLine("Digite um número e veja quantos elementos na lista são maiores que o anterior a esse número.");
                            num = int.Parse(Console.ReadLine());

                            if (lst.pesquisarIterativo(num) == false)
                            {
                                Console.WriteLine("\nEse número não está presente na lista");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Iterativo: ");
                                Console.WriteLine("{0} números na lista são maiores que o elemento anterior ao número digitado.", lst.contagemElementosMaioresAnteriorIterativo(num));
                            }
                            Console.ReadKey();
                        }
                        break;
                }

            }
        }
    }
}
