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