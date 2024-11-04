using Dogajavitas1104;
using System.Text;

List<Versenyzo> versenyzok = [];
using StreamReader sr = new("..\\..\\..\\src\\forras.txt", Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyzők száma: {versenyzok.Count}");

var f1 = versenyzok.Count(v => v.Kategoria == "25-29");
Console.WriteLine($"25-29 kategóriában a versenyzők száma: {f1} fő");

var f2 = versenyzok.Average(v => 2014 - v.SzulEv);
Console.WriteLine($"versenyzők átlagéletkora: {f2:0.00} év");

//TimeSpan t1 = new(00, 30, 00);
//TimeSpan t2 = new(02, 00, 00);
//TimeSpan ot = t1 + t2;
//Console.WriteLine(ot.Hours);

var f3 = versenyzok.Sum(v => v.Idok["úszás"].TotalHours);
Console.WriteLine($"úszással töltött órák száma: {f3:0.00}");

var f4 = versenyzok.Where(v => v.Kategoria == "elit").Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"átlagos úszással töltött idő elit kategóriában: {f4:0.00} perc");

var f5 = versenyzok.Where(v => v.Nem).MinBy(v => v.OsszIdo);
Console.WriteLine($"győztes férfi: {f5}");

var f6 = versenyzok.GroupBy(v => v.Kategoria).OrderBy(g => g.Key);
Console.WriteLine($"kategóriánként a versenyt befejezők száma:");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{grp.Key,11}: {grp.Count(),2}");
}

var f7 = versenyzok
    .GroupBy(v => v.Kategoria)
    .ToDictionary(g => g.Key, g => g.Average(v => 
    v.Idok["I. depó"].TotalMinutes + 
    v.Idok["II. depó"].TotalMinutes))
    .OrderBy(kvp => kvp.Key);
Console.WriteLine($"kategóriánként az átlagos depó idő:");
foreach (var kvp in f7)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}

var f8 = versenyzok.Count(v => v.Kategoria == "elit");
Console.WriteLine($"elit kategóriában a versenyzők száma: {f8} fő");

var f9 = versenyzok
    .Where(v => v.Nem == false)
    .Average(v => 2014 - v.SzulEv);
Console.WriteLine($"női versenyzők átlagéletkora: {f9:0.00} év");

var f10 = versenyzok.Sum(v => v.Idok["kerékpár"].TotalHours);
Console.WriteLine($"kerékpározással töltött órák száma: {f10:0.00}");

var f11 = versenyzok.Where(v => v.Kategoria == "elit junior").Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"átlagos úszással töltött idő elit junior kategóriában: {f11:0.00} perc");

Console.WriteLine($"győztes férfi: {f5}");

Console.WriteLine($"kategóriánként a versenyt befejezők száma:");
foreach (var grp in f6)
{
    Console.WriteLine($"\t{grp.Key,11}: {grp.Count(),2}");
}

var f14 = versenyzok.Count(v => v.Kategoria == "elit junior");
Console.WriteLine($"elit junior kategóriában a versenyzők száma: {f14} fő");

var f15 = versenyzok
    .Where(v => v.Nem)
    .Average(v => 2014 - v.SzulEv);
Console.WriteLine($"férfi versenyzők átlagéletkora: {f15:0.00} év");

var f16 = versenyzok.Sum(v => v.Idok["futás"].TotalHours);
Console.WriteLine($"futással töltött órák száma: {f16:0.00}");

var f17 = versenyzok.Where(v => v.Kategoria == "20-24").Average(v => v.Idok["úszás"].TotalMinutes);
Console.WriteLine($"átlagos úszással töltött idő 20-24 kategóriában: {f17:0.00} perc");

var f18 = versenyzok.Where(v => v.Nem == false).MinBy(v => v.OsszIdo);
Console.WriteLine($"női győztes: {f18}");

var f19 = versenyzok.GroupBy(v => v.Nem).OrderBy(g => g.Key);
Console.WriteLine($"nemenként a versenyt befejezők száma:");
foreach (var grp in f19)
{
    Console.WriteLine($"\t{grp.Key,11}: {grp.Count(),2}");
}

var f20 = versenyzok
    .GroupBy(v => v.Nem)
    .ToDictionary(g => g.Key, g => g.Average(v =>
    v.Idok["I. depó"].TotalMinutes +
    v.Idok["II. depó"].TotalMinutes))
    .OrderBy(kvp => kvp.Key);
Console.WriteLine($"korkategóriánként az átlagos depó idő:");
foreach (var kvp in f20)
{
    Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");
}