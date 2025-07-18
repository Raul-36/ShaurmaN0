using System.ComponentModel.DataAnnotations;

namespace ShaurmaN0App.Models;
public class MenusCategory {
    public Guid Id { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    public ICollection<Menus> Menus { get; set; } = new List<Menus>();
}