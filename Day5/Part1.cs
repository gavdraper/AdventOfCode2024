// var input = File.ReadAllText("input.txt");
// var lines = input.Split('\n');
//
// var rawOrder = new Dictionary<int, List<int>> ();
// var pages = new List<List<int>>();
//
// for (var i = 0; i < lines.Count(); i++)
// {
//     if (lines[i].Contains("|"))
//     {
//         var order =  lines[i].Split('|').Select(x => int.Parse(x)).ToList();
//         if(!rawOrder.ContainsKey(order[0]))
//             rawOrder.Add(order[0],new List<int>());
//         rawOrder[order[0]].Add(order[1]);
//     }
//     else if (lines[i].Contains(","))
//     {
//         pages.Add(lines[i].Split(',').Select(x=>int.Parse(x)).ToList());
//     }
// }
//
//
// var middleNoSum = 0;
// foreach (var p in pages)
// {
//     Console.WriteLine("Checking page Starting : " + p[0]);
//     var correctOrder = true;
//     for (var i = 1; i < p.Count(); i++)
//     {
//         var current = p[i];
//
//         for (var x = 0; x < i; x++)
//         {
//             //Are there any rules saying current should be before prior?
//             if (rawOrder.ContainsKey(current) && rawOrder[current].Contains(p[x]))
//             {
//                 correctOrder = false;
//                 Console.WriteLine("   Failed On " + current.ToString() + " at position " + x);
//             }
//         }
//     }
//
//     if (correctOrder)
//     {
//         var middleIndex = p.Count() / 2;
//         middleNoSum += p[middleIndex];
//     }
// }
//
// Console.WriteLine($"Part 1: {middleNoSum}");