using System.Globalization;
using BootCamp.Contexts;
using BootCamp.Models;
using CsvHelper;
using CsvHelper.Configuration;

namespace BootCamp.SandBox
{
    public class DataInjector(BootCampContext db)
    {
        private readonly BootCampContext _db = db;

        public void Insert()
        {
            var user = new User
            {
                Name = "오하라", IsActive = true, Memo = "Two ctor Data"
            };

            _db.Users.Add(user);

            var result = _db.SaveChanges();

            if (result <= 0) return;
            var list = _db.Users.ToList();

            foreach (var item in list)
            {
                Console.WriteLine($"({item.Id,3})\t{item.Name}\t\t{item.Memo}");
            }
        }

        public async Task RunAsync()
        {
            // CsvHelper
            var csvConf = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true
            };

            var csvfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Assets", "ascii_code.csv");

            var fi = new FileInfo(csvfile);
            var check = fi.Exists;

            if (!check) return;

            using var reader = new StreamReader(fi.FullName);
            using CsvReader? csv = new CsvReader(reader, csvConf);
            await csv.ReadAsync();
            csv.ReadHeader();
            while (await csv.ReadAsync())
            {
                try
                {
                    var item = csv.GetRecord<AsciiCode>();
                    var dec = Convert.ToInt32(item.Dec);
                    var asciiCode = new AsciiCode
                    {
                        Id = dec,
                        Dec = dec,
                        Oct = item.Oct,
                        Hex = item.Hex,
                        Bin = item.Bin.ToString().PadLeft(8, '0'), // $"{0:D8}"
                        Symbol = item?.Symbol ?? string.Empty,
                        HtmlNumber = item?.HtmlNumber ?? string.Empty,
                        HtmlName = item?.HtmlName ?? string.Empty,
                        Description = item?.Description ?? string.Empty,
                    };

                    _ = _db.AsciiCodes.Add(asciiCode);
                    var rs = await _db.SaveChangesAsync();
                    if(rs <= 0) continue;
                    
                    await Task.Delay(10);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}