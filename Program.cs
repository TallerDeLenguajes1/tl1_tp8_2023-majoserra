using System;
using System.Collections.Generic;
using System.IO;
using TareasClass;
using System.Linq;
//1. Cree aleatoriamente N tareas pendientes.
internal class Program{
    private static void Main(string[] args){

        string rutaCarpeta = @"C:\Taller1\tl1_tp8_2023-majoserra\";

        if (Directory.Exists(rutaCarpeta)) //si el directorio existe listamos los archivos 
        {
            //Listar los archivos 
            //Creamos una lista 
            List<string> Listado = Directory.GetFiles(rutaCarpeta).ToList(); //Obtenemos los archivos del directorio y los transformamos a lista
            Console.WriteLine("\nLos Archivos en "+rutaCarpeta+" son:");

            //Trabajamos normalmente como en lista
            foreach (var item in Listado)
            {
                Console.WriteLine(item);//Escribimos los archivos
            }

            string nombreArchivo = "index.csv";
            string NuevoArchivo = rutaCarpeta + nombreArchivo;

            using (StreamWriter sw = new StreamWriter(NuevoArchivo, true)){
                for (int i = 0; i < Listado.Count; i++)
                {
                    string extension = Path.GetExtension(Listado[i]);
                    string nombre = Path.GetFileNameWithoutExtension(Listado[i]);
                    sw.WriteLine(i+";"+nombre+";"+extension);
                }

            }

            
        }else
        {
            Console.WriteLine("No se encontro el Directorio");
        }

        


         
    }
   
}
