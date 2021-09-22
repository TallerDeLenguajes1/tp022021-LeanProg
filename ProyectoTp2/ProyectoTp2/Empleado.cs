using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoTp2
{
    public class Empleado
    {

        private string nombre;
        private string apellido;
        private string direccion;
        private DateTime fechaNacimiento;
        private DateTime fechaIngreso;
        private string titulo;
        private long matricula;
        private static double sueldobasico = 70000;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public long Matricula { get => matricula; set => matricula = value; }
        public static double Sueldobasico { get => sueldobasico; set => sueldobasico = value; }
        public string Apellido { get => apellido; set => apellido = value; }

        public Empleado(string nombre, string apellido, string direccion,DateTime fechaNacimiento, DateTime fechaIngreso, string titulo, long matricula)
        {
            this.Nombre = nombre;
            this.apellido = apellido;
            this.Direccion = direccion;
            this.fechaNacimiento = fechaNacimiento;
            this.FechaIngreso = fechaIngreso;
            this.Titulo = titulo;
            this.Matricula = matricula;
            
        }

        //Calcular antiguedad
        public int DevolverAntiguedad()
        {
            int fechaActual = Convert.ToInt32(DateTime.Now.Year);
            int count=0;
            int fechaempleado = Convert.ToInt32(this.fechaIngreso.Year);
            while (fechaempleado<fechaActual)
            {
                count++;
                fechaempleado++;
            }
            return count;
        }
        //FUNCION PARA CALCULAR EDAD DEL EMPLEADO
        public int EdadEmpleado()
        {
            int fechaActual = Convert.ToInt32(DateTime.Now.Year);
            int edad; ;
            edad = fechaActual - Convert.ToInt32(this.fechaNacimiento.Year);
            return edad;
        }
        //FUNCION PARA CALCULAR SALARIO DEL EMPLEADO
        public double SalarioEmpleado()
        {
            int antiguedad = this.DevolverAntiguedad();
            double salario = 0;

            if (antiguedad >= 1 && antiguedad < 20)
            {
                salario = sueldobasico + ((1 / 100) * sueldobasico * antiguedad) - 0.15 * sueldobasico;
                return salario;
            }
            else
            {
                salario = sueldobasico + ((1 / 100) * sueldobasico * 25) - 0.15 * sueldobasico;
                return salario;
            }
        
            
        }


        


    }

}

   
