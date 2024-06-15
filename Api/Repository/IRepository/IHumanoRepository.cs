using Api.Models;
using Api.Models.Enum;

namespace Api.Repository.IRepository
{
    public interface IHumanoRepository : IRepository<Tbl_Humano>
    {
        Task<List<Tbl_Humano>> HumanosList();
        Task<double> CalculateOperation(OperationType operation, double number1, double number2);
    }
}
