using System.Diagnostics.Tracing;
using System.Security.Cryptography.X509Certificates;

string[] lines = File.ReadAllLines("ub2017egyeni.txt");
List<szerkezet> adat = new List<szerkezet>();


struct szerkezet
{
    public string nev;
    public int rajtszam;
    public string nem;
    public int ido;
    public int szazalek;

    public szerkezet(string line)
    {
        string[] splitted = line.Split(';');

        nev = splitted[0];
        rajtszam = int.Parse(splitted[1]);
        nem = splitted[2];
        ido = int.Parse(splitted[3]);
        szazalek = int.Parse(splitted[4]);

    }
    
}