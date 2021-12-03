using System;
using System.Collections.ObjectModel;
namespace BankProgect
{
    class User<T>
        where T : Account
    {
        string _userName;
        /// <summary>
        /// имя пользовотеля
        /// </summary>
        public string UserName { get => _userName; }
        /// <summary>
        /// колекция счетов
        /// </summary>
        public ObservableCollection<T> Numfers { get; set; }
        public override string ToString() => String.Format("{0}", UserName);
        public User(string name)
        {
            _userName = name;
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
        /// <summary>
        /// перевод между счетами
        /// </summary>
        /// <param name="elem">счет</param>
        /// <param name="calculetion">опирация</param>
        /// <param name="tranzakt">сумма</param>
        public void Translation(T elem, Calculetion calculetion, float tranzakt)
        {
            switch (calculetion)
            {
                case Calculetion.Plus:
                    elem.Money += tranzakt;
                    break;
                case Calculetion.Minus:
                    elem.Money -= tranzakt;
                    break;
                default:
                    break;
            }
        }
    }
    enum Calculetion
    {
        Plus,
        Minus
    }
}
