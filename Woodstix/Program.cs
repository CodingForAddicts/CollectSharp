// See https://aka.ms/new-console-template for more information

Console.WriteLine("------------------- Fundamentals/HandyHelmets.cs -------------------");

List<int> d2 = new List<int> { 0, 1, 0, 3, 5, 6 };
Woodstix.Fundamentals.HandyHelmets.Boxidize(d2);

List<int> c2 = new List<int> { 0, 1, 0, 3, 5, 6 };
(int, int) cr2 = Woodstix.Fundamentals.HandyHelmets.GetMinMax(c2); // cr2 = (1, 5)

Console.WriteLine("Min, Max = " +cr2);

List<int> e1 = new List<int> { 5, 1, 2, 1, 2, 3, 4, 5 };
List<int> er1 = Woodstix.Fundamentals.HandyHelmets.BoxSort(e1); // er1 = { 1, 1, 2, 2, 3, 4, 5, 5 }

Console.Write("{");
er1.ForEach(item => Console.Write(item + ","));
Console.Write("}");

Console.WriteLine("");


Console.WriteLine("-------------------- Fundamentals/Management.cs --------------------");

(int, int) h1 = Woodstix.Fundamentals.Encryptions.GetRepetitionNumber("12[ab]", 0);        // h1 = (12, 2)
(int, int) h2 = Woodstix.Fundamentals.Encryptions.GetRepetitionNumber("2740[ab]3[cd]", 0); // h2 = (2740, 4)
(int, int) h3 = Woodstix.Fundamentals.Encryptions.GetRepetitionNumber("12[ab]3[cd]", 6);   // h3 = (3, 7)
(int, int) h4 = Woodstix.Fundamentals.Encryptions.GetRepetitionNumber("12[3[ab]]", 3);     // h4 = (3, 4)

Console.WriteLine(h1);
Console.WriteLine(h2);
Console.WriteLine(h3);
Console.WriteLine(h4);

Console.WriteLine("-------------------- Fundamentals/Encryptions.cs --------------------");





List<int> k1 = new List<int> { 5, 3, 1, 2, 4 };
int kr1 = Woodstix.Proficiencies.RollingStone.Partition(k1, 0, 4); // kr1 = 3, k1 = { 3, 1, 2, 4, 5 }


Console.WriteLine(kr1);