using System;
using System.Collections.Generic;

// CLASSE PRINCIPAL
public class Personagem
{
    private string nome;
    private int vida;
    private int nivel;

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Vida
    {
        get { return vida; }
        set
        {
            if (value > 100)
                vida = 100;
            else if (value < 0)
                vida = 0;
            else
                vida = value;
        }
    }

    public int Nivel
    {
        get { return nivel; }
        set { nivel = value; }
    }

    public Personagem(string nome, int vida, int nivel)
    {
        Nome = nome;
        Vida = vida;
        Nivel = nivel;
    }

    public virtual void ApresentarInformacoes()
    {
        Console.WriteLine($"Nome: {Nome} | Vida: {Vida} | Nível: {Nivel}");
    }

    protected bool VerificarVida()
    {
        if (Vida <= 0)
        {
            Console.WriteLine($"{Nome} está sem vida e não pode atacar.");
            return false;
        }

        return true;
    }

    public virtual void Atacar()
    {
        if (!VerificarVida())
            return;

        Console.WriteLine($"{Nome} realizou um ataque!");
    }

    public void ReceberDano(int dano)
    {
        if (dano > 0)
        {
            Vida -= dano;
        }
    }
}

// CLASSE GUERREIRO
public class Guerreiro : Personagem
{
    public string Arma { get; set; }

    public Guerreiro(string nome, int vida, int nivel, string arma)
        : base(nome, vida, nivel)
    {
        Arma = arma;
    }

    public override void ApresentarInformacoes()
    {
        Console.WriteLine(
            $"Nome: {Nome} | Classe: Guerreiro | Vida: {Vida} | Nível: {Nivel} | Arma: {Arma}"
        );
    }

    public override void Atacar()
    {
        if (!VerificarVida())
            return;

        Console.WriteLine($"{Nome} ataca com {Arma} e causa dano físico!");
    }
}

// CLASSE MAGO
public class Mago : Personagem
{
    public string Elemento { get; set; }

    public Mago(string nome, int vida, int nivel, string elemento)
        : base(nome, vida, nivel)
    {
        Elemento = elemento;
    }

    public override void ApresentarInformacoes()
    {
        Console.WriteLine(
            $"Nome: {Nome} | Classe: Mago | Vida: {Vida} | Nível: {Nivel} | Elemento: {Elemento}"
        );
    }

    public override void Atacar()
    {
        if (!VerificarVida())
            return;

        Console.WriteLine($"{Nome} lança uma magia de {Elemento}!");
    }
}

// CLASSE ARQUEIRO - DESAFIO EXTRA
public class Arqueiro : Personagem
{
    public int QuantidadeFlechas { get; set; }

    public Arqueiro(string nome, int vida, int nivel, int quantidadeFlechas)
        : base(nome, vida, nivel)
    {
        QuantidadeFlechas = quantidadeFlechas;
    }

    public override void ApresentarInformacoes()
    {
        Console.WriteLine(
            $"Nome: {Nome} | Classe: Arqueiro | Vida: {Vida} | Nível: {Nivel} | Flechas: {QuantidadeFlechas}"
        );
    }

    public override void Atacar()
    {
        if (!VerificarVida())
            return;

        if (QuantidadeFlechas > 0)
        {
            Console.WriteLine($"{Nome} dispara uma flecha contra o inimigo!");
            QuantidadeFlechas--;
        }
        else
        {
            Console.WriteLine($"{Nome} está sem flechas!");
        }
    }
}

// PROGRAMA PRINCIPAL
class Program
{
    static void Main(string[] args)
    {
        // CRIANDO OS PERSONAGENS
        Guerreiro guerreiro1 = new Guerreiro(
            "Thorin", 100, 5, "Machado de Batalha"
        );

        Guerreiro guerreiro2 = new Guerreiro(
            "Brutus", 0, 3, "Espada Longa"
        );

        Mago mago1 = new Mago(
            "Merlin", 80, 7, "Fogo"
        );

        Mago mago2 = new Mago(
            "Morgana", 90, 6, "Gelo"
        );

        Arqueiro arqueiro1 = new Arqueiro(
            "Legolas", 75, 8, 10
        );

        // LISTA DE PERSONAGENS
        List<Personagem> personagens = new List<Personagem>();

        personagens.Add(guerreiro1);
        personagens.Add(guerreiro2);
        personagens.Add(mago1);
        personagens.Add(mago2);
        personagens.Add(arqueiro1);

        // APRESENTANDO OS PERSONAGENS
        Console.WriteLine("========== PERSONAGENS ==========");

        foreach (Personagem personagem in personagens)
        {
            personagem.ApresentarInformacoes();
        }

        // EXECUTANDO OS ATAQUES
        Console.WriteLine();
        Console.WriteLine("========== BATALHA ==========");

        foreach (Personagem personagem in personagens)
        {
            personagem.Atacar();
        }

        // TESTANDO A VIDA
        Console.WriteLine();
        Console.WriteLine("========== TESTE DA VIDA ==========");

        Personagem teste1 = new Personagem("Teste 150", 150, 1);
        Personagem teste2 = new Personagem("Teste -20", -20, 1);

        Console.WriteLine(
            $"Vida informada 150 -> Vida registrada: {teste1.Vida}"
        );

        Console.WriteLine(
            $"Vida informada -20 -> Vida registrada: {teste2.Vida}"
        );

        // TESTANDO O RECEBIMENTO DE DANO
        Console.WriteLine();
        Console.WriteLine("========== TESTE DE DANO ==========");

        guerreiro1.ReceberDano(30);

        Console.WriteLine(
            $"{guerreiro1.Nome} recebeu 30 de dano. Vida atual: {guerreiro1.Vida}"
        );

        Console.WriteLine();
        Console.WriteLine("========== FIM DO RPG ==========");
    }
}