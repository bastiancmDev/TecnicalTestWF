using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WFtest.Models;
using WFtest.Services.Interfaces;

namespace WFtest.Services
{
    public class DataService : IDataService
    {
        public List<Order> LoadOrdersFromXml(string xmlFilePath)
        {
            XDocument doc = XDocument.Load(xmlFilePath);
            return doc.Descendants("Order")
                .Select(o => new Order
                {
                    OrderNumber = (string)o.Element("OrderNumber"),
                    Date = (DateTime)o.Element("Date"),
                    ItemCount = (int)o.Element("ItemCount"),
                    TotalPrice = (decimal)o.Element("TotalPrice"),
                    CustomerName = (string)o.Element("CustomerName"),
                    Products = o.Element("Products")?.Descendants("Product")
                        .Select(p => new Product
                        {
                            OrderNumber = (string)p.Element("OrderNumber"),
                            ProductName = (string)p.Element("ProductName"),
                            Price = (decimal)p.Element("Price"),
                            Quantity = (int)p.Element("Quantity"),
                            Comment = (string)p.Element("Comment")
                        }).ToList() ?? new List<Product>()
                }).ToList();
        }

        public void SaveOrdersToXml(string xmlFilePath, List<Order> orders)
        {
            var xDoc = new XDocument(
                new XElement("Orders",
                    orders.Select(o =>
                        new XElement("Order",
                            new XElement("OrderNumber", o.OrderNumber),
                            new XElement("Date", o.Date),
                            new XElement("ItemCount", o.ItemCount),
                            new XElement("TotalPrice", o.TotalPrice),
                            new XElement("CustomerName", o.CustomerName),
                            new XElement("Products",
                                o.Products.Select(p =>
                                    new XElement("Product",
                                        new XElement("OrderNumber", p.OrderNumber),
                                        new XElement("ProductName", p.ProductName),
                                        new XElement("Price", p.Price),
                                        new XElement("Quantity", p.Quantity),
                                        new XElement("Comment", p.Comment)
                                    )
                                )
                            )
                        )
                    )
                )
            );

            xDoc.Save(xmlFilePath);
        }

    }





}
