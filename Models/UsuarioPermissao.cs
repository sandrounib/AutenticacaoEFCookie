using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class UsuarioPermissao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]        
        public int IdUsuarioPermisao { get; set; }
        
        [Required]
        public int IdUsuario { get; set; }
        
        [ForeignKey("IdUsuario")]
        

        [Required]        
        public int  IdPermissao { get; set; }
        [ForeignKey("IdPermissao")]

        public Permissao Permissao{get;set;}
    }
}