using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace autenticacaoefcookie.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        
        [StringLength(100,MinimumLength=4)] 
        [Required]       
        public string Nome { get; set; }
        
        [Required]
        [StringLength(50,MinimumLength=4)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(12,MinimumLength=4)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public ICollection<UsuarioPermissao> UsuariosPermissoes {get;set;}
        
    }
}