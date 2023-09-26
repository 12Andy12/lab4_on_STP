using ModernCoding;
using System;
using System.Runtime.CompilerServices;

namespace ModernCoding
{
    public class MyException : Exception
    {
        public MyException(string s) : base(s)
        { }
    }
    public class Matrix
    {
        int[,] m;
        //Свойство для работы с числом строк.
        public int row { get; }
        //Свойство для работы с числом столбцов.
        public int col { get; }
        //Конструктор.
        public Matrix(int i, int j)
        {
            if (i <= 0)
                throw new MyException($"недопустимое значение строки = {i}");
            if (j <= 0)
                throw new MyException($"недопустимое значение столбца = {j}");
            row = i;
            col = j;
            m = new int[i, j];
        }


        //Индексатор для доступа к значениям компонентов матрицы.
        public int this[int i, int j]
        {
            get
            {
                if (i < 0 | i > row - 1)
                    throw new MyException($"неверное значение i = {i}");


                if (j < 0 | j > col - 1)
                    throw new MyException($"неверное значение j = {j}");
                return m[i, j];
            }
            set
            {
                if (i < 0 | i > row - 1)
                    throw new MyException($"неверное значение i = {i}");
                if (j < 0 | j > col - 1)
                    throw new MyException($"неверное значение j = {0}");
                m[i, j] = value;
            }
        }

        //Сложение матриц.
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a.row != b.row || a.col!=b.col)
                throw new MyException($"не одинаковый размер матриц");

            Matrix res = new Matrix(a.row, a.col);

            for (int i = 0; i < a.row; i++)
                for (int j = 0; j < a.col; j++)
                    res[i, j] = a.m[i, j] + b.m[i, j];
                
            return res;
        }

        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a.row != b.row || a.col != b.col)
                throw new MyException($"не одинаковый размер матриц");

            Matrix res = new Matrix(a.row, a.col);

            for (int i = 0; i < a.row; i++)
                for (int j = 0; j < a.col; j++)
                    res[i, j] = a.m[i, j] - b.m[i, j];

            return res;
        }

        public static Matrix operator*(Matrix a, Matrix b)
        {
            if (a.row != b.col || a.col != b.row)
                throw new MyException($"не согласованный размер матриц");
            Matrix res = new Matrix(a.row, a.col);

            for (int i = 0; i < a.row; i++)
                for (int j = 0; j < b.col; j++)
                    for (int k = 0; k < b.row; k++)
                        res[i, j] += a[i, k] * b[k, j];

            return res;
        }

        public Matrix transp()
        {

            Matrix res = new Matrix(this.col, this.row);

            for (int i = 0; i < this.col ; i++)
            {
                for (int j = 0; j < this.row; j++)
                {
                    res[i, j] = this.m[j, i];
                }
            }

            return res;
        }

        public int min()
        {
            int m = this.m[0,0];

            for (int i = 0; i < this.row; i++)
                for (int j = 0; j < this.col; j++)
                    if (this.m[i, j] < m)
                        m = this.m[i, j];

            return m;
        }

        public string toString()
        {
            string res = "";
            for (int i = 0; i < this.row; i++)
            {
                for (int j = 0; j < this.col; j++)
                {
                    res += this.m[i, j].ToString();
                    if (j != this.col - 1)
                        res += " ";
                }

                if (i != this.row - 1)
                    res += ", ";
            }

            return res;
        }

        public static bool operator ==(Matrix a, Matrix b)
        {

            for (int i = 0; i < a.row; i++)
                for (int j = 0; j < a.col; j++)
                    if (a[i, j] != b[i, j])
                        return false;

            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            return !(a == b);
        }

        //Вывод значений компонентов на консоль.
        public void Show()
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    Console.Write("\t" + this[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public override bool Equals(object obj)
        {
            return (this as Matrix) == (obj as Matrix);
        }


    }
}