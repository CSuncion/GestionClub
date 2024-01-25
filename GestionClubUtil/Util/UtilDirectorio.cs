using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeclaracionesUtil.Util
{
    public class UtilDirectorio
    {
        public static void CrearCarpeta(string ruta)
        {
            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }
        }
        public static void ExisteArchivo(string rutaCompleta)
        {
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }
        }
    }
}
