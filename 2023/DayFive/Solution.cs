using DayFive;
using DayFour;
using Xunit.Sdk;

namespace DayFive
{

    public class Seed
    {
        public Int64 Number { get; set; }
        public Int64 Soil { get; set; }
        public Int64 Fertilizer { get; set; }
        public Int64 Water { get; set; }
        public Int64 Light { get; set; }
        public Int64 Temp { get; set; }
        public Int64 Humidity { get; set; }
        public Int64 Location { get; set; }
    }

    public class Range
    {
        public Int64 SourceStart { get; set; }
        public Int64 DestinationStart { get; set; }
        public Int64 SourceEnd { get; set; }
        public Int64 DestinationEnd { get; set; }
    }




    internal class Solution
    {
        private Dictionary<string, List<Range>> Maps = new Dictionary<string, List<Range>>();

        public List<Seed> Parse(string[] lines, bool partTwo=false)
        {
            Maps = new Dictionary<string, List<Range>>();
            var seeds = lines[0].Split(":")[1].Split(" ").Where(x => x != "").Select(x=> Int64.Parse(x)).ToList();
            var seedsTwo = new List<Int64>();
            if (partTwo)
            {
                for (var i = 0; i < seeds.Count; i++)
                {
                    if (int.IsOddInteger(i))
                    {
                        var start = seeds[i - 1];
                        for(var num=0;num < seeds[i] ; num++ )
                            seedsTwo.Add(seeds[i - 1] + num);
                    }
                }

                seeds = seedsTwo;
            }
            
            var mapGroup = "";

            for (var i = 2; i < lines.Length; i++)
            {
                if (mapGroup == "")
                {
                    mapGroup = lines[i].Substring(
                        lines[i].LastIndexOf("-")+1,
                        lines[i].IndexOf(" map") - (lines[i].LastIndexOf("-")+1));
                    Maps.Add(mapGroup, new List<Range>());
                }
                else
                {
                    if (lines[i] == "")
                    {
                        mapGroup = "";
                        continue;
                    }

                    var ranges = lines[i].Split(" ");
                    var destinationStart = Int64.Parse(ranges[0]);
                    var sourceStart = Int64.Parse(ranges[1]);
                    var rangeLength = Int64.Parse(ranges[2]);


                    Maps[mapGroup].Add(new Range()
                    {
                        SourceStart = sourceStart,
                        SourceEnd = sourceStart + rangeLength - 1,
                        DestinationStart = destinationStart,
                        DestinationEnd = destinationStart + rangeLength - 1
                    });
                    
                }
            }

            var seedObjects = new List<Seed>();
            foreach (var s in seeds)
            {
                var seed = new Seed();
                seed.Number = s;
                seed.Soil = GetMap(Maps["soil"], s); //.FirstOrDefault(x=>x.SourceStart >= s && x.SourceEnd <= s) ??  s);
                seed.Fertilizer = GetMap(Maps["fertilizer"], seed.Soil);
                seed.Water = GetMap(Maps["water"], seed.Fertilizer);
                seed.Light = GetMap(Maps["light"], seed.Water);
                seed.Temp = GetMap(Maps["temperature"], seed.Light);
                seed.Humidity = GetMap(Maps["humidity"], seed.Temp);
                seed.Location = GetMap(Maps["location"], seed.Humidity);
                seedObjects.Add(seed);
            }

            return seedObjects;
        }

        public Int64 GetMap(List<Range> range, Int64 source)
        {
            var overlap = range.SingleOrDefault(x => x.SourceStart <= source && x.SourceEnd >= source);
            if (overlap == null)
                return source;
            var mappedDestination = overlap.DestinationStart + (source -  overlap.SourceStart);
            return mappedDestination;
        }

        public Result Solve(string input)
        {
            var lines = input.Split(Environment.NewLine);

            var seeds = Parse(lines);
            var minLocation = seeds.Min(x => x.Location);

             seeds = Parse(lines, true);
            var minLocation2 = seeds.Min(x => x.Location);
            return new Result(minLocation, minLocation2);
        }
    }
}
