﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prySp1FerMoya
{
    public class ClassArchivo
    {
        // propiedades
        public string NombreArchivo { get; set; }
        // métodos
        // recibirá un objeto de tipo Repuesto y devolverá un valor booleano para informar el resultado de la grabación.
        public bool GrabarRepuesto(Repuesto repuesto)
        {
            // recibe un objeto de tipo Repuesto y lo graba en el archivo
            bool resultado = false;
            if (NombreArchivo != "")
            {
                // crea el stream en modo append
                StreamWriter sw = new StreamWriter(NombreArchivo, true);
                // graba la linea con los valores de los campos
                sw.WriteLine(repuesto.Codigo + "," +
                repuesto.Nombre + "," +
                repuesto.Marca + "," +
                repuesto.Precio.ToString("#.00", CultureInfo.InvariantCulture) +
                "," +
                repuesto.Origen);
                sw.Close(); // cerrar el stream
                sw.Dispose(); // liberar los recursos
                resultado = true;
            }
            return resultado;
        }
        public bool BuscarCodigoRepuesto(string codigo)
        {
            // recibe el código del repuesto a buscar
            // devuelve falso si el código no existe en el archivo
            // devuelve verdadero si el código ya está grabado
            bool resultado = false;
            string Linea;
            string CodigoRepuesto;
            // verificar que el archivo existe
            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                // crear el stream en modo lectura
                StreamReader sr = new StreamReader(NombreArchivo);
                // leer hasta el final
                while (sr.EndOfStream == false)
                {
                    Linea = sr.ReadLine(); // lee una linea completa
                                           // el código está en el primer valor de cada línea
                    CodigoRepuesto = Linea.Split(',')[0];
                    // comparar el código buscado con el del archivo
                    if (codigo == CodigoRepuesto)
                    {
                        // si son iguales devuelve verdadero
                        resultado = true;
                        break; // sale del ciclo de lectura
                    }
                }
                sr.Close(); // cerrar el stream
                sr.Dispose(); // liberar los recursos
            }
            return resultado;
        }
        public List<Repuesto> ObtenerRepuestos()
        {
            // lee el contenido completo del archivo y lo
            // almacena en una lista de objetos 'Repuesto'
            List<Repuesto> Lista = new List<Repuesto>();
            string Linea;
            if (NombreArchivo != "" && File.Exists(NombreArchivo))
            {
                StreamReader sr = new StreamReader(NombreArchivo);
                while (sr.EndOfStream == false)
                {
                    Linea = sr.ReadLine(); // lee una linea del archivo
                                           // crea un objeto 'Repuesto' y rellena sus propiedades
                    ClassRepuestos repuesto = new ClassRepuestos();
                    repuesto.Codigo = Linea.Split(',')[0];
                    repuesto.Nombre = Linea.Split(',')[1];
                    repuesto.Marca = Linea.Split(',')[2];
                    // el valor decimal se formatea sin formatos regionales
                    // para mantener el punto como separador decimal
                    repuesto.Precio = decimal.Parse(Linea.Split(',')[3],
                    CultureInfo.InvariantCulture);
                    repuesto.Origen = Linea.Split(',')[4];
                    Lista.Add(repuestos); // se agrega el repuesto a la lista
                }
                sr.Close(); // cerrar
                sr.Dispose(); // liberar recursos
            }
            // devuelve la lista de repuestos completa
            return Lista;


        }
        List<Repuesto> Lista = new List<Repuesto>();

        public List<Repuesto> ObtenerRepuestosOrdenados()
        {
            // lee el contenido completo del archivo y lo
            // almacena en una lista de objetos 'Repuesto'
            List<Repuesto> Lista = ObtenerRepuestos();
            // convertir la lista en un arreglo con el método "ToArray()"
            Repuesto[] repuestosArray = Lista.ToArray();
            // ordenar el arreglo con el método de Burbuja
            // por el campo Nombre en forma ascendente (de menor a mayor)
            for (int i = 0; i < repuestosArray.Length - 1; i++)
            {
                for (int j = 0; j < repuestosArray.Length - 1; j++)
                {
                    // se comparan los nombres de los repuestos
                    // usando el método 'Compare' de la clase string
                    if (string.Compare(repuestosArray[j].Nombre,
                    repuestosArray[j + 1].Nombre) > 0)
                    {
                        // se intercambian si el nombre en j es mayor al nombre en j+1
                        Repuesto aux = repuestosArray[j];
                        repuestosArray[j] = repuestosArray[j + 1];
                        repuestosArray[j + 1] = aux;
                    }
                }
            }
            // convertir el arreglo ya ordenado en una lista
            List<Repuesto> Ordenados = repuestosArray.ToList<Repuesto>();
            // devuelve la lista de respuestos ordenada por nombre en forma ascendente
            return Ordenados;
        }
       
    }
}
