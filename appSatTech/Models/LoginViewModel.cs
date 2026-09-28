using System.ComponentModel.DataAnnotations;

namespace appSatTech.Models
{
    // ViewModel utilizada exclusivamente para capturar e validar os dados de entrada na tela de Login
    public class LoginViewModel
    {
        // Define que o campo é obrigatório. Se enviado vazio, exibe a mensagem personalizada.
        [Required(ErrorMessage = "O CPF é obrigatório.")]

        // Configura o rótulo de exibição amigável do campo nas Views Razor (usado pelo <label asp-for="Cpf">)
        [Display(Name = "CPF do Cliente")]

        // Propriedade que armazena o CPF informado, inicializada como string vazia para evitar avisos de nulidade (null-safety)
        public string Cpf { get; set; } = string.Empty;
    }
}
