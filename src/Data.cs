using System;

public class Data
{
    private int dia;
    private int mes;
    private int ano;

    public Data(int dia, int mes, int ano)
    {
        setData(dia, mes, ano);
    }

    public void setData(int dia, int mes, int ano)
    {
        this.dia = dia;
        this.mes = mes;
        this.ano = ano;
    }

    public override string ToString()
    {
        return $"{dia:00}/{mes:00}/{ano:0000}";
    }

    public int Dia
    {
        get { return dia; }
    }

    public int Mes
    {
        get { return mes; }
    }

    public int Ano
    {
        get { return ano; }
    }
}