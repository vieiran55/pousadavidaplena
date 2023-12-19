namespace PousadaVidaPlena.Models.Entities
{
    public class Companion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Propriedade de navegação para associar com a entidade Client
        public int ClientId { get; set; }
        public Client Client { get; set; }

        public Companion() { }

        public Companion(int id, string name, int clientId, Client client)
        {
            Id = id;
            Name = name;
            ClientId = clientId;
            Client = client;
        }
    }
}
