using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


class Matrix
{
    private int n; // количество строк
    private int m; // количество столбцов
    private double[,] arr;

    public Matrix(int n, int m)
    {
        this.n = n;
        this.m = m;
        this.arr = new double[n, m];
    }

    public Matrix(int n, int m, double[,] arr) : this(n, m)
    {
        this.arr = arr;
    }

    public void random(int a = -100, int b = 100)
    {
        Random random = new Random();
        for (int i = 0; i < this.n; i++)
        {
            for (int j = 0; j < this.m; j++)
            {
                this.arr[i, j] = random.Next(a, b);
            }
        }
    }

    public Matrix tranport()
    {
        double[,] new_arr = new double[this.m, this.n];

        for (int i = 0; i < this.n; i++)
        {
            for (int j = 0; j < this.m; j++)
            {
                new_arr[j, i] = this.arr[i, j];
            }
        }
        return new Matrix(this.m, this.n, new_arr);
    }

    // 1.1
    public void input()
    {
        this.n = UserInput.intInput(true, "Введите количество строк: ");
        this.m = UserInput.intInput(false, "Введите количество столбцов: ");
        this.arr = new double[n, m];

        for (int i = 0; i < this.m; i++) 
        {
            double[] v = UserInput.ArrInput(n, $"Введите элементы {i} столбца через пробел:");

            for (int j = 0; j < this.n; j++)
            {
                arr[j,i] = v[j];
            }
        }
    }

    // 1.2
    public void randomNumbers()
    {
        Random random = new Random();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (j < m - i - 1)
                {
                    arr[i, j] = random.Next(-12, 4565);
                }
                else
                {
                    arr[i, j] = random.Next(-1024, 1024);
                }
                
            }
        }
    }

    // 1.3
    public void obr()
    {
        arr[this.n - 1, this.m - 1] = 1;

        for (int j = this.m - 2; j > -1; j--)
        {
            arr[this.n -1, j] = arr[this.n - 1, j + 1] + this.m - j - 1;
        }

        for (int i = this.n - 2; i > -1; i--)
        {
            int k = this.n;
            for (int j = this.n-i-1; j < this.m; j++)
            {
                arr[i, j] = arr[i+1, j] + k;
                k--;
            }
        }
    }

    // 2
    public Matrix maxArrSum()
    {
        double[,] m = new double[3, 3];
        if (this.n < 3 || this.m < 3)
        {
            return new Matrix(3, 3);
        }
        double max_sum = Int32.MinValue;

        for (int i = 0; i < this.n-2; i++) 
        { 
            for (int j = 0; j < this.m-2; j++) 
            {
                double temp = arr[i, j] + arr[i, j + 1] + arr[i, j + 2];
                temp += arr[i + 1, j + 1] + arr[i + 1, j + 1] + arr[i + 1, j + 2];
                temp += arr[i + 2, j + 2] + arr[i + 2, j + 2] + arr[i + 2, j+2];

                if (temp > max_sum)
                {
                    max_sum = temp;

                    m[0, 0] = arr[i, j];
                    m[0, 1] = arr[i, j + 1];
                    m[0, 2] = arr[i, j + 2];

                    m[1, 0] = arr[i + 1, j];
                    m[1, 1] = arr[i + 1, j + 1];
                    m[1, 2] = arr[i + 1, j + 2];

                    m[2, 0] = arr[i + 2, j];
                    m[2, 1] = arr[i + 2, j + 1];
                    m[2, 2] = arr[i + 2, j + 2];

                }

            }
        }

        return new Matrix(3, 3, m);
    }

    // 3
    public static Matrix f(Matrix a, Matrix b, Matrix c)
    {
        return a.tranport() + 2 * b + c.tranport();
    }

    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.n, m1.m);
        for (int i = 0;i < m1.n; i++)
        {
            for (int j = 0;j < m1.m; j++)
            {
                m.arr[i, j] = m1.arr[i, j] + m2.arr[i, j];
            }
        }


        return m;
    }

    public static Matrix operator -(Matrix m1, Matrix m2)
    {
        Matrix m = new Matrix(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
        {
            for (int j = 0; j < m1.m; j++)
            {
                m.arr[i, j] = m1.arr[i, j] - m2.arr[i, j];
            }
        }

        return m;
    }

    public static Matrix operator *(double number, Matrix m1)
    {
        Matrix m = new Matrix(m1.n, m1.m);
        for (int i = 0; i < m1.n; i++)
        {
            for (int j = 0; j < m1.m; j++)
            {
                m.arr[i, j] = m1.arr[i, j] * number;
            }
        }


        return m;
    }


    public override string ToString()
    {
        string s = "";

        for (int i = 0;i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                s += String.Format("{0,-7}", arr[i, j]);
            }
            s += "\n";
        }

        return s;
    }
}

