using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Task_1
{
    /*
       1)   СЕРИАЛИЗАЦИЯ - процесс преобразования структуры данных
                в последовательность байтов (или XML-узлов).

            ДЕСЕРИАЛИЗАЦИЯ - восстановление структуры данных
                из последовательности байтов (или XML-узлов).


       2)   Атрибут [Serialize] применяется к типу для того,
                чтобы указать,чято экземпляры этого типа разрешено сериализовывать.

            Атрибут [NonSerialized] показывает, что
                поле сериализуемого класса не должно быть сериализовано.


       3)   Да, при двоичной сериализации сериализуются даже закрытые члены класса. (Пример ниже)
              При Soap и Json сериализации приватные поля также сериализуются.
              При Xml сериализации приватные поля не сериализуются.
             
    
       4)   Класс А и класс B должны быть помечены атрибутами [Serialize],
                в противном случае возникнет исключение.


       5)   Сериализация контрактов данных:

                - Общее сохранение
                - Веб-службы
                - Json
            
            Сериализация XML:

                - Формат Xml с полный доступом

            Сериализация времени выполнения:

                - Удалённое взаимодействие с .NET


      6)	С помощью интерфейса ISerialize можно позволить объекту управлять
              его собственной сериализацией и десериализацией.


      7)

      8)    BinaryFormatter:

                      а) Serialize:

                          - ArgumentNullException. Значение параметра serializationStream равно null.

                          - SerializationException. Во время сериализации произошла ошибка, например,
                              если объект в параметре graph не отмечен как сериализуемый.

                          - SecurityException. У вызывающего объекта отсутствует необходимое разрешение.
        

                      б) Deserialize:
        
                            - ArgumentNullException. Значение параметра serializationStream равно null.

                            - SerializationException. serializationStream поддерживает поиск, 
                                но его длина равна 0, или целевым типом является тип Decimal,
                                однако его значение находится за пределами диапазона типа Decimal.

                            - SecurityException. У вызывающего объекта отсутствует необходимое разрешение.

              SoapFormatter:

                        а) Serialize:

                            -  ArgumentNullException. serializationStream — null.
                        

                        б) Deserialize:
                            - ArgumentNullException. Свойство serializationStream имеет значение null.

                            - SerializationException. Поток serializationStream поддерживает поиск 
                                и его длина равна 0.


      9)      Классы BinaryFormatter и SoapFormatter помечены модификатором sealed,
                  а значит, наследоваться от них нельзя.


      10)     Для корректной работы Xml-сериализации и десериализация нужен беспараметрический конструктор. 
                  А также модификатор доступа сериализуемого класса должен быть public.

      11)

      12)     [DataMember]:
                При применении к элементу типа указывает, 
                    что этот элемент является частью контракта данных и сериализуется DataContractSerializer.
            
              [DataContract]:
                Указывает, что тип определяет или реализует контракт данных
                    и может быть сериализован сериализатором, таким как DataContractSerializer.

      13)
    */

    [Serializable]
    public class A
    {
        internal A() { }
        internal A(int newA)
        {
            a = newA;
        }

        private int a;

        public override string ToString()
        {
            return a.ToString();
        }
    }

    internal class Program
    {
        private static void Main()
        {
            #region Task 3

            using (var fs = new FileStream("test.txt", FileMode.Create))
            {
                //var formatter = new SoapFormatter();
                //var formatter = new DataContractJsonSerializer(typeof(A));
                //var formatter = new XmlSerializer(typeof(A));
                var formatter = new BinaryFormatter();

                //formatter.Serialize(fs, new A(5));
                formatter.Serialize(fs, new A(5));
            }

            using (var fs = new FileStream("test.txt", FileMode.Open))
            {
                //var formatter = new SoapFormatter();
                //var formatter = new DataContractJsonSerializer(typeof(A));
                //var formatter = new XmlSerializer(typeof(A));
                var formatter = new BinaryFormatter();

                var a = (A)formatter.Deserialize(fs);

                // При двоичной десериализации выводит 5 (т.е. было сериализовано приватное поле).
                // При Soap десериализации выводит 5 (т.е. было сериализовано приватное поле).
                // При Json десериализации выводит 5 (т.е. было сериализовано приватное поле).
                // При Xml десериализации выводит 0 (т.е. не было сериализовано приватное поле). 
                Console.WriteLine(a);
            }

            #endregion
        }
    }
}
