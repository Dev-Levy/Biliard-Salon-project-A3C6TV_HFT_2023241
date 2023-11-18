using System;

namespace A3C6TV_HFT_2023241.Logic
{
    public class Frequenter
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            Frequenter other = obj as Frequenter;
            if (other == null) 
                return false;
            else
                return Name == other.Name && Count == other.Count;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Count);
        }
    }
}