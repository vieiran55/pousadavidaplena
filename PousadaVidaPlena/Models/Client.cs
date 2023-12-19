// Client.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PousadaVidaPlena.Models.Entities;

namespace PousadaVidaPlena.Models;
public class Client
{
    public int Id { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Display(Name = "Endereço")]
    public string Address { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Display(Name = "Número de telefone")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "{0} required")]
    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; }

    public Client() { }

    public Client(int id, string name, string address, string phoneNumber, string email)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}
