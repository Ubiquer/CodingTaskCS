using CodingTaskCS.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Linq;
using CodingTaskCS.Infrastructure.Extensions;
using CodingTaskCS.Models.DTO;

namespace CodingTaskCS.Controllers
{
  public class CodingTaskController : Controller
  {
    private ApplicationDbContext _db = new ApplicationDbContext();

    public string PopulateDB()
    {
      var employeeJson = System.IO.File.ReadAllText(Server.MapPath("~/Content/TaskJsons/Employee.json"));
      var orderJson = System.IO.File.ReadAllText(Server.MapPath("~/Content/TaskJsons/Order.json"));
      var orderDetailsJson = System.IO.File.ReadAllText(Server.MapPath("~/Content/TaskJsons/OrderDetails.json"));
      var productJson = System.IO.File.ReadAllText(Server.MapPath("~/Content/TaskJsons/Product.json"));

      var orders = JsonConvert.DeserializeObject<Orders>(orderJson).Order;
      var orderDetails = JsonConvert.DeserializeObject<OrderDetailss>(orderDetailsJson).OrderDetails;
      var employees = JsonConvert.DeserializeObject<Employees>(employeeJson).Employee;
      var products = JsonConvert.DeserializeObject<Products>(productJson).Product;

      if (!_db.Employees.Any())
      {
        _db.Employees.AddRange(employees);
        _db.Orders.AddRange(orders);
        _db.Products.AddRange(products);
        _db.OrderDetails.AddRange(orderDetails);
        _db.SaveChanges();
      }

      return String.Empty;
    }

    public string GetCities()
    {
      var ProductsChain = _db.Products.FirstOrDefault(x => x.Name == "Chain");

      var chainOrderDetails = ProductsChain.OrderDetails;

      var listOfCities = new List<ChainPerCity>();
      foreach (var orderDetail in chainOrderDetails)
      {
        var indexOfExistingCity = IsCityExistInList(listOfCities, orderDetail.Order.Employee.City);
        if (indexOfExistingCity >= 0)
        {
          listOfCities[indexOfExistingCity].ChainsNumber = listOfCities[indexOfExistingCity].ChainsNumber + 1;
        }
        else
        {
          var chainPerCity = new ChainPerCity()
          {
            City = orderDetail.Order.Employee.City,
            ChainsNumber = 1
          };
          listOfCities.Add(chainPerCity);
        }
      }
      var jsonResult = JsonConvert.SerializeObject(listOfCities);

      return jsonResult;
    }

    public string ReplaceCountries()
    {
      var employees = new List<Employee>(_db.Employees);

      var listOfEmployesWithReplacedCountries = employees
        .Select(n =>
        {
          if (n.CountryRegionName == "Canada")
          {
            n.CountryRegionName = "United States";
          }
          return n;
        });

      var distictListOfCountriesBeforeChange = _db.Employees.Select(x => x.CountryRegionName).Distinct().ToList();
      var distictListOfCountriesAfterChange = listOfEmployesWithReplacedCountries.Select(x => x.CountryRegionName).Distinct().ToList();

      var countriesLists = new CountriesLists()
      {
        DistictListOfCountriesBeforeChange = distictListOfCountriesBeforeChange,
        DistictListOfCountriesAfterChange = distictListOfCountriesAfterChange
      };

      var jsonResult = JsonConvert.SerializeObject(countriesLists);
      return jsonResult;
    }

    public string GetEmployeesForCity(string city)
    {
      var employees = _db.Employees.GetEmployeesFromCity(city).OrderBy(x => x.LastName);
      var jsonResult = JsonConvert.SerializeObject(employees);
      return jsonResult;
    }

    private int IsCityExistInList(List<ChainPerCity> listOfCities, string employeeCity)
    {
      var chainPerCityWithCityIndex = listOfCities.FindIndex(x => x.City == employeeCity);
      return chainPerCityWithCityIndex;
    }
  }
}