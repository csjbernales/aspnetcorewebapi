using aspnetcorewebapisqlclient.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapisqlclientTests.Controllers
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        private IEmployeeDependency employeeDependency;
        private Employees employee;
        private List<Employees> employees;

        [TestInitialize]
        public void Setup()
        {
            employee = new()
            {
                Firstname = "Test",
                Middlename = "Test",
                Lastname = "Test"
            };
            employees = [employee];
            employeeDependency = A.Fake<IEmployeeDependency>();
        }

        [TestMethod()]
        public void GetTest()
        {
            //arrange

            A.CallTo(() => employeeDependency.Get()).Returns(employees);

            //act
            EmployeesController employeesController = new(employeeDependency);

            OkObjectResult rawresult = employeesController.Get().GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => employeeDependency.Get()).MustHaveHappenedOnceExactly();

            Assertion(employees, resultModel);
        }

        [TestMethod()]
        public void GetTestById()
        {
            //arrange

            A.CallTo(() => employeeDependency.Get(A<int>.Ignored)).Returns(employees);

            //act
            EmployeesController employeesController = new(employeeDependency);

            OkObjectResult rawresult = employeesController.Get(1).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => employeeDependency.Get(1)).MustHaveHappenedOnceExactly();

            Assertion(employees, resultModel);
        }

        [TestMethod()]
        public void PostTest()
        {
            //arrange

            List<Employees> employeesList = [employee];

            A.CallTo(() => employeeDependency.Post(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(employeeDependency);

            OkObjectResult rawresult = employeesController.Post(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => employeeDependency.Post(employee)).MustHaveHappenedOnceExactly();

            Assertion(employeesList, resultModel);
        }

        [TestMethod()]
        public void PutTest()
        {
            //arrange
            List<Employees> employeesList = [employee];

            A.CallTo(() => employeeDependency.Put(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(employeeDependency);

            OkObjectResult rawresult = employeesController.Put(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => employeeDependency.Put(employee)).MustHaveHappenedOnceExactly();

            Assertion(employeesList, resultModel);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //arrange
            List<Employees> employeesList = [employee];

            A.CallTo(() => employeeDependency.Delete(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(employeeDependency);

            OkObjectResult rawresult = employeesController.Delete(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => employeeDependency.Delete(A<Employees>.Ignored)).MustHaveHappenedOnceExactly();
            Assertion(employeesList, resultModel);
        }

        private static void Assertion(List<Employees> employees, List<Employees> resultModel)
        {
            resultModel.Should().NotBeNull();
            resultModel.Should().Contain(employees);
            resultModel.Should().HaveCount(1);
        }
    }
}