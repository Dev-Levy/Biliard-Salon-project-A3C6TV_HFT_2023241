using System;

namespace A3C6TV_HFT_2023241.Logic
{
    public class BookingInfo
    {
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Table { get; set; }

        public override bool Equals(object obj)
        {
            BookingInfo b = obj as BookingInfo;
            if (b == null)
                return false;
            else
                return Name == b.Name 
                    && Start == b.Start 
                    && End == b.End 
                    && Table == b.Table;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Start, End, Table);
        }
    }
}