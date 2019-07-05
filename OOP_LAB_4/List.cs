using System;
namespace OOP_LAB_4
{
    public class List
    {
        #region Поля списка
        protected Element currentElement;
        protected Element[] elements;
        int length; //Текущая длина списка
        #endregion 

        #region Конструктор списка
        public List(int size)
        {
            elements = new Element[size];
            length = 0;
        }
        #endregion

        #region Методы работы со списком
        public void AddElement(int value) //Добавление нового элемента в конец и присвоение ему значения
        {
            elements[length] = new Element(value);
            length++;
            checkElements();
        }
        public int GetNextElement() //Получение значения следующего элемента
        {
            if (currentElement.NextElement!= null)
            currentElement = currentElement.NextElement;
            return currentElement.Value;
            
        }
        void checkElements() //Проверяет ссылки следующего элемента в массиве элементов на правильный адрес
        {
            for (int i = 0; i < length; i++)
            {
                if (elements[i].NextElement==null & i<length-1)
                {
                    elements[i].NextElement = elements[i + 1];
                }
            }
        }
        public void PrintAll()
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write(elements[i].Value+" ");
            }
        }
        #endregion

        #region Класс элемента списка
        protected class Element //Элемент списка, содержащий поле данных и следующий элемент
        {
           public int Value { get; set; }

            public ref Element NextElement
            {
                get
                {
                    return ref NextElement;
                }
            }


            public Element(int value,ref Element nextElement)
            {
                Value = value;
                NextElement = nextElement;
            }
            public Element(int value)
            {
                Value = value;
            }


        }
        #endregion
    }
}
