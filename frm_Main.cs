﻿using System;
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

        private void button1_Click(object sender, EventArgs e)
        {
            StripePayment.CustomerCreateOptions();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var test = StripePayment.CustomerCreateOptions();
            StripePayment.SetupIntentCreateOptions(test);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StripePayment.PayCommand();
        }
    }
}
