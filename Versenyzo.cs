using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dogajavitas1104;

internal class Versenyzo
{
    public string Nev {  get; set; }
    public int SzulEv { get; set; }
    public string RSzam { get; set; }
    public bool Nem { get; set; }
    public string Kategoria { get; set; }
    public Dictionary<string, TimeSpan> Idok { get; set; }

    public override string ToString() => $"[{RSzam}] {Nev} ({Kategoria})";

    public int OsszIdo => (int)Idok.Values.Sum(x => x.TotalSeconds);

    public Versenyzo(string sor)
    {
        string[] s = sor.Split(';');
        Nev = s[0];
        SzulEv = int.Parse(s[1]);
        RSzam = s[2];
        Nem = s[3] == "f";
        Kategoria = s[4];
        Idok = new()
        {
            {"úszás", TimeSpan.Parse(s[5]) },
            {"I. depó", TimeSpan.Parse(s[6]) },
            {"kerékpár", TimeSpan.Parse(s[7]) },
            {"II. depó", TimeSpan.Parse(s[8]) },
            {"futás", TimeSpan.Parse(s[9]) },

        };
    }
}
