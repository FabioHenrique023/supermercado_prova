using System.ComponentModel.DataAnnotations;
namespace supermercado_prova.Models;
public class Usuario : Entity
{
    [Required(ErrorMessage="O campo usuário é obrigatório")]
    public string Login {get; set;}
    
    [Required(ErrorMessage="O campo senha é obrigatório")]
    public string Senha {get; set;}   
}