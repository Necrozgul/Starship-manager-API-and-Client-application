namespace ZNJXL9_HFT_2021221.Logic
{
    public class AveragesResult
    {
        public string BrandName { get; set; }
        public double AveragePrice { get; set; }

        public override string ToString()
        {
            return $"BRAND = {BrandName}, AVG = {AveragePrice}";
        }

        public override bool Equals(object obj)
        {
            if (obj is AveragesResult)
            {
                AveragesResult other = obj as AveragesResult;
                return this.BrandName == other.BrandName &&
                    this.AveragePrice == other.AveragePrice;
            }
            else return false;
        }
    }
}