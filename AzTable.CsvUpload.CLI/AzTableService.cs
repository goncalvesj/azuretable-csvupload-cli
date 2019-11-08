using System;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos.Table;

namespace AzTable.CsvUpload.CLI
{
	internal class AzTableService
	{
		public static CloudStorageAccount CreateStorageAccountFromConnectionString(string storageConnectionString)
		{
			CloudStorageAccount storageAccount;
			try
			{
				storageAccount = CloudStorageAccount.Parse(storageConnectionString);
			}
			catch (Exception)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
				throw;
			}

			return storageAccount;
		}

		public static async Task<CloudTable> CreateTableAsync(string tableName, string storageConnectionString)
		{
			var storageAccount = CreateStorageAccountFromConnectionString(storageConnectionString);

			var tableClient = storageAccount.CreateCloudTableClient(new TableClientConfiguration());
			
			var table = tableClient.GetTableReference(tableName);

			if (await table.CreateIfNotExistsAsync().ConfigureAwait(false))
				Console.WriteLine("Created Table named: {0}", tableName);
			else
				Console.WriteLine("Table {0} already exists", tableName);

			Console.WriteLine();

			return table;
		}

		public static async Task<CsvEntity> InsertOrMergeEntityAsync(CloudTable table, CsvEntity entity)
		{
			if (entity == null) throw new ArgumentNullException(nameof(entity));
			try
			{
				var insertOrMergeOperation = TableOperation.InsertOrMerge(entity);

				var result = await table.ExecuteAsync(insertOrMergeOperation);

				var insertedCustomer = result.Result as CsvEntity;

				return insertedCustomer;
			}
			catch (StorageException e)
			{
				Console.WriteLine(e.Message);
				Console.ReadLine();
				throw;
			}
		}
	}
}