///////////////////////////////////////////////////////////////////
///					ЛАБОРАТОРНАЯ	РАБОТА						///
///		  ЧИСЛЕННОЕ РЕШЕНИЕ НАЧАЛЬНО-КРАЕВОЙ ЗАДАЧИ ДЛЯ			///
///	ИНТЕГРО-ДИФФЕРЕНЦИАЛЬНОГО УРАВНЕНИЯ В ЧАСТНЫХ ПРОИЗВОДНЫХ	///
///_____________________________________________________________///
///					УРАВНЕНИЕ ТЕПЛОПРОВОДНОСТИ					///
///			   y'_t(x, t) = y''_xx(x, t) + f(x, t)				///
///			      ГРАНИЧНЫЕ УСЛОВИЯ ВТОРОГО РОДА				///
///				   	  y'_x(0, t)=y'_x(L, t)						///
///						НАЧАЛЬНЫЕ УСЛОВИЯ						///
///						 y(x, 0) = fi(x)						///
///////////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace Laboratory_work2
{
	public partial class Form1 : Form
	{
		private readonly CultureInfo culture = new("ru-Ru");
        // координатная сетка

        private readonly int xMin = -1;
        private readonly int xMax = 20;
        private double yMin = -20;
        private double yMax = 20;
		private int dx;
        private double dy;
        private int x0, y0;
        private readonly int arrowSize = 7;


        int I;											// количество шагов по х и времени
		double L = 7, T = 1, tau = 0.01, h = 0.2;		// длина стержня, время воздействия, шаг по времени, шаг вдоль стержня (стандартные значения)
		double[] fi = { 0, 0, 0 }, 
			bx = { -1.0339, -0.0036, -0.0036 };			// коэффициенты функций
		PointF[] funY, funY_0;

		public Form1()
		{
			InitializeComponent();

			Lenght.Text = L.ToString();
			Time.Text = T.ToString();
			Taustep.Text = tau.ToString();
			Hstep.Text = h.ToString();

            dx = pictureBox1.Width / (xMax - xMin);
            dy = pictureBox1.Height / (yMax - yMin);
            x0 = -dx * xMin;
            y0 = (int)(dy * yMax);

            fi[0] = 1 / L;
			for (int i = 0; i < 3; i++)
			{
                dataGridView1.Rows.Add(fi[i], bx[i]);
			}
		}

		private double Fi(double x)
		{
			return (1 / L + fi[1] * Math.Cos(Math.PI * x / L) + fi[2] * Math.Cos(2 * Math.PI * x / L));
		}

		private double B(double x)
		{
			return (bx[0] + bx[1] * Math.Cos(Math.PI * x / L) + bx[2] * Math.Cos(2 * Math.PI * x / L));
		}

		private static double[] mGaussian(double[,] a, double[] b)
		{
			int size = b.Length;
			double[,] _a = new double[size, size];
			double[] c = new double[size];

			for (int i = 0; i < size; i++)
			{
				_a[i, i] = 1;
			}

			for (int i = 0; i < size; i++)
			{
				double ap = a[i, i];    // 
				for (int j = 0; j < size; j++)
				{
					if (ap != 0 && ap != 1)
					{
						_a[i, j] /= ap;
						a[i, j] /= ap;
					}
				}
				double[] ci = new double[size];
				for (int j = 0; j < size; j++)
				{
					ci[j] = a[j, i];
					if (j != i)
					{
						for (int k = 0; k < size; k++)
						{
							_a[j, k] -= _a[i, k] * ci[j];
							a[j, k] -= a[i, k] * ci[j];
						}
					}
				}
			}
			for (int i = 0; i < size; i++)
			{
				for (int j = 0; j < size; j++)
				{
					c[i] += _a[i, j] * b[j];
				}
			}
			return c;
		}

		private double Integral(double[] Y)
		{
			double Int = Y[0] * B(0) + Y[I - 1] * B(L);
			for (int i = 1; i < I - 1; i += 2)
			{
				Int += 4 * Y[i] * B(i * h) + 2 * Y[i + 1] * B(i * h + h);
			}
			return (Int * h / 3);
		}

		private double[] diffWarm(double[] Y)
		{
			I = Y.Length;

			double[,] A = new double[I, I];     // матрица коэффициентов
			double[] y;// = new double[I];         // значения функции для предыдущего слоя
			double[] f = new double[I];         // значения правой части уравнения

			// граничные условия
			A[0, 0] = A[I - 1, I - 1] = 3;
			A[0, 1] = A[I - 1, I - 2] = -4;
			A[0, 2] = A[I - 1, I - 3] = 1;
			for (int i = 1; i < I - 1; i++)
			{
				A[i, i - 1] = A[i, i + 1] = tau / (h * h);
				A[i, i] = -(1 + 2 * tau / (h * h));
			}
			// основной расчёт
			double j = 1;
			while(true)
			{
				// расчет правой части для начальных условий
				f[0] = f[I - 1] = 0;
				for (int i = 1; i < I - 1; i++)
				{
					f[i] = -Y[i] * (1 + B(i * h) - Integral(Y));
				}
				y = mGaussian(A, f);
				j += tau;
				if(j >= T) break;
				y.CopyTo(Y, 0);
			}
			///MessageBox.Show(String.Join(", ", y));
			return y;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (Lenght.Text != L.ToString() && Lenght.Text != "") L = Convert.ToDouble(Lenght.Text, culture);
			if (Time.Text != T.ToString() && Time.Text != "") T = Convert.ToDouble(Time.Text, culture);
			if (Taustep.Text != tau.ToString() && Taustep.Text != "") tau = Convert.ToDouble(Taustep.Text, culture);
			if (Hstep.Text != h.ToString() && Hstep.Text != "") h = Convert.ToDouble(Hstep.Text, culture);

			for (int i = 0; i < 3; i++)
			{
				if (!dataGridView1.Rows.Equals(fi[i])) fi[i] = Convert.ToDouble(dataGridView1[0, i].Value.ToString(), culture);
				if (!dataGridView1.Rows.Equals(bx[i])) bx[i] = Convert.ToDouble(dataGridView1[1, i].Value.ToString(), culture);
			}
			///MessageBox.Show(String.Join(", ", fi) + "\n" + String.Join(", ", bx));

			//if ((tau / (h * h)) >= 0.25)
			//{
			//	MessageBox.Show("Нарушение устойчивости!\n" +
			//	"Измените значение h на больше чем: " + 2 * Math.Pow(tau, 0.5) +
			//		"\nили tau на меньше чем: " + 0.25 * h * h);
			//         }
			//         else
			//         {
			///MessageBox.Show(L + ", " + T + ", " + tau + ", " + h);

			int I = (int)(L / h);
			double[] y; //= new double[I];
			double[] y_0 = new double[I];

			funY = new PointF[I];
			funY_0 = new PointF[I];

			for (int i = 0; i < I; i++)
			{
				y_0[i] = Fi(i * h);
			}
			y = diffWarm(y_0);

			yMax = y.Max();
			yMin = y.Min();
            dy = 0.5 * pictureBox1.Height / (yMax - yMin);
			y0 = (int)(yMax * dy + pictureBox1.Height / 3);

			///MessageBox.Show("" + dy + ", " + y0);
			///MessageBox.Show("" + yMax + ", " + yMin);
			for (int i = 0; i < I; i++)
			{
				funY[i].X = funY_0[i].X = (float)(x0 + (xMax / L) * i * h * dx);
				funY[i].Y = (float)(y0 - y[i] * dy);
				funY_0[i].Y = (float)(y0 - y_0[i] * dy);
			}
			pictureBox1.Refresh();
		}

		private void pictureBox1_Resize(object sender, EventArgs e)
		{
			pictureBox1.Refresh();
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			double ystp = (yMax - yMin) / (2 * 10);
            // сетка вертикальная
            for (double x = xMin; x <= xMax; x++)
            {
                e.Graphics.DrawLine(Pens.LightGray, (int)(x0 + x * dx), 0, (int)(x0 + x * dx), pictureBox1.Height);
            }
            // сетка горизонтальная
            for (double y = yMin; y <= yMax; y+=ystp)
            {
                e.Graphics.DrawLine(Pens.LightGray, 0, (int)(y0 - y * dy), pictureBox1.Width, (int)(y0 - y * dy));
            }

            // ось абсцисс
            e.Graphics.DrawLine(Pens.Black, 0, y0, pictureBox1.Width, y0);
            // ось ординат
            e.Graphics.DrawLine(Pens.Black, x0, 0, x0, pictureBox1.Height);

            // стрелки
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(pictureBox1.Width, y0), new PointF(pictureBox1.Width - arrowSize, y0 - arrowSize), new PointF(pictureBox1.Width - arrowSize, y0 + arrowSize) });
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(x0, 0), new PointF(x0 - arrowSize, arrowSize), new PointF(x0 + arrowSize, arrowSize) });

            // подписи
            Font f = new("Arial", 12);
            e.Graphics.DrawString("Y", f, Brushes.Black, x0 + 10, 0);
            e.Graphics.DrawString("X", f, Brushes.Black, pictureBox1.Width - 25, y0 + 10);

            if (null != funY)
            {
                Pen diff = new(Brushes.Red, 2);
                Pen diff_0 = new(Brushes.Blue, 2);
                e.Graphics.DrawCurve(diff_0, funY_0);
                e.Graphics.DrawCurve(diff, funY);
                diff.Dispose();
                diff_0.Dispose();
            }

        }
	}
}
