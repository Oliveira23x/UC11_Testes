using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitariosApp
{
    public class Cliente
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente(int id, string nome, string email, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Endereco = endereco;
        }

        public string ObterInformacoes()
        {
            return $"ID: {Id}\nNome: {Nome}\nEmail: {Email}\n Endereço: {Endereco.FormatarEndereco()}";
        }

        public bool EmailValido()
        { 
            return Email.Contains("@") && Email.Contains(".");
        }
    }
}
