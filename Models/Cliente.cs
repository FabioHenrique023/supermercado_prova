using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace supermercado_prova.Models;
public class Cliente : Entity
{

    [Required(ErrorMessage="Campo Codigo Fiscal é obrigatório")]
    [Display(Name = "Codigo Fiscal")]
    [Remote(action: "VerificaDuplicidade", controller: "Cliente")]
    public string? CodigoFiscal { get; set; }

    [Required(ErrorMessage="Campo Inscrição Estadual é obrigatório")]
    [Display(Name = "Inscrição Estadual")]
    [StringLength(15, ErrorMessage = "O campo Inscrição Estadual deve ter 15 caracteres.", MinimumLength=15 )]
    [RegularExpression("^[0-9]*$", ErrorMessage = "O campo Inscrição Estadual deve conter apenas números.")]
    [Remote(action: "VerificaDuplicidade", controller: "Cliente")]
    public string? InscricaoEstadual { get; set; }

    [Required(ErrorMessage="Campo Nome é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage="Campo Nome Fantasia é obrigatório")]
    [Display(Name = "Nome Fantasia")]
    public string? NomeFantasia { get; set; }

    [Required(ErrorMessage="Campo Endereço é obrigatório")]
    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }

    [Required(ErrorMessage="Campo Número é obrigatório")]
    [RegularExpression("^[0-9]*$", ErrorMessage = "O campo Número deve conter apenas números.")]
    [Display(Name = "Número")]
    public long Numero { get; set; }

    [Required(ErrorMessage="Campo Bairro é obrigatório")]
    public string? Bairro { get; set; }

    [Required(ErrorMessage="Campo Cidade é obrigatório")]
    public string? Cidade { get; set; }

    [Required(ErrorMessage="Campo Estado é obrigatório")]
    public string? Estado { get; set; }

    [Required(ErrorMessage="Campo Data é obrigatório")]
    [Display(Name = "Data de Nascimento ou Abertura")]
    public DateTime? DataCliente { get; set; }

    [Display(Name = "Imagem(apenas uma)")]
    public string? Imagens { get; set; }
}