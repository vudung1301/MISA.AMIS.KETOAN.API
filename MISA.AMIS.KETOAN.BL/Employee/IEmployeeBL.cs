﻿using MISA.AMIS.KETOAN.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace MISA.AMIS.KETOAN.BL
{
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: DungNP (26/12/2022)
        public string GetNewCode();

        /// <summary>
        /// Lọc nhân viên theo các tiêu chí
        /// </summary>
        /// <param name="keyword">Từ khóa cần lọc</param>
        /// <param name="limit">Số bản ghi cần lấy</param>
        /// <param name="offset">Nơi bắt đầu lấy</param>
        /// <returns>Danh sách nhân viên đã được phân trang</returns
        public Pagingnation<Employee> GetFilterEmployees(
            string? keyword,
            int limit,
            int offset
        );

        /// <summary>
        /// Xóa nhiều nhân viên dựa theo danh sách ID
        /// </summary>
        /// <param name="listEmployeeIDs">Danh sách ID của các nhân viên cần xóa/param>
        /// <returns>Danh sách GUID của các nhân viên vừa được xóa</returns>
        /// Created by: DungNP (26/12/2022)
        public int DeleteBatchEmployees(ListEmployeeIDs listEmployeeIDs);

    }
}
