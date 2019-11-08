using System.IO;
using System.Threading.Tasks;
using CsvHelper;

namespace AzTable.CsvUpload.CLI
{
	internal static class Program
	{
		private static async Task Main(string storageConnectionString = "", string storageTable = "",
			string csvFilePath = "")
		{
			var sa = await AzTableService.CreateTableAsync(storageTable, storageConnectionString).ConfigureAwait(false);

			using (var reader = new StreamReader(filePath))
			using (var csv = new CsvReader(reader))
			{
				var records = csv.GetRecords<CsvDto>();
				foreach (var r in records)
				{
					var customer = new CsvEntity(r.Id.ToString(), r.Name);
					await AzTableService.InsertOrMergeEntityAsync(sa, customer).ConfigureAwait(false);
				}
			}
		}
	}
}