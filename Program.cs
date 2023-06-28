using System;
using System.Collections.Generic;
using System.IO;
using TareasClass;
using System.Linq;
//1. Cree aleatoriamente N tareas pendientes.
internal class Program{
    private static void Main(string[] args){
        Random rand = new Random(); //Creamos una instancia de random
        int cantidad = rand.Next(2,5); //Creamos una cantidad aleatoria
        //Creacion de lista de descripciones
        List<string> Descripciones = new List<string>(){
            "Mantenimiento de Funcionarias",
            "Reposicion de Producciones",
            "Atencion al cliente",
            "Produccion de Materiales"
        };
        //Creacion de lista de Tareas Pendientes
        List<Tarea> TareasPendien = new List<Tarea>();

        //Cargamos Las Tareas en la lista
        for (int i = 0; i < cantidad; i++)
        {
            string descripcion = Descripciones[rand.Next(Descripciones.Count)]; //
            Tarea Tareas = new Tarea(i, descripcion, rand.Next(1,11));
            TareasPendien.Add(Tareas); //Añadimos las tareas a la lista de las tareas pendientes
        }

        Console.WriteLine("\nIngrese la descripcion de la Tarea: ");
        string? descripB = Console.ReadLine();
        int j = BuscarTareaDescripcion(TareasPendien, descripB);
        if (j!=-99)
        {
            Console.WriteLine("\nLa Tarea Se Encontro con Exito :]");
            Console.WriteLine( TareasPendien[j].mostrarTarea());
        }else
        {
            Console.WriteLine("No se Encontro esa Tarea :(");
        }

        //Mostramos las Tareas Pendientes;
        Console.WriteLine("\n--------------Tareas Pendientes --------------");
        foreach (var item in TareasPendien)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine("-----------");
        }
        //Creacion de tareas Realizadas
        List<Tarea> TareasRealizadas = new List<Tarea>();
        MoverTareas(TareasPendien, TareasRealizadas);

        Console.WriteLine("\n--------------Tareas Realizadas --------------");
        foreach (var item in TareasRealizadas)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine("-----------");
        }
        //Eliminamos la Tarea Realizada de la lista de Tarea Pendiente
        foreach (var item in TareasRealizadas)
        {
            TareasPendien.Remove(item);
        }
        Console.WriteLine("\n--------------Tareas Pendientes --------------");
        foreach (var item in TareasPendien)
        {
            Console.WriteLine(item.mostrarTarea());
            Console.WriteLine("-----------");
        }

        /*4. Guarde en un archivo de texto un sumario de las horas trabajadas por el
        empleado (sumatoria de la duración de las tareas).*/
        string RutaArchivo = @"C:\Taller1\tl1_tp8_2023-majoserra\";
        string nombreArchivo = "HorasTrabajadas.txt";
        string nuevoArchivo = RutaArchivo + nombreArchivo;

        using (StreamWriter sw = new StreamWriter(nuevoArchivo, true)){
            TimeSpan HT = CantidadHoras(TareasRealizadas);
            sw.WriteLine($"Horas Trabajadas: {HT}");
        }



         
    }

    public static void MoverTareas(List<Tarea> TareasPendien, List<Tarea> TareasRealizadas){
        int resp=0;
        for (int i = 0; i < TareasPendien.Count; i++)
        {
            Console.WriteLine("\nId: "+TareasPendien[i].Tareaid);
            Console.WriteLine("\nDescripcion: "+TareasPendien[i].Descripcion);
            Console.WriteLine("\nDuracion: "+TareasPendien[i].Duracion);
            Console.WriteLine("Realizo la Tarea?: ");
            int.TryParse(Console.ReadLine(), out resp);
            if(resp == 1){
                TareasRealizadas.Add(TareasPendien[i]);
            }
            Console.WriteLine("------------------------");
        }
        
    }
    //3. Desarrolle una interfaz para buscar tareas pendientes por descripción.
    public static int BuscarTareaDescripcion(List<Tarea> Tareas, string descrip){
        for (int i = 0; i < Tareas.Count ; i++)
        {
            if (Tareas[i].Descripcion == descrip)
            {
                return i;
            }
        }
        return -99;
    }
    public static TimeSpan CantidadHoras(List<Tarea> Lista){
        TimeSpan HorasTrabajadas = TimeSpan.Zero; //Inicializamos en zero
        TimeSpan durac;
        foreach (var item in Lista)
        {
            TimeSpan.TryParse(item.Duracion.ToString(), out durac);
            HorasTrabajadas += durac;
        }
        return HorasTrabajadas;
    }
   
}
