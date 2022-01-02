using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BankLibrary
{
    public class User<T>
        where T : Account
    {
        public static event Action<string> UserEvents;
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
            UserEvents += e => Debug.WriteLine(e);
            Numfers = new ObservableCollection<T>();
            UserEvents($"Пользователь {UserName} был создан");
            //Account.CreateAccount += 
        }
        /// <summary>
        /// Добовление в масив
        /// </summary>
        /// <param name="elem"></param>
        public void Add(T elem)
        {
            Numfers.Add(elem);
            //Account.CreateAccount += e => UserEvents($"Пользователь {UserName} {e}");
            UserEvents($"Пользователь {UserName} создал {elem.Name} с номером {elem.AccountNumf} ссумой {elem.Money} и ставкой {elem.Bet}");
        }
        /// <summary>
        /// удоление элемента из списка
        /// </summary>
        /// <param name="elem"></param>
        public void Remove(T elem)
        {
            Numfers.Remove(elem);
            UserEvents($"Пользователь {UserName} удалил {elem.Name} с номером {elem.AccountNumf}");
        }
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
                    UserEvents($"Пользователь {UserName} перевел на {elem.Name} с номером {elem.AccountNumf} сумму {tranzakt}");
                    break;
                case Calculetion.Minus:
                    elem.Money -= tranzakt;
                    UserEvents($"Пользователь {UserName} перевел c {elem.Name} с номером {elem.AccountNumf} сумму {tranzakt}");
                    break;
                default:
                    break;
            }
        }
        public void RemuveAccount() => UserEvents($"Пользовотель {UserName} удалил свой акаунт");
    }
   public enum Calculetion
    {
        Plus,
        Minus
    }
}
