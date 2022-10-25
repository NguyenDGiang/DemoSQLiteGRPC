using Demo.DBConnect;
using Demo.Entities;
using Microsoft.Data.Sqlite;

namespace Demo.BLL
{
    public class EmployeeImplement : DBContext, IEmployee
    {
        public EmployeeImplement()
        {

        }
        public EmployeeImplement(IConfiguration configuration) : base(configuration)
        {

        }
        public int Add(Employee t)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            List<Employee> employees = new List<Employee>();
            using (SqliteConnection connection = ConnectString())
            {
                connection.Open();
                string sql = "SELECT * FROM Employee";
                using (SqliteCommand cmd = new SqliteCommand(sql, connection))
                {
                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Employee employee = new Employee();
                            employee.Id = int.Parse(reader["Id"].ToString());
                            employee.MaNV = reader["MaNV"].ToString();
                            employee.TenNV = reader["TenNV"].ToString();
                            employee.Email = reader["Email"].ToString();
                            employee.CanCuoc = reader["CanCuoc"].ToString();
                            employee.GioiTinh = (reader["GioiTinh"].ToString()) == "0" ? true : false;
                            employee.SoDienThoai = reader["SoDienThoai"].ToString();
                            employee.NgayTao = DateTime.ParseExact("22/11/2009", "dd/MM/yyyy", null);
                            employees.Add(employee);
                        }
                    }
                }
                connection.Close();
            }
            return employees;
        }

        public Employee GetId(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
