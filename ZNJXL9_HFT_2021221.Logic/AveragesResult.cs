namespace ZNJXL9_HFT_2021221.Logic
{
    public class AveragesResult
    {
        public string ModelName { get; set; }
        public double AveragePrice { get; set; }

        public override string ToString()
        {
            return $"MODEL = {ModelName}, AVG = {AveragePrice}";
        }

        public override bool Equals(object obj)
        {
            if (obj is AveragesResult)
            {
                AveragesResult other = obj as AveragesResult;
                return this.ModelName == other.ModelName &&
                    this.AveragePrice == other.AveragePrice;
            }
            else return false;
        }
    }
}