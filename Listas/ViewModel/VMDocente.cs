
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Listas.Model;
using System.Collections.ObjectModel;

namespace Listas.ViewModel
{
    public class VMDocente : INotifyPropertyChanged
    {
        public VMDocente()
        {

            DarClase = new Command(
                    () => {
                        HorasClaseAcumulada = HorasClaseAcumulada + HorasClase;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }
                );

            Guardar = new Command(
                   () => 
                   {


                       ModelDocente x = new ModelDocente()
                       {
                           nombre = Nombre,
                           identidad = Identidad,
                           
                       };

                        bool existia = false;

                       for (int i = 0; i < listaGuardar.Count; i++)
                       {

                           if (listaGuardar[i].identidad == Identidad)
                           {
                               listaGuardar[i] = x;
                               existia = true;
                           }


                       }

                       if (existia == false)
                       {
                           listaGuardar.Add(x);
                       }


                   }

               );

            Buscar = new Command(
                    () =>
                    {

                        ModelDocente temporal = new ModelDocente();

                        for (int i = 0; i < listaGuardar.Count; i++)
                        {

                            temporal = listaGuardar[i];

                            if (temporal.identidad == Identidad)
                            {

                                Nombre = temporal.nombre;
                                HorasClase = temporal.horasacumuladas;
                                Reporte = temporal.calculoSalario();

                            }

                        }

                    };



                    ResetHorasClase = new Command
                (

                    () => 
                    {

                        HorasClaseAcumulada = 0;
                        Reporte = "El docente " + Nombre + " Tiene por Salario: " + HorasClaseAcumulada * 300;
                    }

                );

        }

        public ObservableCollection<ModelDocente> ListaGuardar { get; set; } = new ObservableCollection<ModelDocente>();

        String nombre;

        public String Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }

        String identidad;

        public String Identidad
        {
            get => identidad;
            set
            {

                identidad = value;
                var args = new PropertyChangedEventArgs(nameof(Identidad));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClase = 0;
        public int HorasClase
        {

            get => horasClase;
            set
            {
                horasClase = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClase));
                PropertyChanged?.Invoke(this, args);

            }
        }

        int horasClaseAcumulada = 0;
        public int HorasClaseAcumulada 
        {
            get => horasClaseAcumulada;
            set 
            {

                horasClaseAcumulada = value;
                var args = new PropertyChangedEventArgs(nameof(HorasClaseAcumulada));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string reporte = "";
        private object listaGuardar;

        public string Reporte
        {
            get => reporte;
            set
            {
                reporte = value;
                var args = new PropertyChangedEventArgs(nameof(Reporte));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command Guardar { get; }

        public Command Buscar { get; }

        public Command DarClase { get; }
        public Command ResetHorasClase { get; }
        public ModelDocente Temporal { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
