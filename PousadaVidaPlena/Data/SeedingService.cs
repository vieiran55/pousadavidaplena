using PousadaVidaPlena.Models;
using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Data
{
    public class SeedingService
    {
        private PousadaContext _context;

        public SeedingService(PousadaContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Room.Any() ||
                _context.Client.Any() ||
                    _context.Employee.Any())
            {
                return; // db has benn seed
            }

            Room r1 = new Room(1, 101, RoomType.Standard, RoomStatus.Disponivel, 100.00);
            Room r2 = new Room(2, 102, RoomType.Standard, RoomStatus.Disponivel, 100.00);
            Room r3 = new Room(3, 103, RoomType.Standard, RoomStatus.Disponivel, 100.00);
            Room r4 = new Room(4, 104, RoomType.Standard, RoomStatus.Disponivel, 100.00);
            Room r5 = new Room(5, 105, RoomType.Standard, RoomStatus.Disponivel, 100.00);
            Room r6 = new Room(6, 201, RoomType.Executivo, RoomStatus.Disponivel, 150.00);
            Room r7 = new Room(7, 202, RoomType.Executivo, RoomStatus.Disponivel, 150.00);
            Room r8 = new Room(8, 203, RoomType.Executivo, RoomStatus.Disponivel, 150.00);
            Room r9 = new Room(9, 204, RoomType.Executivo, RoomStatus.Disponivel, 150.00);
            Room r10 = new Room(10, 205, RoomType.Executivo, RoomStatus.Disponivel, 150.00);
            Room r11 = new Room(11, 301, RoomType.Deluxe, RoomStatus.Disponivel, 250.00);
            Room r12 = new Room(12, 302, RoomType.Deluxe, RoomStatus.Disponivel, 250.00);
            Room r13 = new Room(13, 303, RoomType.Deluxe, RoomStatus.Disponivel, 250.00);
            Room r14 = new Room(14, 304, RoomType.Deluxe, RoomStatus.Disponivel, 250.00);
            Room r15 = new Room(15, 305, RoomType.Deluxe, RoomStatus.Disponivel, 250.00);


            Client c1 = new Client
            {
                Id = 1,
                Name = "João Silva",
                Address = "Rua ABC, 123",
                City = "São Paulo",
                State = "SP",
                Country = "Brasil",
                PhoneNumber = "(11) 99999-9999",
                Email = "joao.silva@example.com",
                BirthDate = new DateTime(1990, 5, 15),
                Gender = "Masculino",
                Nationality = "Brasileiro",
                Rg = 123456789,
                Cpf = "12345678901"
            };

            Client c2 = new Client
            {
                Id = 2,
                Name = "Luke Skywalker",
                Address = "Tatooine Street, 123",
                City = "Mos Eisley",
                State = "Tatooine",
                Country = "Galaxy Far Far Away",
                PhoneNumber = "555-1234",
                Email = "luke.skywalker@example.com",
                BirthDate = new DateTime(1990, 1, 1),
                Gender = "Male",
                Nationality = "Galactic",
                Rg = 987654321,
                Cpf = "12345678901"
            };
            Client c3 = new Client
            {
                Id = 3,
                Name = "Hermione Granger",
                Address = "Magic Lane, 456",
                City = "Hogwarts",
                State = "Scotland",
                Country = "United Kingdom",
                PhoneNumber = "555-5678",
                Email = "hermione.granger@example.com",
                BirthDate = new DateTime(1989, 2, 28),
                Gender = "Female",
                Nationality = "British",
                Rg = 123987456,
                Cpf = "23456789012"
            };

            Client c4 = new Client
            {
                Id = 4,
                Name = "Tony Stark",
                Address = "Stark Tower, 10880",
                City = "New York",
                State = "NY",
                Country = "United States",
                PhoneNumber = "555-8765",
                Email = "tony.stark@example.com",
                BirthDate = new DateTime(1970, 5, 29),
                Gender = "Male",
                Nationality = "American",
                Rg = 654321987,
                Cpf = "34567890123"
            };

            Client c5 = new Client
            {
                Id = 5,
                Name = "Ellen Ripley",
                Address = "Nostromo Street, 426",
                City = "LV-426",
                State = "Outer Space",
                Country = "Unknown",
                PhoneNumber = "555-4321",
                Email = "ellen.ripley@example.com",
                BirthDate = new DateTime(2070, 3, 15),
                Gender = "Female",
                Nationality = "Human",
                Rg = 789012345,
                Cpf = "45678901234"
            };

            Client c6 = new Client
            {
                Id = 6,
                Name = "Jack Sparrow",
                Address = "Pirate Cove, 17",
                City = "Tortuga",
                State = "Caribbean",
                Country = "Pirates' Haven",
                PhoneNumber = "555-9876",
                Email = "jack.sparrow@example.com",
                BirthDate = new DateTime(1690, 6, 9),
                Gender = "Male",
                Nationality = "Pirate",
                Rg = 567890123,
                Cpf = "56789012345"
            };
            Client c7 = new Client
            {
                Id = 7,
                Name = "Princess Leia",
                Address = "Alderaan Avenue, 5",
                City = "Alderaan",
                State = "Unknown",
                Country = "Galaxy Far Far Away",
                PhoneNumber = "555-5432",
                Email = "princess.leia@example.com",
                BirthDate = new DateTime(1980, 10, 21),
                Gender = "Female",
                Nationality = "Royal",
                Rg = 345678901,
                Cpf = "67890123456"
            };
            Client c8 = new Client
            {
                Id = 8,
                Name = "Indiana Jones",
                Address = "Adventurer Lane, 789",
                City = "Archaeology City",
                State = "Unknown",
                Country = "Explorer's Realm",
                PhoneNumber = "555-8765",
                Email = "indiana.jones@example.com",
                BirthDate = new DateTime(1960, 7, 1),
                Gender = "Male",
                Nationality = "Adventurer",
                Rg = 123456789,
                Cpf = "78901234567"
            };
            Client c9 = new Client
            {
                Id = 9,
                Name = "Katniss Everdeen",
                Address = "District 12 Lane, 456",
                City = "Panem",
                State = "Unknown",
                Country = "The Hunger Games",
                PhoneNumber = "555-2345",
                Email = "katniss.everdeen@example.com",
                BirthDate = new DateTime(2000, 11, 3),
                Gender = "Female",
                Nationality = "District 12",
                Rg = 567890123,
                Cpf = "89012345678"
            };
            Client c10 = new Client
            {
                Id = 10,
                Name = "Sherlock Holmes",
                Address = "Baker Street, 221B",
                City = "London",
                State = "Unknown",
                Country = "United Kingdom",
                PhoneNumber = "555-7890",
                Email = "sherlock.holmes@example.com",
                BirthDate = new DateTime(1854, 1, 6),
                Gender = "Male",
                Nationality = "British",
                Rg = 234567890,
                Cpf = "90123456789"
            };
            Client c11 = new Client
            {
                Id = 11,
                Name = "Wonder Woman",
                Address = "Amazon Island, 567",
                City = "Themyscira",
                State = "Unknown",
                Country = "Paradise",
                PhoneNumber = "555-3456",
                Email = "wonder.woman@example.com",
                BirthDate = new DateTime(1985, 5, 15),
                Gender = "Female",
                Nationality = "Amazonian",
                Rg = 345678901,
                Cpf = "01234567890"
            };
            Client c12 = new Client
            {
                Id = 12,
                Name = "James Bond",
                Address = "Spy Lane, 007",
                City = "London",
                State = "Unknown",
                Country = "United Kingdom",
                PhoneNumber = "555-8765",
                Email = "james.bond@example.com",
                BirthDate = new DateTime(1963, 11, 12),
                Gender = "Male",
                Nationality = "British",
                Rg = 567890123,
                Cpf = "12345678901"
            };

            Client c13 = new Client
            {
                Id = 13,
                Name = "Mulan",
                Address = "Imperial Avenue, 888",
                City = "China",
                State = "Unknown",
                Country = "The Middle Kingdom",
                PhoneNumber = "555-9876",
                Email = "mulan@example.com",
                BirthDate = new DateTime(1998, 7, 2),
                Gender = "Female",
                Nationality = "Chinese",
                Rg = 678901234,
                Cpf = "23456789012"
            };

            Client c14 = new Client
            {
                Id = 14,
                Name = "Katara",
                Address = "Water Tribe Street, 321",
                City = "Southern Water Tribe",
                State = "Unknown",
                Country = "Avatar World",
                PhoneNumber = "555-5432",
                Email = "katara@example.com",
                BirthDate = new DateTime(1992, 3, 15),
                Gender = "Female",
                Nationality = "Water Tribe",
                Rg = 789012345,
                Cpf = "34567890123"
            };

            Client c15 = new Client
            {
                Id = 15,
                Name = "Aragorn",
                Address = "Ranger Road, 777",
                City = "Gondor",
                State = "Unknown",
                Country = "Middle-earth",
                PhoneNumber = "555-6543",
                Email = "aragorn@example.com",
                BirthDate = new DateTime(2931, 10, 1),
                Gender = "Male",
                Nationality = "Gondorian",
                Rg = 890123456,
                Cpf = "45678901234"
            };

            Client c16 = new Client
            {
                Id = 16,
                Name = "Elsa",
                Address = "Ice Palace Avenue, 456",
                City = "Arendelle",
                State = "Unknown",
                Country = "Frozen Kingdom",
                PhoneNumber = "555-8765",
                Email = "elsa@example.com",
                BirthDate = new DateTime(1998, 12, 21),
                Gender = "Female",
                Nationality = "Arendellian",
                Rg = 567890123,
                Cpf = "56789012345"
            };
            Client c17 = new Client
            {
                Id = 17,
                Name = "Captain America",
                Address = "Avenger Street, 1941",
                City = "New York",
                State = "NY",
                Country = "United States",
                PhoneNumber = "555-4321",
                Email = "captain.america@example.com",
                BirthDate = new DateTime(1918, 7, 4),
                Gender = "Male",
                Nationality = "American",
                Rg = 678901234,
                Cpf = "67890123456"
            };

            Client c18 = new Client
            {
                Id = 18,
                Name = "Katniss Everdeen",
                Address = "District 12 Lane, 456",
                City = "Panem",
                State = "Unknown",
                Country = "The Hunger Games",
                PhoneNumber = "555-2345",
                Email = "katniss.everdeen@example.com",
                BirthDate = new DateTime(2000, 11, 3),
                Gender = "Female",
                Nationality = "District 12",
                Rg = 789012345,
                Cpf = "89012345678"
            };

            Client c19 = new Client
            {
                Id = 19,
                Name = "Harry Potter",
                Address = "Wizardry Alley, 789",
                City = "Hogwarts",
                State = "Scotland",
                Country = "United Kingdom",
                PhoneNumber = "555-5678",
                Email = "harry.potter@example.com",
                BirthDate = new DateTime(1980, 7, 31),
                Gender = "Male",
                Nationality = "British",
                Rg = 890123456,
                Cpf = "90123456789"
            };

            Client c20 = new Client
            {
                Id = 20,
                Name = "Black Widow",
                Address = "Spy Lane, 567",
                City = "Moscow",
                State = "Unknown",
                Country = "Russia",
                PhoneNumber = "555-8765",
                Email = "black.widow@example.com",
                BirthDate = new DateTime(1984, 11, 22),
                Gender = "Female",
                Nationality = "Russian",
                Rg = 123456789,
                Cpf = "01234567890"
            };


            Employee e1 = new Employee
            {
                Id = 1,
                Matricula = 1001,
                Name = "Antonio",
                Address = "Qa 18 Mr Casa 09 Setor Leste",
                City = "Planaltina",
                State = "Goias",
                Country = "Brazil",
                PhoneNumber = "555-8765",
                Email = "antonio.leoncio@pousasavidaplea.com",
                BirthDate = new DateTime(1992, 11, 19),
                Gender = "Masculino",
                Nationality = "Brasileiro",
                Rg = "123456789",
                Cpf = "01234567890",
                EmployeeFunction = EmployeeFunction.Gerente
            };

            Employee e2 = new Employee
            {
                Id = 2,
                Matricula = 1002,
                Name = "Sakura",
                Address = "Rua das Flores, 10",
                City = "Konoha",
                State = "Hi no Kuni",
                Country = "Japão",
                PhoneNumber = "123-4567",
                Email = "sakura@konohagakure.com",
                BirthDate = new DateTime(1986, 3, 28),
                Gender = "Feminino",
                Nationality = "Japonesa",
                Rg = "987654321",
                Cpf = "01234567890",
                EmployeeFunction = EmployeeFunction.Administrativo
            };

            Employee e3 = new Employee
            {
                Id = 3,
                Matricula = 1003,
                Name = "Goku",
                Address = "Kame House, Master Roshi Island",
                City = "Earth",
                State = "Universe 7",
                Country = "Dragon Ball World",
                PhoneNumber = "777-1234",
                Email = "goku@saiyan.com",
                BirthDate = new DateTime(737, 4, 16),
                Gender = "Masculino",
                Nationality = "Saiyan",
                Rg = "111223344",
                Cpf = "0323456780",
                EmployeeFunction = EmployeeFunction.Gerais
            };

            // Funcionário fictício 4
            Employee e4 = new Employee
            {
                Id = 4,
                Matricula = 1004,
                Name = "Naruto Uzumaki",
                Address = "Hokage Residence, Hidden Leaf Village",
                City = "Konoha",
                State = "Hi no Kuni",
                Country = "Land of Fire",
                PhoneNumber = "987-6543",
                Email = "naruto@leafvillage.com",
                BirthDate = new DateTime(2002, 10, 10),
                Gender = "Masculino",
                Nationality = "Japanese",
                Rg = "876543210",
                Cpf = "01233267890",
                EmployeeFunction = EmployeeFunction.Suporte
            };

            // Funcionário fictício 5
            Employee e5 = new Employee
            {
                Id = 5,
                Matricula = 1005,
                Name = "Edward Elric",
                Address = "Resembool",
                City = "East Area",
                State = "Amestris",
                Country = "Fullmetal Alchemist World",
                PhoneNumber = "333-5678",
                Email = "edward@alchemy.com",
                BirthDate = new DateTime(1899, 2, 3),
                Gender = "Masculino",
                Nationality = "Amestrian",
                Rg = "987654321",
                Cpf = "01234567870",
                EmployeeFunction = EmployeeFunction.Gerais
            };

            // Funcionário fictício 6
            Employee e6 = new Employee
            {
                Id = 6,
                Matricula = 1006,
                Name = "Sailor Moon",
                Address = "Juuban District",
                City = "Tokyo",
                State = "Tokyo Metropolis",
                Country = "Japan",
                PhoneNumber = "111-9999",
                Email = "sailormoon@moonkingdom.com",
                BirthDate = new DateTime(1978, 6, 30),
                Gender = "Feminino",
                Nationality = "Japanese",
                Rg = "654321987",
                Cpf = "01264567890",
                EmployeeFunction = EmployeeFunction.Gerais
            };


            _context.Room.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12, r13, r14, r15);
            _context.Client.AddRange(c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20);
            _context.Employee.AddRange(e1, e2, e3, e4, e5, e6);


            _context.SaveChanges();
        }
    }
}
