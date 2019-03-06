using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodingTaskCS.Models
{
  public class Employee
  {
    [Key]
    public int BusinessEntityID { get; set; }

    public virtual ICollection<Order> Orders { get; set; }

    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string JobTitle { get; set; }

    public string PhoneNumber { get; set; }

    public string PhoneNumberType { get; set; }

    public string EmailAddress { get; set; }

    public int EmailPromotion { get; set; }

    public string AddressLine1 { get; set; }

    public string City { get; set; }

    public string StateProvinceName { get; set; }

    public string PostalCode { get; set; }

    public string CountryRegionName { get; set; }

    public string Title { get; set; }

    public string AddressLine2 { get; set; }

    public string Suffix { get; set; }
  }

  public class Employees
  {
    public List<Employee> Employee { get; set; }
  }
}