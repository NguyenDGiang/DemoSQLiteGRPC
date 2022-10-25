using Demo.Entities;

namespace Demo.BLL
{
    public interface IEmployee
    {
        List<Employee> GetAll();
        int Add(Employee t);
        int Delete(int id);
        int Update(Employee t);
        Employee GetId(int id);
    }
}
