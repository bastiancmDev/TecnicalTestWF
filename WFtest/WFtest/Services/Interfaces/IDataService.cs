using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFtest.Models;

namespace WFtest.Services.Interfaces
{
    public interface IDataService
    {
        List<Order> LoadOrdersFromXml(string xmlFilePath);
        void SaveOrdersToXml(string xmlFilePath, List<Order> orders);
    }
}
