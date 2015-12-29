using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;


namespace Capaaccesodatos
{
  public class Lista_Usuarios : CapaDatoAbstractaSingleton<Lista_Usuarios>,I_CapaDatos<Usuario>
  {
     
    private List<Usuario> ColeccionUsuarios = new List<Usuario>();

    public Lista_Usuarios()
    {

    }

    public void Agregar(Usuario oUsuario)
    {
        int Id_ultimo = ColeccionUsuarios.Count + 1; // ultimo Id
        oUsuario.Id = Id_ultimo;
        ColeccionUsuarios.Add(oUsuario);
    }

    public void Remover(Usuario dato)
    {
        ColeccionUsuarios.Remove(dato);
    }

    public void Modificar(Usuario dato)
    {
        throw new NotImplementedException();
    }

    public List<Usuario> TraerTodos()
    {
        return ColeccionUsuarios; 
    }

    public Usuario Buscar_por_USUARIO(string p_IdUsuario)
    {
        Usuario oUsuario = ColeccionUsuarios.FirstOrDefault(x => x.IdUsuario == p_IdUsuario); //busca en la lista si existe retorna el usuario
        if (oUsuario == null)
        {
            throw new Exception("El usuario no Existe");
        }
        return oUsuario;
    }

    public Usuario Buscar_por_ID(int Id)
    {
        throw new NotImplementedException();
    }
  }

}
