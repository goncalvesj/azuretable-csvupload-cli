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
			var table = await AzTableService.CreateTableAsync(storageTable, storageConnectionString).ConfigureAwait(false);

			using (var reader = new StreamReader(csvFilePath))
			using (var csv = new CsvReader(reader))
			{
				var records = csv.GetRecords<CsvDto>();
				foreach (var r in records)
				{
					var entity = new CsvEntity(r.Id.ToString(), r.Name);
					await AzTableService.InsertOrMergeEntityAsync(table, entity).ConfigureAwait(false);
				}
			}
		}
	}
}