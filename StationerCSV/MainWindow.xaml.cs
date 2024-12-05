using System;
using System.Data;
using System.Linq;
using System.Windows;
using Stationery.Service;

namespace StationerCSV
{
    public partial class MainWindow : Window
    {
        private readonly CsvDataService _csvService;
        private DataTable _goodsTable;

        public MainWindow()
        {
            InitializeComponent();
            _csvService = new CsvDataService();
            LoadData();
        }

        // Завантаження даних
        private void LoadData()
        {
            _goodsTable = _csvService.LoadGoodsAsDataTable();
            GoodsDataGrid.ItemsSource = _goodsTable.DefaultView;
        }

        // Додавання товару
        private void AddGoodsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = GoodsNameBox.Text;
                string color = GoodsColorBox.Text;
                int quantity = int.Parse(StockQuantityBox.Text);
                decimal price = decimal.Parse(UnitPriceBox.Text);

                AddGoods(name, color, quantity, price);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding goods: {ex.Message}");
            }
        }

        private void AddGoods(string name, string color, int quantity, decimal price)
        {
            var newRow = _goodsTable.NewRow();
            newRow["GoodsId"] = _goodsTable.Rows.Count + 1;
            newRow["GoodsName"] = name;
            newRow["GoodsColor"] = color;
            newRow["StockQuantity"] = quantity;
            newRow["UnitPrice"] = price;
            _goodsTable.Rows.Add(newRow);

            _csvService.SaveGoodsFromDataTable(_goodsTable);
            LoadData();
            MessageBox.Show("Goods added successfully!");
        }

        // Обчислення загальної вартості товарів
        private void CalculateValueButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int supplierId = int.Parse(CalculateSupplierIdBox.Text);
                CalculateTotalValue(supplierId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total value: {ex.Message}");
            }
        }

        private void CalculateTotalValue(int supplierId)
        {
            try
            {
                // Розрахунок суми без об'єднання таблиць
                var totalValue = (from goods in _goodsTable.AsEnumerable()
                                  where goods.Field<int>("SupplierId") == supplierId
                                  select goods.Field<int>("StockQuantity") * goods.Field<decimal>("UnitPrice"))
                                 .Sum();

                MessageBox.Show($"Total value of goods for Supplier ID {supplierId}: {totalValue:C}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating total value: {ex.Message}");
            }
        }


    }
}
