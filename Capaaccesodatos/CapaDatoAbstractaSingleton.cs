using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capaaccesodatos
{
    public abstract class CapaDatoAbstractaSingleton <S> where S: CapaDatoAbstractaSingleton<S>, new()
    {
        
     private static S _instance;      
    
     public static S Instance()
        {
              if (_instance == null)
              {
                 _instance = new S();
                }
                return _instance;
         }
      }
}
