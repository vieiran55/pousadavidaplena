// Client.cs
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PousadaVidaPlena.Models.Entities;

namespace PousadaVidaPlena.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Logradouro")]
        public string Address { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Cidade")]
        public string City { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Estado")]
        public string State { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "País")]
        public string Country { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Número de telefone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Gênero")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Nacionalidade")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "RG")]
        public int Rg { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "CPF")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "Invalid CPF")]
        [CustomValidation(typeof(Client), "ValidateCpf")]
        public string Cpf { get; set; }

        public Client() { }

        public Client(int id, string name, string address, string phoneNumber, string email,
                      DateTime birthDate, string gender, string nationality, int rg, string cpf, string estado, string cidade, string country)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Nationality = nationality;
            Rg = rg;
            Cpf = cpf;
            City = cidade;
            State = estado;
            Country = country;
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
