using System;

namespace A3C6TV_HFT_2023241.Models
{
    public class TableRate
    {

        public int? PoolsBookedNum { get; set; }
        public int? SnookersBookedNum { get; set; }
        public TableRate()
        {

        }
        public TableRate(int? poolsBookedNum, int? snookersBookedNum)
        {
            PoolsBookedNum = poolsBookedNum;
            SnookersBookedNum = snookersBookedNum;
        }

        public override bool Equals(object obj)
        {
            TableRate other = obj as TableRate;
            if (other == null)
                return false;
            else
                return PoolsBookedNum == other.PoolsBookedNum && SnookersBookedNum == other.SnookersBookedNum;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PoolsBookedNum, SnookersBookedNum);
        }
    }
}
