using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7_RunningButton
{
    public partial class RunningButton : Form
    {
        float x, y;
        int cursX, cursY;
        public RunningButton()
        {
            InitializeComponent();
            recountXY();
            cursX = Cursor.Position.X;
            cursY = Cursor.Position.Y;
            this.Resize += new System.EventHandler(this.Form_Resize);
            b.Click += new EventHandler(this.b_Click);
            this.MouseMove += new MouseEventHandler(this.b_Move);
        }
        /// <summary>
        /// Обработчик движения мышки
        /// </summary>
        /// <remarks>
        /// Кнопка убегает только в случае, если расстояние до неё уменьшается
        /// </remarks>
        private void b_Move(object o, MouseEventArgs e)
        {
            Point button = b.Location;
            Point cursor = this.PointToClient(Cursor.Position);
            int newX = button.X + (cursor.X - cursX);
            int newY = button.Y + (cursor.Y - cursY);
            if (newX > this.ClientSize.Width - 110)
            {
                newX = this.ClientSize.Width - 110;
            }
            if (newY > this.ClientSize.Height - 60)
            {
                newY = this.ClientSize.Height - 60;
            }
            if (newX < 10)
            {
                newX = 10;
            }
            if (newY < 10)
            {
                newY = 10;
            }
            int r1 = (newX - cursor.X) * (newX - cursor.X) + (newY - cursor.Y) * (newY - cursor.Y);
            int r2 = (button.X - cursor.X) * (button.X - cursor.X) + (button.Y - cursor.Y) * (button.Y - cursor.Y);
            if ( r1 > r2 )
            {
                b.Location = new Point(newX, newY);
                recountXY();
            }
            cursX = cursor.X;
            cursY = cursor.Y;
        }
        /// <summary>
        /// Изменяет положение кнопки при изменении размеров формы
        /// </summary>
        private void Form_Resize(object o, EventArgs e)
        {
            int newX =(int) (this.ClientSize.Width * x - 50);
            int newY = (int)(this.ClientSize.Height * y - 25);
            if (newX < 10) newX = 10;
            if (newX > this.ClientSize.Width - 110) newX = this.ClientSize.Height - 110;
            if (newY < 10) newY = 10;
            if (newY > this.ClientSize.Height - 60) newY = this.ClientSize.Height - 60;
            this.b.Location = new Point(newX, newY);
        }
        /// <summary>
        /// Вывод сообщения о завершении игры
        /// </summary>
        private void b_Click(object o, EventArgs e)
        {
            MessageBox.Show("Поздравляем! Вы смогли нажать на кнопку!", "Победа");
            this.b.Location = new Point((this.ClientSize.Width / 2 - 50), (this.ClientSize.Height / 2 - 25));
            recountXY();
        }
        /// <summary>
        /// Пересчёт соотношения позиции кнопки относительно ширины и высоты формы
        /// </summary>
        private void recountXY()
        {
            x = (b.Location.X + 50) / (float)this.ClientSize.Width;
            y = (b.Location.Y + 25) / (float)this.ClientSize.Height;
        }

    }
}
