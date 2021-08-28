using System;
using System.Collections.Generic;
using System.Text;

namespace HomeworkApplication
{
    public interface IService
    {
        double GetSum(double x, double y);
        int GetAverage(int x, int y);
        string GetFullName(User user);
    }
}
