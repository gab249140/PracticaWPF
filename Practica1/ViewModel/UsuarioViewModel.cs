using Practica1.DataAccess;
using Practica1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.ViewModel
{
    public class UsuarioViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Usuario> usuario;
        public event PropertyChangedEventHandler PropertyChanged;
        private Usuario selectedUsuario;
        public UsuarioViewModel()
        {
            LoadListUsers();
        }

        public Usuario SelectedUsuario
        {
            get { return selectedUsuario; }
            set
            {
                selectedUsuario = value;
                OnPropertyChanged("SelectedUsuario");
            }
        }

        public ObservableCollection<Usuario> Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged("Usuario");
            }
        }

        private void LoadListUsers()
        {
            MyDataAcces dataacces = new MyDataAcces();
            Usuario = dataacces.GetListUsuario();
        }

        private void SaveUser(string Nombre,string ApellidoPaterno, string ApellidoMaterno, int Edad)
        {
            Usuario user = new Usuario() { Nombre = Nombre, ApellidoPaterno = ApellidoPaterno, ApellidoMaterno = ApellidoMaterno, Edad = Edad };
            MyDataAcces dataacces = new MyDataAcces();
            bool response = dataacces.SaveUsuario(user);
            LoadListUsers();
        }

        private void UdateUser(int IdUsuario, string Nombre, string ApellidoPaterno, string ApellidoMaterno, int Edad)
        {
            Usuario user = new Usuario() {IdUsuario = IdUsuario, Nombre = Nombre, ApellidoPaterno = ApellidoPaterno, ApellidoMaterno = ApellidoMaterno, Edad = Edad };
            MyDataAcces dataacces = new MyDataAcces();
            bool response = dataacces.UpdateUsuario(user);
            LoadListUsers();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
