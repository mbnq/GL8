﻿
/* 

    www.mbnq.pl 2024 
    https://mbnq.pl/
    mbnq00 on gmail

*/

using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GL8.CORE
{
    public partial class mbWaitDialog : MaterialForm
    {
        public mbWaitDialog()
        {
            InitializeComponent();
            this.Cursor = Cursors.WaitCursor;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            this.FormClosed += (sender, e) => { this.Cursor = Cursors.Default; };
        }
    }
}
