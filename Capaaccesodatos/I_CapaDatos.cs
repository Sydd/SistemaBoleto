using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capaaccesodatos
{
    /// <summary>
    /// Interfaz para guardar cosas en la base de datos.
    /// </summary>
    /// <typeparam name="T">Objeto a ser guardado en la Base de datos</typeparam>
    public interface I_CapaDatos<T>
    {
        void Agregar(T dato);
        void Remover(T dato);
        void Modificar(T dato);
        List<T>TraerTodos();
        T Buscar_por_ID(int Id);

    }
}
