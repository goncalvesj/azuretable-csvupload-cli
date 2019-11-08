using Microsoft.Azure.Cosmos.Table;

namespace AzTable.CsvUpload.CLI
{
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