bool[] portas = new bool[3];
var rand = new Random();
int portaEscolhida=0;
int portaExibida;
bool trocar = false;
int vezes = 10_000_000;
int ganhou = 0;
int perdeu = 0;

for (int i = 0; i < vezes; i++)
{
    //sortear uma porta para o premio, preencher outras com cabra
    sorteiaPorta();

    //escolher uma porta
    portaEscolhida = escolhePorta();

    //exibe uma porta
    portaExibida = exibeUmaPorta(portaEscolhida);

    //trocar de porta
    if (trocar) portaEscolhida = trocaPorta(portaEscolhida, portaExibida);

    if (portas[portaEscolhida])
    {
        ganhou += 1;
    }
    else
    {
        perdeu += 1;
    }
}

Console.WriteLine($"Ganhou {ganhou:n0} | Perdeu {perdeu:n0}");


void sorteiaPorta()
{
    portas = new bool[3];
    portas[rand.Next(3)] = true;
}

int escolhePorta()
{
    return rand.Next(3);
}

int exibeUmaPorta(int portaEscolhida)
{
    //se o participante escolheu  a porta correta
    if (portas[portaEscolhida] == true)
    {
        if (portaEscolhida == 0)
        {
            //exibe porta 1 ou 2
            return rand.Next(1, 3);
        }
        else if (portaEscolhida == 1)
        {
            //exibe porta 0 ou 2 (sorteia 0 ou 1, se for 0, mostra, se for 1, mostra a 2
            return rand.Next(0, 2) == 0 ? 0 : 2;
        }
        else if (portaEscolhida == 2)
        {
            //exibe porta 0 ou 1
            return rand.Next(0, 2);
        }
    }
    else
    {
        if (portaEscolhida == 0)
        {
            //se a porta com o prêmio é a 1, mostra a 2
            return portas[1] ? 2 : 1;
        }
        else if (portaEscolhida == 1)
        {
            //se a porta com o prêmio é a 2, mostra a 0
            return portas[2] ? 0 : 2;
        }
        else if (portaEscolhida == 2)
        {
            //se a porta com o prêmio é a 0, mostra a 1
            return portas[0] ? 1 : 0;
        }
    }

    return 0;

}

void imprimePortas()
{
    for (int i = 0; i < portas.Length; i++)
    {
        Console.WriteLine($"Porta {i} = {portas[i]}");
    }
}

int trocaPorta(int portaEscolhida, int portaExibida)
{
    if (portaEscolhida == 0)
    {
        //se a porta exibida foi a 1, troca a escolhida pela 2
        return portaExibida == 1 ? 2 : 1;
    }
    else if (portaEscolhida == 1)
    {
        //se a porta exibida foi a 2, troca a escolhida pela 0
        return portaExibida == 2 ? 0 : 2;
    }
    else if (portaEscolhida == 2)
    {
        //se a porta exibida foi a 0, troca a escolhida pela 1
        return portaExibida == 0 ? 1 : 0;
    }
    return 0;
}