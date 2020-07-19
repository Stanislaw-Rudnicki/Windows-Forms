using System;
using System.Windows.Forms;

namespace Wf04_1_t01
{
    [Serializable]
    public class Student
    {
        public static SortOrder sortOrder { get; set; }
        public string PIB { get; set; }
        public DateTime Bday { get; set; }
        public double Avg { get; set; }

        public string DisplayMember => $"{PIB}, {Bday.ToShortDateString()}, {Math.Round(Avg, 2)}";

        public override string ToString()
        {
            return $"{PIB}, {Bday.ToShortDateString()}, {Math.Round(Avg, 2)}";
        }

        public string[] ToStringArray()
        {
            return new string[] {$"{PIB}", $"{Bday.ToShortDateString()}", $"{Math.Round(Avg, 2)}" };
        }
    }
}
