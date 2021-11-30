using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankProgect
{
    class User<T>
        where T : Account
    {
        string _UserName;
        public string UserName { get => _UserName; }
        public ObservableCollection<T> Numfers { get; set; }
        public User(string name)
        {
            _UserName = name;
            Numfers = new ObservableCollection<T>();
        }
        /// <summary>
        /// Добовление в масив
        /// </summary>
        /// <param name="elem"></param>
        public void Add(T elem) => Numfers.Add(elem);
        /// <summary>
        /// удоление элемента из списка
        /// </summary>
        /// <param name="elem"></param>
        public void Remove(T elem) => Numfers.Remove(elem);
        public void Translation(T elem, Calculetion calculetion, float tranzakt)
        {
            switch (calculetion)
            {
                case Calculetion.Plus:                    
                    elem.Kech += tranzakt;
                    break;
                case Calculetion.Minus:
                    elem.Kech -= tranzakt;
                    break;
                default:
                    break;
            }
        }
        public override string ToString() => String.Format("{0}", UserName);
    }
    enum Calculetion
    {
        Plus,
        Minus
    }
}
