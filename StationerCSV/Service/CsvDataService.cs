using System.Data;
using System.Globalization;
using System.IO;
using CsvHelper;

namespace Stationery.Service
{
    public class CsvDataService
    {
        private readonly string _goodsFile = "D:\\вступ до програмування\\Екз\\csv\\StationerCSV\\StationerCSV\\Goods.csv";
        private readonly string _suppliersFile = "D:\\вступ до програмування\\Екз\\csv\\StationerCSV\\StationerCSV\\Supplier.csv";
        private readonly string _deliveriesFile = "D:\\вступ до програмування\\Екз\\csv\\StationerCSV\\StationerCSV\\Deliveries.csv";

        // Зчитування Goods у DataTable
        public DataTable LoadGoodsAsDataTable()
        {
            var table = new DataTable();
            using var reader = new StreamReader(_goodsFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            using var dr = new CsvDataReader(csv);
            table.Load(dr);
            return table;
        }

        // Зчитування Deliveries у DataTable
        public DataTable LoadDeliveriesAsDataTable()
        {
            var table = new DataTable();
            using var reader = new StreamReader(_deliveriesFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            using var dr = new CsvDataReader(csv);
            table.Load(dr);
            return table;
        }

        // Зчитування Suppliers у DataTable
        public DataTable LoadSuppliersAsDataTable()
        {
            var table = new DataTable();
            using var reader = new StreamReader(_suppliersFile);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            using var dr = new CsvDataReader(csv);
            table.Load(dr);
            return table;
        }

        // Збереження Goods із DataTable у CSV
        public void SaveGoodsFromDataTable(DataTable table)
        {
            SaveDataTableToCsv(table, _goodsFile);
        }

        // Збереження Deliveries із DataTable у CSV
        public void SaveDeliveriesFromDataTable(DataTable table)
        {
            SaveDataTableToCsv(table, _deliveriesFile);
        }

        // Збереження Suppliers із DataTable у CSV
        public void SaveSuppliersFromDataTable(DataTable table)
        {
            SaveDataTableToCsv(table, _suppliersFile);
        }

        // Загальний метод для збереження DataTable у CSV
        private void SaveDataTableToCsv(DataTable table, string filePath)
        {
            using var writer = new StreamWriter(filePath);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

            // Записуємо заголовки
            foreach (DataColumn column in table.Columns)
            {
                csv.WriteField(column.ColumnName);
            }
            csv.NextRecord();

            // Записуємо дані
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    csv.WriteField(item);
                }
                csv.NextRecord();
            }
        }
    }
}
