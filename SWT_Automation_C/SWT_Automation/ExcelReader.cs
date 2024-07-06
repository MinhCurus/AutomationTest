using ExcelDataReader;
using System.Collections.Generic;
using System.Data;
using System.IO;

public class ExcelReader
{
    public static IEnumerable<object[]> ReadExcel(string filePath)
    {
        var dataList = new List<object[]>();

        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var dataTable = dataSet.Tables[0];

                foreach (DataRow row in dataTable.Rows)
                {
                    var username = row["Username"].ToString();
                    var password = row["Password"].ToString();
                    dataList.Add(new object[] { username, password });
                }
            }
        }

        return dataList;
    }
}
