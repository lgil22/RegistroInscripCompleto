using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroP.BLL;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroP.Entidades;
using Microsoft.EntityFrameworkCore;
using RegistroP.UI.Registros;
using RegistroP.UI;

namespace RegistroP.BLL.Tests
{
    [TestClass()]
    public class InscripcionesBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Inscripciones inscrip = new Inscripciones();
            inscrip.InscripcionId = 0;
            inscrip.Fecha = DateTime.Now;
            inscrip.PersonaId = 1;
            inscrip.Comentarios = "Test Debuging";
            inscrip.Monto = 500;
            paso = InscripcionesBLL.Guardar(inscrip);
            Assert.AreEqual(paso, true);
           
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Inscripciones inscrip = new Inscripciones();
            inscrip.InscripcionId = 1;
            inscrip.Fecha = DateTime.Now;
            inscrip.PersonaId = 1;
            inscrip.Comentarios = "Test Debuging";
            inscrip.Monto = 1000;
            paso = InscripcionesBLL.Guardar(inscrip);
            Assert.AreEqual(paso, true);

        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = InscripcionesBLL.Eliminar( 1,  0);
            Assert.AreEqual(paso, true);
           
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Inscripciones inscrip;
            inscrip = InscripcionesBLL.Buscar(3);
            Assert.AreEqual(2, 1);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var listado = new List<Inscripciones>();
            listado = InscripcionesBLL.GetList(p => true);
            Assert.AreEqual(listado, listado);
        }
    }
}