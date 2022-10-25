using Demo.BLL;
using Demo.Protos;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static Demo.Protos.EmployeeService;

namespace Demo.Services
{
    public class EmployeeService: EmployeeServiceBase
    {
        readonly IEmployee employeeContext;
        public EmployeeService(IEmployee employeeContext)
        {
            this.employeeContext = employeeContext; 
        }
        public override Task<EmployeeProtos> GetAll(EmptyProto request, ServerCallContext context)
        {
            EmployeeProtos employeeProtos = new EmployeeProtos();
            var employees = employeeContext.GetAll();
            foreach(var employee in employees)
            {
                EmployeeProto employeeProto = new EmployeeProto();
                employeeProto.Id = employee.Id;
                employeeProto.MaNV = employee.MaNV;
                employeeProto.TenNV = employee.TenNV;
                employeeProto.CanCuoc = employee.CanCuoc;
                employeeProto.NgayTao = Timestamp.FromDateTime(DateTime.SpecifyKind(employee.NgayTao, DateTimeKind.Utc));
                employeeProto.SoDienThoai = employee.SoDienThoai;
                employeeProto.Email = employee.Email;
                employeeProto.GioiTinh = employee.GioiTinh;
                employeeProtos.Items.Add(employeeProto);
            }
            return Task.FromResult(employeeProtos);
        }
    }
}
