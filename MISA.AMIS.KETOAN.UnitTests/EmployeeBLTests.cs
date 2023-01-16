using MISA.AMIS.KETOAN.BL;
using MISA.AMIS.KETOAN.Common;
using MISA.AMIS.KETOAN.DL;
using NPOI.HSSF.Record;
using NSubstitute;

namespace MISA.AMIS.KETOAN.UnitTests
{
    public class EmployeeBLTests
    {

        /// <summary>
        /// Hàm test dữ liệu đầu vào Deparment không chính xác
        /// Author: DungNP(04/01/2023)
        /// </summary>
        [Test]
        public void InsertEmployee_ValidInputEmpoyeeCodeEmpty_ReturnsError400BadRequest()
        {
            //Arrange - Chuẩn bị tất cả tham số đầu vào
            Employee employee = new Employee();
            employee.EmployeeCode = "";
            employee.EmployeeName = "Dung";
            employee.Email = "dung@gmail.com";
            employee.DepartmentID = new Guid("142cb08f-7c31-21fa-8e90-67245e8b283e");
            employee.JobPositionID = new Guid("25c6c36e-1668-7d10-6e09-bf1378b8dc91");

            //fake dữ liệu dựa trên NSAtriibute 
                
            var fakeEmployeeDL = Substitute.For<IEmployeeDL>();
            var recordID = Guid.NewGuid();
            fakeEmployeeDL.InsertRecord(employee).Returns(recordID);
            var employeeBL = new EmployeeBL(fakeEmployeeDL);

            //Act - Gọi hàm cần test
            var actualResult = employeeBL.InsertRecord(employee);

            //Assert - Kiểm tra kết quả có đúng mong đợi không
            Assert.AreEqual(recordID, actualResult);
        }

        /// <summary>
        /// Hàm test dữ liệu đầu vào tên nhân viên để trống
        /// Author: DungNP(04/01/2023)
       /* /// </summary>
        [Test]
        public void InsertEmployee_EmptyInputEmpoyeeName_ReturnsError400BadRequest()
        {
            //Arrange - Chuẩn bị tất cả tham số đầu vào
            Employee employee = new Employee();
            employee.EmployeeCode = "NV00912241241";
            employee.EmployeeName = "";
            employee.Email = "dung@gmail.com";
            var expectedResult = 400;

            var insertEmployee = new EmployeeUnitTestsController();

            //Act - Gọi hàm cần test
            var actualResult = insertEmployee.InsertEmployee(employee);

            //Assert - Kiểm tra kết quả có đúng mong đợi không

            Assert.AreEqual(expectedResult, actualResult);
        }


        /// <summary>
        /// Hàm test dữ liệu đầu vào trùng mã nhân viên
        /// Author: DungNP(04/01/2023)
        /// </summary>
        [Test]
        public void InsertEmployee_DuplicateInputEmployeeCode_ReturnsError400BadRequest()
        {
            //Arrange - Chuẩn bị tất cả tham số đầu vào
            Employee employee = new Employee();
            employee.EmployeeCode = "NV-85483";
            employee.EmployeeName = "Dung";
            employee.Email = "dung@gmail.com";
            employee.DepartmentID = new Guid("469b3ece-744a-45d5-957d-e8c757976496");
            var expectedResult = 400;

            var insertEmployee = new EmployeeUnitTestsController();

            //Act - Gọi hàm cần test
            var actualResult = insertEmployee.InsertEmployee(employee);

            //Assert - Kiểm tra kết quả có đúng mong đợi không

            Assert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// Hàm test đúng dữ liệu đầu vào
        /// Author: DungNP(04/01/2023)
        /// </summary>
        [Test]
        public void InsertEmployee_ValidInput_ReturnsError201Created()
        {
            //Arrange - Chuẩn bị tất cả tham số đầu vào
            Employee employee = new Employee();
            employee.EmployeeCode = "NV80811";
            employee.EmployeeName = "Vu Dũng";
            employee.Email = "DungNP@gmail.com";
            employee.DepartmentID = new Guid("469b3ece-744a-45d5-957d-e8c757976496");
            var expectedResult = 201;

            var insertEmployee = new EmployeeUnitTestsController();

            //Act - Gọi hàm cần test
            var actualResult = insertEmployee.InsertEmployee(employee);

            //Assert - Kiểm tra kết quả có đúng mong đợi không

            Assert.AreEqual(expectedResult, actualResult);
        }





        /// <summary>
        /// Hàm test dữ liệu đầu vào không tồn tài
        /// </summary>
        [Test]
        public void DeleteEmployee_noExistEmployeeID_returnsError400()
        {
            //Arrange - Chuẩn bị tất cả tham số đầu vào
            Employee employee = new Employee();
            employee.EmployeeID = new Guid("469b3ece-744a-45d5-957d-e8c757976496");
            var expectedResult = 500;
            var deleteEmployee = new EmployeeUnitTestsController();

            //Act -Gọi hàm cần test

            var actualResult = deleteEmployee.DeleteEmployeeByID(employee.EmployeeID);

            //Assert - Kiểm tra kết quả có đúng mong đợi không
            Assert.AreEqual(expectedResult, actualResult);
        }*/
    }
}