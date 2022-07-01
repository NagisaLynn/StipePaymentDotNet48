using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StipePaymentDotNet48
{
    public partial class frm_Main : Form
    {


        public frm_Main()
        {
            InitializeComponent();
        }

        private void button_Payment_by_Card_Click(object sender, EventArgs e)
        {
            StripePayment.Payment_by_Card();
        }

        private void button_Create_Customer_Click(object sender, EventArgs e)
        {
            StripePayment.CustomerCreateOptions();
        }

        private void button_Payment_by_Customer_Click(object sender, EventArgs e)
        {
            StripePayment.Payment_by_Customer();
        }

        private void button_Retrieve_All_Card_Click(object sender, EventArgs e)
        {
            StripePayment.GetAllCards();
        }

        private void button_Add_New_Card_Click(object sender, EventArgs e)
        {
            StripePayment.AddNewCard();
        }

        private void button_Update_Card_Click(object sender, EventArgs e)
        {
            StripePayment.UpdateCard();
        }

        private void button_Delete_Card_Click(object sender, EventArgs e)
        {
            StripePayment.DeleteCard();
        }

        private void button_Payment_By_PayNow_Click(object sender, EventArgs e)
        {
            StripePayment.Payment_by_PayNow();  
        }
    }
}
