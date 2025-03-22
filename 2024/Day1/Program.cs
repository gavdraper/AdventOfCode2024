var input = File.ReadAllText("input.txt");
var lines = input.Split('\n');

var listOne = new List<int>();
var listTwo = new List<int>();
var partTwoList = new List<int>();

foreach (var l in lines)
{
    var numbers = l.Split("   ");
    listOne.Add(int.Parse(numbers[0]));
    listTwo.Add(int.Parse(numbers[1]));
}

listOne.Sort();
listTwo.Sort();

var delta = 0;

for (var i = 0; i < listOne.Count; i++)
{
    delta += Math.Abs(listOne[i] - listTwo[i]);
    partTwoList.Add(listOne[i] * listTwo.Count(x => x == listOne[i]));
}

Console.WriteLine("Part 1");
Console.WriteLine(delta);

Console.WriteLine("Part 2");
Console.WriteLine(partTwoList.Sum());

Console.WriteLine("----------------");
Console.WriteLine("Test Pass/Fail");
if (delta == 3569916 && partTwoList.Sum() == 26407426)
    Console.WriteLine("Pass");
else Console.WriteLine("Fail");

Console.ReadLine();