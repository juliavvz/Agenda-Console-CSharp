using System.Collections.Generic;

public class Contatos
{
    private List<Contato> agenda;

    public IReadOnlyList<Contato> Agenda
    {
        get { return agenda.AsReadOnly(); }
    }

    public Contatos()
    {
        agenda = new List<Contato>();
    }

    public bool adicionar(Contato c)
    {
        if (agenda.Contains(c))
        {
            return false;
        }

        agenda.Add(c);
        return true;
    }

    public Contato pesquisar(Contato c)
    {
        foreach (Contato contato in agenda)
        {
            if (contato.Equals(c))
            {
                return contato;
            }
        }

        return null;
    }

    public bool alterar(Contato c)
    {
        Contato contato = pesquisar(c);

        if (contato == null)
        {
            return false;
        }

        int indice = agenda.IndexOf(contato);
        agenda[indice] = c;

        return true;
    }

    public bool remover(Contato c)
    {
        Contato contato = pesquisar(c);

        if (contato == null)
        {
            return false;
        }

        return agenda.Remove(contato);
    }
}