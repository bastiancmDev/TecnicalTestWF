using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WFtest.Models;
using WFtest.Services.Interfaces;

namespace WFtest.Controllers
{
    public class MainFormController
    {
        private readonly Form1 view;
        private readonly IDataService dataService;
        private List<Order> orders;
        private List<Product> currentProducts;
        private string currentFilePath;

        public MainFormController(Form1 view, IDataService dataService)
        {
            this.view = view;
            this.dataService = dataService;
            Initialize();
        }

        private void Initialize()
        {
            view.BrowseButton.Click += async (sender, e) => await BrowseButton_Click();
            view.SearchProductsButton.Click += (sender, e) => SearchProductsButton_Click();
            view.SearchOrdersButton.Click += (sender, e) => SearchOrdersButton_Click();
            view.NextButtonOrders.Click += (sender, e) => NextButtonOrders_Click();
            view.PreviousButtonOrders.Click += (sender, e) => PreviousButtonOrders_Click();
            view.PreviousButtonProducts.Click += (sender, e) => PreviousButtonProducts_Click();
            view.NextButtonProducts.Click += (sender, e) => NextButtonProducts_Click();
            view.SaveButton.Click += (sender, e) => SaveButton_Click();
            view.OrdersGridView.SelectionChanged += OrdersGridView_SelectionChanged;
            view.ProductsGridView.CellEndEdit += ProductsGridView_CellEndEdit;
        }

        private void NextButtonOrders_Click()
        {
            if (view.OrdersGridView.SelectedRows.Count > 0)
            {
                int currentIndex = view.OrdersGridView.SelectedRows[0].Index;
                if (currentIndex < view.OrdersGridView.Rows.Count - 1)
                {
                    view.OrdersGridView.ClearSelection();
                    view.OrdersGridView.Rows[currentIndex + 1].Selected = true;
                }
            }
            else if (view.OrdersGridView.Rows.Count > 0)
            {
                view.OrdersGridView.Rows[0].Selected = true;
            }
        }

        private void PreviousButtonOrders_Click()
        {
            if (view.OrdersGridView.SelectedRows.Count > 0)
            {
                int currentIndex = view.OrdersGridView.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    view.OrdersGridView.ClearSelection();
                    view.OrdersGridView.Rows[currentIndex - 1].Selected = true;
                }
            }
            else if (view.OrdersGridView.Rows.Count > 0)
            {
                view.OrdersGridView.Rows[0].Selected = true;
            }
        }

        private void NextButtonProducts_Click()
        {
            if (view.ProductsGridView.SelectedRows.Count > 0)
            {
                int currentIndex = view.ProductsGridView.SelectedRows[0].Index;
                if (currentIndex < view.ProductsGridView.Rows.Count - 1)
                {
                    view.ProductsGridView.ClearSelection();
                    view.ProductsGridView.Rows[currentIndex + 1].Selected = true;
                }
            }
            else if (view.ProductsGridView.Rows.Count > 0)
            {
                view.ProductsGridView.Rows[0].Selected = true;
            }
        }

        private void PreviousButtonProducts_Click()
        {
            if (view.ProductsGridView.SelectedRows.Count > 0)
            {
                int currentIndex = view.ProductsGridView.SelectedRows[0].Index;
                if (currentIndex > 0)
                {
                    view.ProductsGridView.ClearSelection();
                    view.ProductsGridView.Rows[currentIndex - 1].Selected = true;
                }
            }
            else if (view.ProductsGridView.Rows.Count > 0)
            {
                view.ProductsGridView.Rows[0].Selected = true;
            }
        }



        private void SearchOrdersButton_Click()
        {
            var searchTerm = view.SearchOrdersTextBox.Text.ToLower();
            var filteredOrders = orders.Where(o => o.OrderNumber.ToLower().Contains(searchTerm)
                                                || o.CustomerName.ToLower().Contains(searchTerm)).ToList();

            if (filteredOrders.Any())
            {
                view.OrdersGridView.DataSource = filteredOrders.Select(o => new
                {
                    o.OrderNumber,
                    o.Date,
                    o.ItemCount,
                    o.TotalPrice,
                    o.CustomerName
                }).ToList();
            }
            else
            {
                view.OrdersGridView.DataSource = new List<Order>(); // Si no se encuentran resultados, asigna una lista vacía
            }
        }

