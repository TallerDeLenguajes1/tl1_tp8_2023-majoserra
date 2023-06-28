//Crearemos una clase de tareas;
namespace TareasClass;

public class Tarea{
    private int tareaid;
    private string? descripcion;
    private int duracion;

    public Tarea(int tareaid, string? descripcion, int duracion){
        this.Tareaid = tareaid;
        this.Descripcion = descripcion;
        this.Duracion = duracion;
    }

    public int Tareaid { get => tareaid; set => tareaid = value; }
    public string? Descripcion { get => descripcion; set => descripcion = value; }
    public int Duracion { get => duracion; set => duracion = value; }

    public string mostrarTarea(){
        string Mensaje = $"ID: {Tareaid} \n Descripcion: {Descripcion} \n Duracion: {Duracion}";
        return Mensaje;
    }
}