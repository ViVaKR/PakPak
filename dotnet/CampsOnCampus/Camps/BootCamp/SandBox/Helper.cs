using System.Globalization;
using CsvHelper.Configuration;

namespace BootCamp.SandBox
{
    public class Helper
    {
        public void CsvCamp(string path)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                NewLine = Environment.NewLine


            };
        }
    }
}