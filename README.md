# azuretable-csvupload-cli
CLI app to read a CSV file and upload the data into an azure storage table

# Steps
1. Create a CSV file.
	- First row should be column names.
	- Insert test data

2. Replicate the column names in ```CsvDto.cs``` and ```CsvEntity.cs```

3. Map the fields in program.cs

```
var entity = new CsvEntity(r.Id.ToString(), r.Name) 
{
	Field1 = "".
	Field2 = ""
};
```

4. Publish the app to a folder and test in the command line

```
./AzTable.CsvUpload.CLI --help
```