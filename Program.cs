namespace TP02_Censo_Nacional;
class Program
{
    static void Main(string[] args)
    {
        int num,dni,cantVotan=0,cantPersonas=0,acumEdad=0,promedio=0,quiereInfo;
        string ape,nom,mail;
        DateTime nac=new DateTime();
        Dictionary<int,Persona> DicPersona=new Dictionary<int, Persona>();
        
        
        do{
            Menu();
            num=IngresarEnteroPositivo("Ingrese opcion requerida:");
            switch(num)
            {
            case 1:
            dni=IngresarEnteroPositivo("Ingrese DNI:");

            while(DicPersona.ContainsKey(dni))
            {
                dni=IngresarEnteroPositivo("DNI REGISTRA PREVIAMENTE. Ingrese otro dni:");
            }

            ape=IngresarCadena("Ingrese Apellido:");
            nom=IngresarCadena("Ingrese Nombre:");
            nac=DateTime.Parse(IngresarCadena("Ingrese su feche de nacimiento (año/mes/dia):"));
            mail=IngresarCadena("Ingrese su mail");

            Persona i= new Persona(dni,ape,nom,nac,mail);
            DicPersona.Add(dni,i);

            Console.WriteLine("Se ha creado una persona");
            if(i.PuedeVotar(nac))//verificacion
            {
                cantVotan++;
            }
            cantPersonas++;
            acumEdad=acumEdad + i.ObtenerEdad(nac);
            promedio=acumEdad/cantPersonas;

            break;
            
            case 2:
            Console.WriteLine("Estadisticas del Censo:");
            Console.WriteLine("Cantidad de personas:"+cantPersonas);
            Console.WriteLine("Cantidad de votantes:"+cantVotan);
            Console.WriteLine("Promedio:"+ promedio);            
            break;
            
            case 3:
            quiereInfo=IngresarEnteroPositivo("Ingrese DNI que quiere info:");
            Console.WriteLine(DicPersona[quiereInfo]);

            break;
            
            case 4:
            break;
            
            case 5:
            Console.WriteLine("Chau!");
            break;
            }
            Console.Clear();
        }while(num!=5);



    }
    static void Menu()
    {
    Console.WriteLine("1.Cargar Nueva Persona\n2.Obtener Estadísticas del Censo\n3.Buscar Persona\n4.Modificar Mail de una Persona\n5.Salir");
    }
    static int IngresarEnteroPositivo(string mensaje)
    {
        Console.Write(mensaje);
        int num=int.Parse(Console.ReadLine());

        while(num<=0)
        {
            Console.Write("ERROR!NUMERO NEGATIVO.Vuelva a ingresar:");
            num=int.Parse(Console.ReadLine());
        }
        return num;
    }
    static string IngresarCadena(string mensaje)
    {
        Console.Write(mensaje);
        string cadena= Console.ReadLine();
        return cadena;
    }
    
    
}
