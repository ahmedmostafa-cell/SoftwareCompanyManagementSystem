using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EibtekSystemProject
{
    public static class SD
    {
        static SD()
        {
            DealthyHallowRace = new Dictionary<string, int>();
            DealthyHallowRace.Add(Cloak, 0);
            DealthyHallowRace.Add(Stone, 0);
            DealthyHallowRace.Add(Wand, 0);
        }

        public const string Wand = "wand";
        public const string Stone = "stone";
        public const string Cloak = "cloak";

        public static Dictionary<string, int> DealthyHallowRace;
        public const string Success = "Success";
        public const string Error = "Error";
    }
}
