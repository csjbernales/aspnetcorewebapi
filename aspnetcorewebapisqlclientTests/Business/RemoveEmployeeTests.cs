﻿namespace aspnetcorewebapisqlclient.Business.Tests
{
    [TestClass()]
    public class RemoveEmployeeTests
    {

        [TestMethod()]
        public void RemoveEmployeeDataTest()
        {
            //arrange
            Employees employees = new()
            {
                Firstname = string.Empty,
                Middlename = string.Empty,
                Lastname = string.Empty
            };
            IEmployeeService service = A.Fake<IEmployeeService>();
            List<Employees> employeeList = new() { employees, employees };
            A.CallTo(() => service.Delete(3)).Returns(employeeList);

            //act
            RemoveEmployee removeEmployee = new(service);
            var rawResult = removeEmployee.RemoveEmployeeData(3);
            var result = rawResult.GetAwaiter().GetResult();

            //assert
            A.CallTo(() => service.Delete(3)).MustHaveHappenedOnceExactly();

            result.Should().NotBeNull();
            result.Should().Contain(employees);
            result.Should().HaveCount(2);
        }
    }
}