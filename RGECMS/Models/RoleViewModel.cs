
using System.ComponentModel.DataAnnotations;
namespace RGECMS.Models
{
    public class RoleViewModel
    {
        public RoleViewModel()
        {

        }
        public RoleViewModel(ApplicationRole role)
        {
            Id = role.Id;
            name = role.Name;
        }
      public string Id { get; set; }
        [Required]
        public string name { get; set; }
    }
}