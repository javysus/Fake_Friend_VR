using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DatosUsuario
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Root
    {
        public bool exito { get; set; }
        public string mensaje { get; set; }
        public Sesion sesion { get; set; }
    }

    public class Sesion
    {
        public string agua_organismo { get; set; }
        public int id_sustancia { get; set; }
        public int id_usuario { get; set; }
        public int idusuario_sustancia { get; set; }
        public string temperatura_corp { get; set; }
    }
}