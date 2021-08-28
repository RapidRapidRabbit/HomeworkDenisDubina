using HomeworkApplication;
using System;
using Xunit;
using Moq;
using System.Text.RegularExpressions;
using Bogus;


namespace TestProject2
{
    public class Tests
    {
        [Theory]
        [InlineData(2, 5)]
        [InlineData(1.5, 1.5)]
        public void Test1(double x, double y)
        {
            IService service = new Service();

            double ActualValue = service.GetSum(x, y);

            Assert.NotEqual(10, ActualValue);
        }

        [Fact]
        public void MoqTest()
        {
            int actualvalue = 0;
            int givenparameter1 = 0;
            int givenparameter2 = 0;

            var mocked = new Mock<IService>();
            mocked.Setup(x => x.GetAverage(It.IsAny<int>(), It.IsAny<int>()))
                .Returns((int x, int y) => (x + y) / 2)
                .Callback((int input1, int input2) => {
                    givenparameter1 = input1;
                    givenparameter2 = input2;
                });


            actualvalue = mocked.Object.GetAverage(10, 20);

            Assert.Equal(15, actualvalue);
            Assert.Equal(10, givenparameter1);
            Assert.Equal(20, givenparameter2);

        }

        [Fact]
        public void BogusTest()
        {
            IService service = new Service();
            Regex regex = new Regex(@"\w*\s\w*"); //2 слова с пробелом между ними

            User user = new Faker<User>()
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName());

            string actualvalue = service.GetFullName(user);

            Assert.Matches(regex, actualvalue);


        }
    }
}
