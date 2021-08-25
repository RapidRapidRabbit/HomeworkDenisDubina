using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkApplication
{
    public class Service : IService
    {
        public double GetSum(double x, double y) => x + y;
        public int GetAverage(int x, int y) => (x + y) / 2;
        public string GetFullName(User user) => $"{user.FirstName} {user.LastName}";
    }
}
