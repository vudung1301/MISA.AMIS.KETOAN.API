using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.KETOAN.Common;
using MySqlConnector;

namespace MISA.AMIS.KETOAN.API.Controllers
{
    public class EmployeeUnitTestsController : Controller
    {

        /// <summary>
        /// API thêm mới nhân viên
        /// Author: NVQUY(25/12/2022)
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần thêm mới</param>
        /// <returns>
        /// 201: Thêm mới thành công
        /// 400: Dữ liệu nhập vào không hợp lệ
        /// 500: Lỗi exception
        /// </returns>
        [HttpPost]
        public int InsertEmployee([FromBody] Employee employee)
        {
            try
            {
                //Khai báo các thông tin cần thiết
                
                //Bước 1:Validate dữ liệu: trả về mã 400 kèm theo các thông báo lỗi
                //1.1. Kiểm tra mã nhân viên bắt buộc nhập
                if (string.IsNullOrEmpty(employee.EmployeeCode))
                {
                    return 400;
                }
                //1.2. Kiểm tra tên nhân viên bắt buộc nhập
                if (string.IsNullOrEmpty(employee.EmployeeName))
                {
                    return 400;
                }
                //1.3. Kiểm tra thông tin phòng ban không được phép để trống
          
                //Chuẩn bị câu lệnh procedure
                var storedProcedureName = "Proc_Employee_InsertOne";

                //Chuẩn bị tham số đầu vào
                var parameters = new DynamicParameters();
                parameters.Add("@EmployeeID", Guid.NewGuid());
                parameters.Add("@EmployeeCode", employee.EmployeeCode);
                parameters.Add("@EmployeeName", employee.EmployeeName);
                parameters.Add("@DateOfBirth", employee.DateOfBirth);
                parameters.Add("@Gender", employee.Gender);
                parameters.Add("@IdentityNumber", employee.IdentityNumber);
                parameters.Add("@IdentityIssueDate", employee.IdentityIssueDate);
                parameters.Add("@IdentityIssuePlace", employee.IdentityIssuePlace);
                parameters.Add("@Email", employee.Email);
                parameters.Add("@PhoneNumber", employee.PhoneNumber);
                parameters.Add("@Address", "Hà Nội");
                parameters.Add("@TelephoneNumber", "021984193");
                parameters.Add("@BankAccountNumber", "0394857829348329");
                parameters.Add("@BankName", "VietComBank");
                parameters.Add("@BankBranchName", "VietComBank");
                parameters.Add("@Salary", employee.Salary);
                parameters.Add("@DepartmentID", "469b3ece-744a-45d5-957d-e8c757976496");
                parameters.Add("@JobPositionID", "3700cc49-55b5-69ea-4929-a2925c0f334d");
                parameters.Add("@CreatedDate", employee.CreatedDate);
                parameters.Add("@CreatedBy", employee.CreatedBy);
                parameters.Add("@ModifiedDate", employee.ModifiedDate);
                parameters.Add("@ModifiedBy", employee.ModifiedBy);


                //Khởi tạo kết nối đến database
                var connectionString = "Server=localhost; Port=3306; Database=web10.vuvandung ;Uid=root; Pwd=Tiendung@123;;";
                var mySqlConnection = new MySqlConnection(connectionString);

                //Gọi vào database để chạy stored procedure  trên
                var result = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

                //Xử lý kết quả trả về
                //Nếu thành công
                if (result > 0)
                {
                    return 201;
                }

                return 500;
                //Xử lý try catch
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return 500;
            }

        }

        /// <summary>
        /// Xoá 1 nhân viên theo ID
        /// </summary>
        /// <param name="employeeID">ID của nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: DungNP (28/11/2022)
        public int DeleteEmployeeByID(Guid employeeID)
        {
            // Chuẩn bị tên stored procedure
            string storedProcedureName = "Proc_Employee_DeleteByID";

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("@EmployeeID", employeeID);

            // Khởi tạo kết nối tới Database
            string connectionString = "Server=localhost; Port=3306; Database=web10.vuvandung ;Uid=root; Pwd=Tiendung@123";
            var mySqlConnection = new MySqlConnection(connectionString);

            // Thực hiện gọi vào Database để chạy stored procedure
            var numberOfDeleteRow = mySqlConnection.Execute(storedProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);

            // Trả về số bản ghi bị ảnh hưởng
            return numberOfDeleteRow;
        }
    }
}
