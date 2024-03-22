﻿using aspnetcorewebapisqlclient.Business;

namespace aspnetcorewebapisqlclientTests.Business
{
    [TestClass()]
    public class AddNewEmployeeTests
    {
        [TestMethod()]
        public void AddEmployeeTest()
        {
            //arrange
            Employees employees = new()
            {
                Firstname = string.Empty,
                Middlename = string.Empty,
                Lastname = string.Empty
            };
            IEmployeeService service = A.Fake<IEmployeeService>();
            List<Employees> employeeList = [employees];
            A.CallTo(() => service.Post(A<Employees>.Ignored)).Returns(employeeList);

            //act
            AddNewEmployee addNewEmployee = new(service);
            var rawResult = addNewEmployee.AddEmployee(employees);
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Post(A<Employees>.Ignored)).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(1);
        }
    }
}