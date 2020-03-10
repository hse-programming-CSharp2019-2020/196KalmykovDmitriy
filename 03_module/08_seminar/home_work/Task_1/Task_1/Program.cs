using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    // А)
    //      1) У делегата Action все типизирующие параметры снабжены модификатором in.

    //      2) У делегата Func все типизирующие параметры, кроме TResult, снабжены модификатором in,
    //          Tresult снабжён модификатором out.

    //      3) У делагата Predicate типизирующий параметр снабжён модификатором in.

    //      4) У интерфейса IComparable типизирующий параметр снабжён модификатором in.

    //      5) У интерфейса IComparer типизирующий параметр снабжён модификатором in.

    //      Разинца заключается в следующем:

    //          1) Модификатор out позволяет
    //              использовать тип с большей глубиной наследования, чем задано изначально.

    //          2) Модификатор in позволяет
    //              использовать более универсальный тип(с меньшей глубиной наследования),
    //              чем заданный изначально.


    #region Action, Func, Predicate.

    internal class Animal { }

    internal class Cat : Animal { }
    internal class Dog : Animal { }

    internal class MiniCat : Cat { }

    #endregion

    #region IComaprable.

    internal class Person<T> : IComparable<Client<T>>
    {
        internal T Id { get; set; }
        internal int Sum { get; set; }

        internal Person(int sum) =>
            Sum = sum;

        public int CompareTo(Client<T> other) =>
            Sum.CompareTo(other.Sum);
    }

    internal class Client<T> : Person<T>
    {
        internal Client(int sum) : base(sum) { }
    }

    #endregion

    #region IComparer.

    internal class Transport<T> : IComparer<Car<T>>
    {
        internal T Id { get; set; }
        internal int Number { get; set; }

        internal Transport(int number) =>
            Number = number;

        public int Compare(Car<T> x, Car<T> y) =>
            x.Number.CompareTo(y.Number);
    }

    internal class Car<T> : Transport<T>
    {
        internal Car(int number) : base(number) { }
    }

    #endregion

    interface IFruit<T>
    {
    }

    interface IPerson<in T>
    {
    }

    interface ICar<out T>
    {

    }

    class A<T>
    {

    }

    class B<T> : A<T>, IFruit<T>, ICar<T>, IPerson<T>
    {

    }

    class C<T> : B<T>
    {

    }


    class A1
    {
    }

    class A2 : A1
    {

    }

    class A3 : A2
    {

    }

    internal delegate T Del1<T>(T item);
    internal delegate int Del2<in T>(T item);
    internal delegate T Del3<out T>(int item);

    internal class Program
    {
        private static void TestAction(Animal animal) =>
            Console.WriteLine("This is animal!");

        private static MiniCat TestFunc(Cat cat) =>
            new MiniCat();

        private static bool TestPredicate(Animal animal) =>
            true;


        private static int Del2<T>(T item) => 3;

        private static T Del1<T>(T item) => default;

        private static T Del3<T>(int item) => default;

        private static void Main()
        {
            #region Б.

            // Демонстрация контрвариантности в делегате Action.
            Action<Cat> action = TestAction;

            // Демонстрация контрвариантности и ковариантности в делегате Func.
            Func<MiniCat, Animal> func = TestFunc;

            // Демонстрация контрвариантности в делегате Predicate.
            Predicate<Dog> predicate = TestPredicate;

            // Демонстрация контрвариантности в интерфейсе IComparable.
            IComparable<Client<int>> inter = new Person<int>(123);

            // Демонстрация контрвариантности в интерфейсе IComparer.
            IComparer<Car<int>> car = new Transport<int>(12);


            #endregion

            #region В.

            // Ошибка, потому что интерфейс IFruit не является ковариантным.
            IFruit<B<int>> ifruit1 = new B<C<int>>();

            // Ошибка, потому что интерфейс IFruit не является контрвариантным.
            IFruit<B<int>> ifruit2 = new B<A<int>>();

            // Нет ошибки, потому что интерфейс ICar является ковариантным.
            ICar<B<int>> icar1 = new B<C<int>>();

            // Ошибка, потому что интерфейс ICar не является контрвариантым.
            ICar<B<int>> icar2 = new B<A<int>>();

            // Ошибка, потому что интерфейс IPerson не является ковариантным.
            IPerson<B<int>> Iperson1 = new B<C<int>>();

            // Нет ошибки, потому что интерфейс IPerson является контрвариантым.
            IPerson<B<int>> Iperson2 = new B<A<int>>();

            #endregion

            #region Г.

            // Две ошибки, потому что делегат Del1 не является 
            // ни ковариантным, ни контрвариантынм.
            Del1<A2> del1 = Del1<A1>;
            Del1<A2> del2 = Del1<A3>;

            // Нет ошибки, потому что делегат Del2 является контрвариантным.
            Del2<A2> del3 = Del2<A1>;

            // Ошибка, потому что делегат Del2 не является контрвариантным.
            Del2<A2> del4 = Del2<A3>;

            // Ошибка, потому что делегат Del3 не является контрвариантным.
            Del3<A2> del6 = Del3<A1>;

            // Нет ошибки, потому что делегат Del3 является ковариантным.
            Del3<A2> del5 = Del3<A3>;

            #endregion

            #region Д.

            // 1) Ковариантность и контрвариантность
            //     обеспечивают большую гибкость в назначении и использовании универсальных типов.

            // 2) Поддержка ковариации и контрвариантности для групп методов позволяет
            //     сопоставить сигнатуры методов с типами делегатов. За счет этого вы можете
            //     назначать делегатам не только методы с совпадающими сигнатурами, но и методы,
            //     которые возвращают более производные типы (ковариация) или принимают параметры
            //     с менее производными типами (контрвариантность), чем задает тип делегата.

            // 3) Вся суть вариантности состоит в использовании в производных типах
            //     преимуществ наследования. Известно, что если два типа связаны
            //     отношением "предок-потомок", то объект потомка может храниться в переменной
            //     типа предка. На практике это значит, что мы можем использовать для
            //     каких-либо операций объекты потомка вместо объектов предка.
            //     Тем самым, можно писать более гибкий и короткий код
            //     для выполнения действий поддерживаемых разными потомками с общим предком.

            #endregion
        }
    }
}
