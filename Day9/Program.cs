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

    private List<File> _files = new List<File>();

    protected override string ProcessPartOne()
    {
        _files = new List<File>();

        var ndx = 0;
        while (ndx < (Input.Length))
        {
            var id = _files.Count();
            var length = int.Parse(Input[ndx].ToString());
            var freeSpace = 0;
            if (Input.Length > (ndx + 1)) 
                freeSpace = int.Parse(Input[ndx + 1].ToString());
            _files.Add(new File() { Id = id, Blocks = length, FreeSpace = freeSpace });
            ndx += 2;
        }

        var checkSum = Defrag();
        return checkSum.ToString();
    }

    private long Defrag()
    {
        long csum = 0;
        var ndx = 0;
        var cnt = 0;
        while (true)
        {
            if (ndx == _files.Count())
                break;
            //Write Current Item
            for (var i = 0; i < _files[ndx].Blocks; i++)
            {
                csum += _files[ndx].Id*cnt;
                cnt++;
            }
            _files[ndx].Blocks = 0;
            
            //Fill the current files space
            while (_files[ndx].FreeSpace > 0)
            {
                var lastFile = _files.OrderByDescending(x => x.Id).FirstOrDefault(x=>x.Blocks >0);
                if (lastFile == null) break;
                var amountToMove = _files[ndx].FreeSpace > lastFile.Blocks ? lastFile.Blocks : _files[ndx].FreeSpace;
                _files[ndx].FreeSpace -= amountToMove;
                lastFile.Blocks -= amountToMove;
                for (var i = 0; i < amountToMove; i++)
                {
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
        return "-1";
    }
}