        private void SearchProductsButton_Click()
        {
            var searchTerm = view.SearchProductsTextBox.Text.ToLower();
            
            if(currentProducts != null)
            {
                var filteredProducts = currentProducts.Where(o => o.OrderNumber.ToLower().Contains(searchTerm)
                                               || o.ProductName.ToLower().Contains(searchTerm)).ToList();

                if (filteredProducts.Any())
                {
                    view.ProductsGridView.DataSource = filteredProducts.Select(o => new
                    {
                        o.OrderNumber,
                        o.ProductName,
                        o.Price,
                        o.Quantity,
                        o.Comment
                    }).ToList();
                }
                else
                {
                    view.ProductsGridView.DataSource = new List<Order>(); 
                }
            }
           
        }

        private async Task BrowseButton_Click()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.Title = "Select an XML file";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    await LoadXmlToDataGridViewAsync(filePath);
                }
            }
        }

        private async Task LoadXmlToDataGridViewAsync(string xmlFilePath)
        {
            try
            {
                orders = await Task.Run(() => dataService.LoadOrdersFromXml(xmlFilePath));

                if (orders.Any())
                {
                    view.OrdersGridView.DataSource = orders.Select(o => new
                    {
                        o.OrderNumber,
                        o.Date,
                        o.ItemCount,
                        o.TotalPrice,
                        o.CustomerName
                    }).ToList();
                    currentFilePath = xmlFilePath;
                }
                else
                {
                    MessageBox.Show("No se encontraron pedidos en el archivo XML.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el XML: {ex.Message}");
            }
        }

        private void OrdersGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (view.OrdersGridView.SelectedRows.Count > 0)
            {
                var selectedOrderNumber = view.OrdersGridView.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
                LoadOrderDetails(selectedOrderNumber);
            }
        }

        private void LoadOrderDetails(string orderNumber)
        {
            var selectedOrder = orders.FirstOrDefault(o => o.OrderNumber == orderNumber);
            if (selectedOrder != null)
            {
                var productsList = new BindingList<Product>(selectedOrder.Products.ToList());
                currentProducts = productsList.ToList();
                view.ProductsGridView.DataSource = productsList;
            }
        }

        private void ProductsGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == view.ProductsGridView.Rows.Count - 1)
            {
                var newProductRow = view.ProductsGridView.Rows[e.RowIndex];
                if (!string.IsNullOrWhiteSpace(newProductRow.Cells["ProductName"].Value?.ToString()))
                {
                    // Add the new product
                    var selectedOrderNumber = view.OrdersGridView.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
                    var selectedOrder = orders.FirstOrDefault(o => o.OrderNumber == selectedOrderNumber);
                    if (selectedOrder != null)
                    {
                        var newProduct = new Product
                        {
                            OrderNumber = selectedOrderNumber,
                            ProductName = newProductRow.Cells["ProductName"].Value.ToString(),
                            Price = decimal.Parse(newProductRow.Cells["Price"].Value.ToString()),
                            Quantity = int.Parse(newProductRow.Cells["Quantity"].Value.ToString()),
                            Comment = newProductRow.Cells["Comment"].Value.ToString()
                        };
                        selectedOrder.Products.Add(newProduct);
                        LoadOrderDetails(selectedOrderNumber);
                    }
                }
            }
        }

        private void SaveButton_Click()
        {
            if (view.OrdersGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un pedido.");
                return;
            }

            var selectedOrderNumber = view.OrdersGridView.SelectedRows[0].Cells["OrderNumber"].Value.ToString();
            var selectedOrder = orders.FirstOrDefault(o => o.OrderNumber == selectedOrderNumber);
            if (selectedOrder != null)
            {
                var updatedProducts = new List<Product>();
                foreach (DataGridViewRow row in view.ProductsGridView.Rows)
                {
                    // Verificar si la celda es nula antes de intentar acceder a su valor
                    if (row.Cells["ProductName"].Value != null &&
                        row.Cells["Price"].Value != null &&
                        row.Cells["Quantity"].Value != null &&
                        row.Cells["Comment"].Value != null)
                    {
                        var product = new Product
                        {
                            OrderNumber = selectedOrderNumber,
                            ProductName = row.Cells["ProductName"].Value.ToString(),
                            Price = decimal.Parse(row.Cells["Price"].Value.ToString()),
                            Quantity = int.Parse(row.Cells["Quantity"].Value.ToString()),
                            Comment = row.Cells["Comment"].Value.ToString()
                        };
                        updatedProducts.Add(product);
                    }
                }

                selectedOrder.Products = updatedProducts;
                dataService.SaveOrdersToXml(currentFilePath, orders);
                MessageBox.Show("Los cambios se han guardado exitosamente.");
            }
            else
            {
                MessageBox.Show("No se encontró el pedido seleccionado.");
            }
        }


    }
}
