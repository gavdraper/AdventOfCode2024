using System.Drawing;
using System.Runtime.CompilerServices;

var input = File.ReadAllText("input.txt");
var grid = new Grid(input.Split('\n'));

var foundWords = 0;
for (var y = 0; y < grid.RowCount; y++)
{
    for (var x = 0; x < grid.ColCount; x++)
        foundWords += grid.MatchCount(x, y);
}

Console.WriteLine(foundWords);

class Grid
{
    private List<string> rows;
    public int RowCount => rows.Count();
    public int ColCount => rows[0].Count();

    public Grid(string[] input)
    {
        rows = input.ToList();
    }

    public int MatchCount(int x, int y)
    {
        if (rows[y][x] == 'A')
        {
            var topLeft = new Point(x - 1, y - 1);
            var bottomLeft = new Point(x - 1, y + 1);
            var topRight = new Point(x + 1, y - 1);
            var bottomRight = new Point(x + 1, y + 1);

            if (isValidXY(topLeft) && isValidXY(topRight) && isValidXY(bottomLeft) && isValidXY(bottomRight))
            {
                if (
                    (
                        (rows[topLeft.Y][topLeft.X] == 'M' && rows[bottomRight.Y][bottomRight.X] == 'S')
                        || (rows[topLeft.Y][topLeft.X] == 'S' && rows[bottomRight.Y][bottomRight.X] == 'M')
                    ) &&
                    (
                        (rows[bottomLeft.Y][bottomLeft.X] == 'M' && rows[topRight.Y][topRight.X] == 'S')
                        || (rows[bottomLeft.Y][bottomLeft.X] == 'S' && rows[topRight.Y][topRight.X] == 'M')
                    )
                )
                    return 1;

            }

            return 0;
        }

        return 0;
    }



    private bool isValidXY(Point pos)
    {
        return isValidXY(pos.X, pos.Y);
    }

    private bool isValidXY(int x, int y)
    {
        return
            (x >= 0 && x < ColCount) &&
            (y >= 0 && y < RowCount);
    }
}