namespace CodeWars.BuildTower
{
    public class BuildTower
    {
        public static string[] Build(int numberOfFloors)
        {
            var result = new string[numberOfFloors];
            for (var i = 0; i < numberOfFloors; i++)
            {
                var floor = new string('*', i * 2 + 1);
                floor = floor.PadLeft(numberOfFloors + i);
                floor = floor + new string(' ', numberOfFloors - (i + 1));
                result[i] = floor;
            }
            return result;
        }
    }

    public class Kata
    {
        public static string[] TowerBuilder(int nFloors)
        {
            var result = new string[nFloors];
            for (var i = 0; i < nFloors; i++)
            {
                var floor = new string('*', i * 2 + 1);
                floor = floor.PadLeft(nFloors + i);
                floor = floor + new string(' ', nFloors - (i + 1));
                result[i] = floor;
            }
            return result;
        }
    }
}
