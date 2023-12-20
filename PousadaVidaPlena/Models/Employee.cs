// Employee.cs
using PousadaVidaPlena.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PousadaVidaPlena.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Matrícula")]
        public int Matricula { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Display(Name = "Cidade")]
        public string City { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "País")]
        public string Country { get; set; }

        [Display(Name = "Número de telefone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Gênero")]
        public string Gender { get; set; }

        [Display(Name = "Nacionalidade")]
        public string Nationality { get; set; }

        [Display(Name = "RG")]
        public int Rg { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "CPF")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid CPF")]
        [CustomValidation(typeof(Client), "ValidateCpf")]
        public string Cpf { get; set; }

        public EmployeeFunction EmployeeFunction { get; set; }

        public Employee() { }

        public Employee(int id, int matricula, 
            string name, string address, string city,
            string state, string country, string phoneNumber,
            string email, DateTime birthDate, string gender,
            string nationality, int rg, string cpf, EmployeeFunction employeeFunction)
        {
            Id = id;
            Matricula = matricula;
            Name = name;
            Address = address;
            City = city;
            State = state;
            Country = country;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Nationality = nationality;
            Rg = rg;
            Cpf = cpf;
            EmployeeFunction = employeeFunction;
        }

        public static ValidationResult ValidateCpf(string cpf, ValidationContext context)
        {
            if (cpf.Length == 11)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid CPF");
        }
    }
}
