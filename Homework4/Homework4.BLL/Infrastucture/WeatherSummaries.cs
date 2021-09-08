using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4.BLL.Infrastucture
{
    public class WeatherSummaries // я бы отнес этот класс так же к моделям, т.к. он не делает какие-либо преобразовния, но при этом является данными для отображения
    {
        public static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
    }
}
