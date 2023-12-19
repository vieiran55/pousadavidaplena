using System.ComponentModel.DataAnnotations;

namespace PousadaVidaPlena.Models.Entities
{
    public class ClientCompanion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "{0} required")]
        public string CompanionName { get; set; }

        public Client Client { get; set; }

        public ClientCompanion() { }

        public ClientCompanion(int id, int clientId, string companionName, Client client)
        {
            Id = id;
            ClientId = clientId;
            CompanionName = companionName;
            Client = client;
        }
    }
}
