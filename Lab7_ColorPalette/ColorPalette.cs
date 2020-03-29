using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab7_ColorPalette
{
    public partial class ColorPalette : Form
    {
        private byte byteR = 128;
        private byte byteG = 128;
        private byte byteB = 128;
        private string color;
        public ColorPalette()
        {
            InitializeComponent();
            this.canvas.MouseHover += new EventHandler(this.canvas_Hover);
            r.Scroll += new EventHandler(r_Scroll);
            g.Scroll += new EventHandler(g_Scroll);
            b.Scroll += new EventHandler(b_Scroll);
            color = "#" + canvas.BackColor.Name.ToUpper().Substring(2);
        }
        /// <summary>
        /// Вывод подсказыки с цветом при наведении на холст
        /// </summary>
        private void canvas_Hover(object o, EventArgs e)
        {
            ToolTip t = new ToolTip();
            t.SetToolTip(canvas, color);
        }
        /// <summary>
        /// Обработчик изменения красного ползунка
        /// </summary>
        private void r_Scroll(object o, EventArgs e)
        {
            byteR = (byte)r.Value;
            changeColor();
        }
        /// <summary>
        /// Обработчик изменения зелёного ползунка
        /// </summary>
        private void g_Scroll(object o, EventArgs e)
        {
            byteG = (byte)g.Value;
            changeColor();
        }
        /// <summary>
        /// Обработчик изменения синего ползунка
        /// </summary>
        private void b_Scroll(object o, EventArgs e)
        {
            byteB = (byte)b.Value;
            changeColor();
        }
        /// <summary>
        /// Изменениe цвета холста
        /// </summary>
        private void changeColor()
        {
            this.canvas.BackColor = Color.FromArgb(255, byteR, byteG, byteB);
            color = "#" + canvas.BackColor.Name.ToUpper().Substring(2);
            Clipboard.SetText(color);
        }
    }
}
