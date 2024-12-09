using System.ComponentModel.DataAnnotations;
using System.Data;
using AocBase;
using Microsoft.VisualBasic;

var day = new Day9("1928", "2858", "6301895872542", "");
day.Solve(true);

public class Day9 : Day
{
    public Day9(string expectedSampleResult, string expectedSampleResultTwo, string expectedResult,
        string expectedResultTwo) : base(expectedSampleResult, expectedSampleResultTwo, expectedResult,
        expectedResultTwo)
    {
    }

    public List<File> files = new List<File>();

    protected override string ProcessPartOne()
    {
        files = new List<File>();

        var ndx = 0;
        while (ndx < (Input.Length))
        {
            var id = files.Count();
            var length = int.Parse(Input[ndx].ToString());
            var freeSpace = 0;
            if (Input.Length > (ndx + 1)) freeSpace = int.Parse(Input[ndx + 1].ToString());
            files.Add(new File() { Id = id, Blocks = length, FreeSpace = freeSpace });
            ndx += 2;
        }

        var checkSum = Defrag();
        return checkSum.ToString();
    }

    private long Defrag(bool partTwo = false)
    {
        long csum = 0;
        Console.WriteLine("Defrag");
        var ndx = 0;
        var cnt = 0;
        while (true)
        {
            if (ndx == files.Count())
                break;
            //Write Current Item
            for (var i = 0; i < files[ndx].Blocks; i++)
            {
                Console.WriteLine($"{cnt} {files[ndx].Id}");
                csum += files[ndx].Id*cnt;
                cnt++;
            }
            files[ndx].Blocks = 0;
            
            //Fill the current files space
            while (files[ndx].FreeSpace > 0)
            {
                var lastFile = files.OrderByDescending(x => x.Id).FirstOrDefault(x=>x.Blocks >0 && (!partTwo || x.Blocks <= files[ndx].FreeSpace));
                if (lastFile == null) break;
                var amountToMove = files[ndx].FreeSpace > lastFile.Blocks ? lastFile.Blocks : files[ndx].FreeSpace;
                files[ndx].FreeSpace -= amountToMove;
                lastFile.Blocks -= amountToMove;
                
                for (var i = 0; i < amountToMove; i++)
                {
                    Console.WriteLine($"{cnt} {lastFile.Id}");
                    csum += lastFile.Id*cnt;
                    cnt++;
                }
            }

            ndx++;
        }

        return csum;
    }

    protected override string ProcessPartTwo()
    {
        files = new List<File>();

        var ndx = 0;
        while (ndx < (Input.Length))
        {
            var id = files.Count();
            var length = int.Parse(Input[ndx].ToString());
            var freeSpace = 0;
            if (Input.Length > (ndx + 1)) freeSpace = int.Parse(Input[ndx + 1].ToString());
            files.Add(new File() { Id = id, Blocks = length, FreeSpace = freeSpace });
            ndx += 2;
        }

        var checkSum = Defrag(true);
        return checkSum.ToString();
    }
}

public class File
{
    public int Id { get; set; }
    public int Blocks { get; set; }
    public int FreeSpace { get; set; }

    public string ToString()
    {
        var result = "";
        for (var i = 0; i < Blocks; i++) result += Id;
        //ID * Blocks
        for (var i = 0; i < FreeSpace; i++) result += ".";
        //FreeSpace = .
        return result;
    }
}