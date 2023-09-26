using ModernCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //Создаём матрицу a.
                Matrix a = new Matrix(3, 3);
                //Создаём матрицу b.
                Matrix b = new Matrix(3, 3);
                //Объявляем матрицу c.
                Matrix c;
                //Заполняем матрицу a.
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.col; j++)
                    {
                        a[i, j] = a.col * i + j;
                    }
                }
                //Выводим матрицу a.
                a.Show();
                //Заполняем матрицу b.
                for (int i = 0; i < a.row; i++)
                {
                    for (int j = 0; j < a.col; j++)
                    {
                        b[i, j] = a.col * i + j + 1;
                    }
                }
                //Выводим матрицу a.
                b.Show();
                //Складываем матрицы a и b.
                c = a + b;
                //Выводим матрицу c.
                c.Show();
                Console.WriteLine(c.toString());
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
