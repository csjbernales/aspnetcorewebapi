using aspnetcorewebapisqlclient.Business.Interfaces;
using aspnetcorewebapisqlclient.Controllers;

using Microsoft.AspNetCore.Mvc;

namespace aspnetcorewebapisqlclientTests.Controllers
{
    [TestClass()]
    public class EmployeesControllerTests
    {
        private IGetAllEmployee getAllEmployee;
        private IGetEmployeeById getEmployeeById;
        private IAddNewEmployee addNewEmployee;
        private IUpdateEmployee updateEmployee;
        private IRemoveEmployee removeEmployee;

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
            employees = new() { employee };
            getAllEmployee = A.Fake<IGetAllEmployee>();
            getEmployeeById = A.Fake<IGetEmployeeById>();
            addNewEmployee = A.Fake<IAddNewEmployee>();
            updateEmployee = A.Fake<IUpdateEmployee>();
            removeEmployee = A.Fake<IRemoveEmployee>();
        }

        [TestMethod()]
        public void GetTest()
        {
            //arrange

            A.CallTo(() => getAllEmployee.GetAllEmployees()).Returns(employees);

            //act
            EmployeesController employeesController = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);

            OkObjectResult rawresult = employeesController.Get().GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => getAllEmployee.GetAllEmployees()).MustHaveHappenedOnceExactly();

            Assertion(employees, resultModel);
        }

        [TestMethod()]
        public void GetTestById()
        {
            //arrange

            A.CallTo(() => getEmployeeById.GetEmployee(A<int>.Ignored)).Returns(employees);

            //act
            EmployeesController employeesController = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);

            OkObjectResult rawresult = employeesController.Get(1).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => getEmployeeById.GetEmployee(1)).MustHaveHappenedOnceExactly();

            Assertion(employees, resultModel);
        }

        [TestMethod()]
        public void PostTest()
        {
            //arrange

            List<Employees> employeesList = new() { employee };

            A.CallTo(() => addNewEmployee.AddEmployee(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);

            OkObjectResult rawresult = employeesController.Post(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => addNewEmployee.AddEmployee(employee)).MustHaveHappenedOnceExactly();

            Assertion(employeesList, resultModel);
        }

        [TestMethod()]
        public void PutTest()
        {
            //arrange
            List<Employees> employeesList = new() { employee };

            A.CallTo(() => updateEmployee.UpdateEmployeeData(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);

            OkObjectResult rawresult = employeesController.Put(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => updateEmployee.UpdateEmployeeData(employee)).MustHaveHappenedOnceExactly();

            Assertion(employeesList, resultModel);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //arrange
            List<Employees> employeesList = new() { employee };

            A.CallTo(() => removeEmployee.RemoveEmployeeData(A<Employees>.Ignored)).Returns(employeesList);

            //act
            EmployeesController employeesController = new(getAllEmployee, getEmployeeById, addNewEmployee, updateEmployee, removeEmployee);

            OkObjectResult rawresult = employeesController.Delete(employee).GetAwaiter().GetResult() as OkObjectResult;

            List<Employees> resultModel = rawresult.Value as List<Employees>;

            //assert
            A.CallTo(() => removeEmployee.RemoveEmployeeData(A<Employees>.Ignored)).MustHaveHappenedOnceExactly();
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