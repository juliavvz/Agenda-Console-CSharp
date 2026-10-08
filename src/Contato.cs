using System;
using System.Collections.Generic;

public class Contato
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public Data DtNasc { get; set; }

    private List<Telefone> telefones;

    public Contato(string nome, string email, Data dtNasc)
    {
        Nome = nome;
        Email = email;
        DtNasc = dtNasc;
        telefones = new List<Telefone>();
    }

    public int getIdade()
    {
        DateTime hoje = DateTime.Today;

        int idade = hoje.Year - DtNasc.Ano;

        if (hoje.Month < DtNasc.Mes ||
            (hoje.Month == DtNasc.Mes && hoje.Day < DtNasc.Dia))
        {
            idade--;
        }

        return idade;
    }

    public void adicionarTelefone(Telefone t)
    {
        if (t.Principal)
        {
            foreach (Telefone telefone in telefones)
            {
                telefone.Principal = false;
            }
        }

        telefones.Add(t);
    }

    public string getTelefonePrincipal()
    {
        foreach (Telefone telefone in telefones)
        {
            if (telefone.Principal)
            {
                return telefone.Numero;
            }
        }

        return "Nenhum telefone principal";
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Email: {Email}\n" +
               $"Data de nascimento: {DtNasc}\n" +
               $"Idade: {getIdade()}\n" +
               $"Telefone principal: {getTelefonePrincipal()}";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is Contato))
        {
            return false;
        }

        Contato outro = (Contato)obj;

        return Email.Equals(
            outro.Email,
            StringComparison.OrdinalIgnoreCase
        );
    }

    public override int GetHashCode()
    {
        return Email.ToLower().GetHashCode();
    }
}