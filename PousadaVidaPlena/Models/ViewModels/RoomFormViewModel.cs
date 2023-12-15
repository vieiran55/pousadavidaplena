using PousadaVidaPlena.Models.Enums;

namespace PousadaVidaPlena.Models.ViewModels
{
    public class RoomFormViewModel
    {
        public Room Room { get; set; }
        public ICollection<RoomType> RoomTypes { get; set; }
    }
}
