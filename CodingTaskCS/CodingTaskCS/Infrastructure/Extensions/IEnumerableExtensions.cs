using System.Collections.Generic;
using System.Linq;
using CodingTaskCS.Models;

namespace CodingTaskCS.Infrastructure.Extensions
{
  public static class IEnumerableExtensions
  {
    public static IEnumerable<Employee> GetEmployeesFromCity(this IEnumerable<Employee> employees, string city)
    {
      return employees.Where(x => x.City == city);
    }
  }
}