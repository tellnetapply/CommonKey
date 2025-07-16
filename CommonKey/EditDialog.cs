using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace CommonKey
{
    public partial class EditDialog : Form
    {
        public delegate void TextEventHandler(string strText);
        public TextEventHandler TextHandler;

        public EditDialog()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void BT_OK_Click(object sender, EventArgs e)
        {
            if (null != TextHandler)
            {
                if ((this.Text == "短按\r\n阈值") ||
                    (this.Text == "长按\r\n阈值") ||
                    (this.Text == "无效\r\n阈值"))
                {
                    try
                    {
                        int x = int.Parse(txtString.Text);
                        TextHandler.Invoke(x.ToString());
                        DialogResult = DialogResult.OK;
                    }
                    catch
                    {
                        MessageBox.Show("输入非法字符！(输入范围：正整数)");
                    }
                }
                else
                {
                    if (Regex.IsMatch(txtString.Text, "^[a-zA-Z_]+.*$"))
                    {
                        Match mInfo = Regex.Match(txtString.Text, "^[a-zA-Z0-9_]+$");
                        if (mInfo.Success == true)
                        {
                            TextHandler.Invoke(txtString.Text);
                            DialogResult = DialogResult.OK;
                        }
                        else
                        {
                            MessageBox.Show("输入非法字符！(输入范围：字母、数字、下划线)");
                        }
                    }
                    else
                    {
                        MessageBox.Show("首字母输入非法字符！(输入范围：字母、下划线)");
                    }
                }
            }
        }

        private void BT_CANCEL_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

         public static DialogResult Edit(string FormName, string InitStr, out string strText)
        {
            string strTemp = string.Empty;
            EditDialog editDialog = new EditDialog();
            editDialog.Text = FormName;
            editDialog.txtString.Text = InitStr;

            editDialog.TextHandler = (str) => { strTemp = str; };

            DialogResult result = editDialog.ShowDialog();
            strText = strTemp;

            return result;
        }

        private void txtString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (null != TextHandler)
                {
                    Match mInfo = Regex.Match(txtString.Text, "^[a-zA-Z0-9_]+$");
                    if (mInfo.Success == true)
                    {
                        TextHandler.Invoke(txtString.Text);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("输入非法字符！(输入范围：字母、数字、下划线)");
                    }
                }
            }
        }
    }
}
