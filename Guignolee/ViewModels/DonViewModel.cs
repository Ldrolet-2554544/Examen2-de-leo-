using Guignolee.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Guignolee.ViewModels
{
    public class DonViewModel : ValidableViewModel
    {
        private readonly Don _don;

        public DonViewModel(Don don)
        {
            _don = don;
            _errors.Add("Nom", new ObservableCollection<ValidationResult>());
        }

        public int Id => _don.Id;


        [Required(ErrorMessage = "Le nom du donateur est requis")]
        [MinLength(2, ErrorMessage = "Le nom du donateur est trop petit")]
        [MaxLength(50, ErrorMessage = "Le titre de la tâche doit comprendre moins de 50 caractères.")]
        [RegularExpression(@".{2,50}", ErrorMessage ="Le donnateur n'est pas valide")]
        public string Donateur
        {
            get { return _don.Donateur; }
            set
            {
                // TODO: appliquer la validation sinon rien ne se passe
                //          && Validate(value) 
                if (_don.Donateur != value)
                {
                    _don.Donateur = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Required(ErrorMessage = "Le nom du contenu est requis")]
        [MinLength(2, ErrorMessage = "Le contenu est trop petit")]
        [MaxLength(50, ErrorMessage = "Le contenu doit comprendre moins de 50 caractères.")]
        [RegularExpression(@".{2,50}", ErrorMessage = "Le contenu n'est pas valide")]
        public string Contenu
        {
            get { return _don.Contenu; }
            set
            {
                if (_don.Contenu != value )
                {
                    _don.Contenu = value;
                    RaisePropertyChanged();
                }
            }
        }
        [Required(ErrorMessage = "La quantité est requise")]
        [RegularExpression(@"\d{1,100}", ErrorMessage = "La quantité n'est pas dans l'intervalle 1 à 100")]
        public int Quantite
        {
            get { return _don.Quantite; }
            set
            {
                if (Quantite != value)
                {
                    _don.Quantite = value;
                    RaisePropertyChanged();    

                }
            }
        }
        public bool EstPerissable
        {
            get { return _don.EstPerissable; }
            set
            {
                if (_don.EstPerissable != value)
                {
                    _don.EstPerissable = value;
                    RaisePropertyChanged();
                }
            }
        }

        public bool EstRemis
        {
            get { return _don.EstRemis; }
            set
            {
                if (_don.EstRemis != value)
                {
                    _don.EstRemis = value;
                    RaisePropertyChanged();
                }
            }
        }

        public DateTime DateReception => _don.DateReception;

        public string Details
        {
            get
            {
                return $"{_don.Quantite} article(s) - {_don.Donateur} - reçu le {_don.DateReception:dd-MM-yyyy}";
            }
        }
    }
}
