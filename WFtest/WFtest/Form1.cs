using System.Data;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WFtest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public DataGridView OrdersGridView => ordersGridView;
        public DataGridView ProductsGridView => productsGridView;
        public TextBox SearchOrdersTextBox => searchOrdersTextBox;
        public TextBox SearchProductsTextBox => searchProductsTextBox;
        public Button BrowseButton => browseButton;
        public Button NextButtonOrders => nextButtonOrders;
        public Button PreviousButtonOrders => previewsOrdersButton;
        public Button PreviousButtonProducts => previousProductsButton;
        public Button NextButtonProducts => nextButtonProducts;
        public Button SearchOrdersButton => searchOrdersButton;
        public Button SearchProductsButton => searchProductsButton;
        public Button SaveButton => saveButton;
    }
}
