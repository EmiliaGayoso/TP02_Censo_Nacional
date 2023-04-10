class Persona
{
    public int DNI{get;set;}
    public string Apellido{get;set;}
    public string Nombre{get;set;}
    public DateTime Nacimiento{get;set;}
    public string Email{get;set;}

    public Persona(int dni, string ape,string nom,DateTime nac,string mail)
    {
        DNI=dni;
        Apellido=ape;
        Nombre=nom;
        Nacimiento=nac;
        Email=mail;
    }
    public bool PuedeVotar(DateTime nac)
    {
        bool puedeVotar=false;
        int edad=ObtenerEdad(nac);

        if(edad>=16)
        {
            puedeVotar=true;
        }
        return puedeVotar;
    }
    public int ObtenerEdad(DateTime nac)
    {
        DateTime hoy= DateTime.Today;
        int edadPersona=hoy.Month - nac.Month;
        return edadPersona;
    }
}