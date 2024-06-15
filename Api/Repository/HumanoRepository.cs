using Api.Data;
using Api.Models;
using Api.Models.Enum;
using Api.Repository.IRepository;

namespace Api.Repository
{
    public class HumanoRepository : Repository<Tbl_Humano>,IHumanoRepository
    {
        private readonly ApplicationDbContext _db;
        public HumanoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<List<Tbl_Humano>> HumanosList()
        {
            return new List<Tbl_Humano>{ 
                            new Tbl_Humano { Id = 1, Nombre = "Ana", Sexo = 'F', Edad = 20, Altura = 1.50, Peso = 50.5 },
                            new Tbl_Humano { Id = 2, Nombre = "Pedro", Sexo = 'M', Edad = 23, Altura = 1.70, Peso = 50.5 },
                            new Tbl_Humano { Id = 3, Nombre = "Miriam", Sexo = 'F', Edad = 21, Altura = 1.53, Peso = 50.5 },
                            new Tbl_Humano { Id = 4, Nombre = "Eduardo", Sexo = 'M', Edad = 25, Altura = 1.58, Peso = 50.5 },
                            new Tbl_Humano { Id = 5, Nombre = "Diana", Sexo = 'F', Edad = 22, Altura = 1.60, Peso = 60.5 },
                            new Tbl_Humano { Id = 6, Nombre = "Omar", Sexo = 'M', Edad = 24, Altura = 1.65, Peso = 50.5 },
                            new Tbl_Humano { Id = 7, Nombre = "Itzel", Sexo = 'F', Edad = 29, Altura = 1.63, Peso = 60.5 },
                            new Tbl_Humano { Id = 8, Nombre = "Angel", Sexo = 'M', Edad = 27, Altura = 1.80, Peso = 80.5 },
                            new Tbl_Humano { Id = 9, Nombre = "Sara", Sexo = 'F', Edad = 28, Altura = 1.71, Peso = 60.5 },
                            new Tbl_Humano { Id = 10, Nombre = "Luis", Sexo = 'M', Edad = 26, Altura = 1.70, Peso = 70.5 },
            };
        }

        public async Task<double> CalculateOperation(OperationType operation, double number1, double number2)
        {
            switch (operation)
            {
                case OperationType.suma:
                    return number1 + number2;
                case OperationType.resta:
                    return number1 - number2;
                case OperationType.multiplicacion:
                    return number1 * number2;
                case OperationType.division:
                    return number1 / number2;
            }

            return 0;
        }
    }
}
