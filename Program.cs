namespace TP02_Censo_Nacional;
class Program
{
    static void Main(string[] args)
    {
        int num, dni, cantVotan = 0, cantPersonas = 0, acumEdad = 0, promedio = 0, quiereInfo;
        string ape, nom, mail;
        bool esMail = true;
        DateTime nac = new DateTime();
        Dictionary<int, Persona> DicPersona = new Dictionary<int, Persona>();


        do
        {
            Menu();
            num = IngresarEnteroPositivo("Ingrese opcion requerida:");
            switch (num)
            {
                case 1:
                    dni = IngresarEnteroPositivo("Ingrese DNI: ");

                    while (DicPersona.ContainsKey(dni))
                    {
                        dni = IngresarEnteroPositivo("DNI REGISTRA PREVIAMENTE. Ingrese otro dni: ");
                    }

                    ape = IngresarCadena("Ingrese Apellido: ");
                    nom = IngresarCadena("Ingrese Nombre: ");
                    nac = DateTime.Parse(IngresarCadena("Ingrese su feche de nacimiento (año/mes/dia): "));

                    mail = IngresarCadena("Ingrese su mail: ");
                    while (!VerificarMail(mail))
                    {
                        mail = IngresarCadena("Ingrese su mail: ");
                        esMail = VerificarMail(mail);
                    }

                    Persona i = new Persona(dni, ape, nom, nac, mail);
                    DicPersona.Add(dni, i);

                    Console.WriteLine("Se ha creado una persona");
                    if (i.PuedeVotar(nac))//verificacion
                    {
                        cantVotan++;
                    }
                    cantPersonas++;
                    acumEdad = acumEdad + i.ObtenerEdad(nac);
                    promedio = acumEdad / cantPersonas;

                break;

                case 2:
                    Console.WriteLine("Estadisticas del Censo:");
                    Console.WriteLine("Cantidad de personas:" + cantPersonas);
                    Console.WriteLine("Cantidad de votantes:" + cantVotan);
                    Console.WriteLine("Promedio:" + promedio);
                break;

                case 3:
                    quiereInfo = IngresarEnteroPositivo("Ingrese DNI que quiere info:");

                    if (DicPersona.ContainsKey(quiereInfo))
                    {
                        Console.WriteLine(DicPersona[quiereInfo]);
                    }
                    else
                    {
                        Console.WriteLine("“No se encuentra el DNI”");
                    }

                break;

                case 4:

                    quiereInfo = IngresarEnteroPositivo("Ingrese DNI quiere cambiar mail:");
                    ModificarMail(DicPersona,quiereInfo);
                    Console.WriteLine("Mail modificado: " + DicPersona[quiereInfo].Email);
                break;
                
                case 5:
                    Console.WriteLine("Chau!");
                break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (num != 5);

    }
    static void Menu()
    {
        Console.WriteLine("1.Cargar Nueva Persona\n2.Obtener Estadísticas del Censo\n3.Buscar Persona\n4.Modificar Mail de una Persona\n5.Salir");
    }
    static int IngresarEnteroPositivo(string mensaje)
    {
        Console.Write(mensaje);
        int num = int.Parse(Console.ReadLine());
        while (num <= 0)
        {
            Console.Write("ERROR!NUMERO NEGATIVO.Vuelva a ingresar:");
            num = int.Parse(Console.ReadLine());
        }
        return num;
    }
    static string IngresarCadena(string mensaje)
    {
        Console.Write(mensaje);
        string cadena = Console.ReadLine();
        return cadena;
    }
    static bool VerificarMail(string mail)
    {
        bool esMail = false;
        if (mail.Contains("@") && mail.LastIndexOf(".") != mail.Length && mail.IndexOf("@") != 0 && mail.IndexOf("@") != mail.Length && mail.IndexOf("@") < mail.LastIndexOf("."))
        {
            esMail = true;
        }
        return esMail;
    }
    static void ModificarMail(Dictionary<int, Persona> DicPersona, int dni)
    {
        
        if (DicPersona.ContainsKey(dni))
        {
            DicPersona[dni].Email = IngresarCadena("Ingrese mail nuevo:");
            while (!VerificarMail(DicPersona[dni].Email))
            {
                DicPersona[dni].Email = IngresarCadena("ERROR!Ingrese mail nuevo:");
            }
        }
    }
}

