using RegistroP.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Data;
using RegistroP.Entidades;
using Microsoft.EntityFrameworkCore;
using RegistroP.UI.Registros;
using RegistroP.UI;


namespace RegistroP.BLL.Tests
{
    [TestClass()]
    public class PersonasBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.PersonaId = 0;
            personas.Nombre = "Luis";
            personas.Telefono = "8295092787";
            personas.Direccion = "Principal Villa Tapia";
            personas.Balance = 0;
            paso = PersonasBLL.Guardar(personas);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }
    }
}