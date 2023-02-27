using Agenda.Contatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Contatos.Repository
{
    public interface IUsuarioRepository
    {
        UsuarioModel BuscarPorId(int id);

        List<UsuarioModel> BuscarTodos();

        UsuarioModel Cadastrar(UsuarioModel usuario);

        UsuarioModel EditarContato(UsuarioModel usuario);

        bool ApagarContato(int id);
    }
}
