using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Example_14_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //--------------------------------------------------------------------
        ContextMenuStrip contextmenustrip1 = new ContextMenuStrip();
        ToolStripMenuItem Cut_tsmi = new ToolStripMenuItem("&Cut");
        ToolStripMenuItem Copy_tsmi = new ToolStripMenuItem("C&opy");
        ToolStripMenuItem Paste_tsmi = new ToolStripMenuItem("&Paste");
        ToolStripMenuItem Delete_tsmi = new ToolStripMenuItem("&Delete");
        //--------------------------------------------------------------------
        private void Form1_Load(object sender, EventArgs e)
        {
            contextmenustrip1.Items.AddRange(new ToolStripItem[] {Cut_tsmi,Copy_tsmi,Paste_tsmi,Delete_tsmi});
            Cut_tsmi.Click += new System.EventHandler(this.Cut_Copy_Paste_Delete_Click);
            Copy_tsmi.Click += new System.EventHandler(this.Cut_Copy_Paste_Delete_Click);
            Paste_tsmi.Click += new System.EventHandler(this.Cut_Copy_Paste_Delete_Click);
            Delete_tsmi.Click += new System.EventHandler(this.Cut_Copy_Paste_Delete_Click);
            this.ContextMenuStrip = contextmenustrip1;
            foreach (Button btn in this.Controls)
            {
                btn.ContextMenuStrip = contextmenustrip1;
            }
        }
        //--------------------------------------------------------------------
        void GetProperties(ref Button destbtn, Button sourcebtn)
        {
            destbtn.Text = sourcebtn.Text;
            destbtn.Size = sourcebtn.Size;
            destbtn.Font=sourcebtn.Font;
            destbtn.Location = sourcebtn.Location;
            //,.....
        }
        //--------------------------------------------------------------------
        private void Cut_Copy_Paste_Delete_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = (ToolStripMenuItem)sender;
            switch (tsmi.Text)
            {
                case "&Cut":
                    if (contextmenustrip1.SourceControl != this)
                    {
                        Button b = new Button();
                        GetProperties(ref b, (Button)contextmenustrip1.SourceControl);
                        this.Tag = b;
                        contextmenustrip1.SourceControl.Dispose();
                    }
                    break;
                case "C&opy":
                    if (contextmenustrip1.SourceControl != this)
                    {
                        Button b = new Button();
                        GetProperties(ref b, (Button)contextmenustrip1.SourceControl);
                        this.Tag = b;
                    }
                    break;
                case "&Paste":
                    if (this.Tag != null)
                    {
                        Button b1 = new Button();
                        GetProperties(ref b1, (Button)this.Tag);
                        b1.Location=new Point(MousePosition.X - this.Left-24 ,MousePosition.Y - this.Top-82);
                        b1.ContextMenuStrip = contextmenustrip1;
                        this.Controls.Add(b1);
                        b1.Focus();
                        b1.BringToFront();
                    }
                    break;
                case "&Delete":
                    if (contextmenustrip1.SourceControl != this)
                    {
                        contextmenustrip1.SourceControl.Dispose();
                    }
                    break;
            }
        }
        //--------------------------------------------------------------------
    }
}
