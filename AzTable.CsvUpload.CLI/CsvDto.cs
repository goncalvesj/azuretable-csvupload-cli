using Microsoft.Azure.Cosmos.Table;

namespace AzTable.CsvUpload.CLI
{
	internal class CsvDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}

	internal class CsvEntity : TableEntity
	{
		public CsvEntity()
		{
		}

		public CsvEntity(string id, string name)
		{
			PartitionKey = id;
			RowKey = name;
		}
	}
}