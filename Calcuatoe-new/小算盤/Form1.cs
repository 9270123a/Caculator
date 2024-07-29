using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 小算盤
{
    public partial class Form1 : Form
    {

        public string CurrentOperation;
        public string number1;
        public string number2;
        bool newinput = true;
        Controller controller = new Controller();
        public Form1()
        {
            InitializeComponent();
            EventHandlers.ResultEvent += EventHandlers_ResultEvent;


    }

    private void EventHandlers_ResultEvent(object sender, double e)
        {
            ResultTxt.Text = "";
            ResultTxt.Text = e.ToString();
            number1 = e.ToString();
            number2 = "";
            newinput = true;
        }

        private void NumberClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(CurrentOperation))
            {
                if (newinput)
                {
                    ResultTxt.Text = "";
                    newinput = false;
                }
                number2 += button.Text;
                ResultTxt.Text += button.Text;
            }
            else
            {
                number1 += button.Text;
                ResultTxt.Text += button.Text;
            }
        }
    
        private void OperClick(object sender, EventArgs e)
        {

            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(number2))
            {
                Controller controller = new Controller();
                controller.Calculator(number1, number2, CurrentOperation);
            }
            CurrentOperation = button.Text;

        }

        private void EqualsClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(number2))
            {
                Controller controller = new Controller();
                controller.Calculator(number1, number2, CurrentOperation);
            }

        }



        private void DELETE_Click(object sender, EventArgs e)
        {
            
        }
        
        private void ClearDisplay()
        {
            ResultTxt.Text = "";
        }



    }
}
