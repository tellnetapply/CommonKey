using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;

namespace CommonKey
{
    public partial class MainForm : Form
    {
        #region xml
        private const string FILE_TITLE_S = "<Key>\r\n";
        private const string FILE_TITLE_E = "</Key>";

        private const string SETTING_S = "\t<Setting>\r\n";
        private const string SETTING_E = "\t</Setting>\r\n";
        private const string FILE_NAME_S = "\t\t<FileName>";
        private const string FILE_NAME_E = "</FileName>\r\n";
        private const string MODEL_NAME_S = "\t\t<modle>";
        private const string MODEL_NAME_E = "</modle>\r\n";

        private const string LIST_ITEM_S = "\t<Item>\r\n";
        private const string LIST_ITEM_E = "\t</Item>\r\n";
        private const string LIST_KEYINDEX_S = "\t\t<KeyIndex>";
        private const string LIST_KEYINDEX_E = "</KeyIndex>\r\n";
        private const string LIST_SHORTTHRESHOLD_S = "\t\t<ShortThreshold>";
        private const string LIST_SHORTTHRESHOLD_E = "</ShortThreshold>\r\n";
        private const string LIST_LONGTHRESHOLD_S = "\t\t<LongThreshold>";
        private const string LIST_LONGTHRESHOLD_E = "</LongThreshold>\r\n";
        private const string LIST_UNRELEASETHRESHOLD_S = "\t\t<UnReleaseThreshold>";
        private const string LIST_UNRELEASETHRESHOLD_E = "</UnReleaseThreshold>\r\n";
        private const string LIST_HARDKEYVALUE_S = "\t\t<HardKeyValue>";
        private const string LIST_HARDKEYVALUE_E = "</HardKeyValue>\r\n";
        private const string LIST_SHORTPRESSFUN_S = "\t\t<ShortPressFun>";
        private const string LIST_SHORTPRESSFUN_E = "</ShortPressFun>\r\n";
        private const string LIST_LONGPRESSFUN_S = "\t\t<LongPressFun>";
        private const string LIST_LONGPRESSFUN_E = "</LongPressFun>\r\n";
        private const string LIST_RELEASEFUN_S = "\t\t<ReleaseFun>";
        private const string LIST_RELEASEFUN_E = "</ReleaseFun>\r\n";
        private const string LIST_UNRELEASEFUN_S = "\t\t<UnReleaseFun>";
        private const string LIST_UNRELEASEFUN_E = "</UnReleaseFun>\r\n";
        #endregion
        #region 全局变量
        public string[] ColumnName = new string[9];
        public int RowCount = 0;

        private struct ProjectData_ST
        {
            public string LocalName;
            public string FileName;
            public string ModelName;
            public string Path;
            public string Data;
        };

        private ProjectData_ST ProjectData = new ProjectData_ST();
        #endregion
        #region form init
        public MainForm()
        {
            InitializeComponent();

            MainTbl.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);
            MainTbl.AllowUserToAddRows = false;//不显示行前星号
            MainTbl.AutoGenerateColumns = false;//固定表头
            MainTbl.TopLeftHeaderCell.Value = "   \\ 参数\r\n    \\\r\nNo.  \\";

            ColumnName[0] = "按键\r\n索引";
            ColumnName[1] = "短按\r\n阈值";
            ColumnName[2] = "长按\r\n阈值";
            ColumnName[3] = "无效\r\n阈值";
            ColumnName[4] = "按键\r\n输入";
            ColumnName[5] = "短按\r\n执行";
            ColumnName[6] = "长按\r\n执行";
            ColumnName[7] = "抬起\r\n执行";
            ColumnName[8] = "无效\r\n执行";
            AddColumns(ColumnName, 9);

            disableSort();
        }
        #endregion
        #region 禁止自动排序
        private void disableSort()
        {
            for (int i = 0; i < MainTbl.Columns.Count; i++)
            {
                MainTbl.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        #endregion
        #region 文件操作
        public static byte[] ReadFileToByte(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }
        public static bool WriteByteToFile(byte[] pReadByte, string fileName)
        {
            FileStream pFileStream = null;
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Create);
                pFileStream.Write(pReadByte, 0, pReadByte.Length);
            }
            catch
            {
                return false;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Flush();
                pFileStream.Close();
            }
            return true;
        }
        #endregion
        #region 添加列
        private void AddColumns(string[] str, int size)
        {
            for (int i = 0; i < size; i++)
            {
                DataGridViewTextBoxColumn ColumnTemp = new DataGridViewTextBoxColumn();
                ColumnTemp.HeaderText = str[i];
                MainTbl.Columns.Add(ColumnTemp);
            }
        }
        #endregion
        #region 删除当前
        private void DelCell(int x, int y)
        {
            MainTbl.Rows[y].Cells[x].Value = "";
            disableSort();
        }
        #endregion
        #region 获取指定单元格
        private string GetCell(int x, int y)
        {
            if (MainTbl.Rows[y].Cells[x].Value != null)
            {
                return MainTbl.Rows[y].Cells[x].Value.ToString();
            }
            else
            {
                return "";
            }
        }
        #endregion
        #region 设置指定单元格
        private void SetCell(int x, int y, string str)
        {
            MainTbl.Rows[y].Cells[x].Value = str;
        }
        #endregion
        #region 单元格双击
        private void MainTbl_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string str = GetCell(e.ColumnIndex, e.RowIndex);
                EditDialog.Edit(ColumnName[e.ColumnIndex], str, out str);
                if (str != string.Empty)
                {
                    if (e.ColumnIndex == 0)
                    {
                        str = str.ToUpper();
                    }
                    SetCell(e.ColumnIndex, e.RowIndex, str);
                }
                else
                {

                }
            }
            else
            {

            }
        }
        #endregion
        #region 编辑按钮
        private void BTN_EditConnect_Click(object sender, EventArgs e)
        {
            if (MainTbl.CurrentCellAddress.X != -1 && MainTbl.CurrentCellAddress.Y != -1)
            {
                string str = GetCell(MainTbl.CurrentCellAddress.X, MainTbl.CurrentCellAddress.Y);
                EditDialog.Edit(ColumnName[MainTbl.CurrentCellAddress.X], str, out str);
                if (str != string.Empty)
                {
                    SetCell(MainTbl.CurrentCellAddress.X, MainTbl.CurrentCellAddress.Y, str);
                }
                else
                {

                }
            }
            else
            {

            }
        }
        #endregion
        #region 删除按钮
        private void BTN_DelConnect_Click(object sender, EventArgs e)
        {
            if (MainTbl.CurrentCellAddress.Y != -1 && MainTbl.CurrentCellAddress.X != -1)
            {
                MainTbl.Rows[MainTbl.CurrentCellAddress.Y].Cells[MainTbl.CurrentCellAddress.X].Value = "NULL";
            }
        }
        #endregion
        #region 添加新行按钮
        private void BTN_AddRow_Click(object sender, EventArgs e)
        {
            RowCount++;
            MainTbl.Rows.Add();
            for (int i = 0; i < RowCount; i++)
            {
                MainTbl.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            disableSort();
        }
        #endregion
        #region 删除当前行按钮
        private void BTN_DelRow_Click(object sender, EventArgs e)
        {
            if (MainTbl.CurrentCellAddress.Y != -1 && MainTbl.CurrentCellAddress.X != -1)
            {
                if (RowCount != 0)
                {
                    RowCount--;
                    MainTbl.Rows.RemoveAt(MainTbl.CurrentCellAddress.Y);
                    for (int i = 0; i < RowCount; i++)
                    {
                        MainTbl.Rows[i].HeaderCell.Value = (i + 1).ToString();
                    }
                }
            }
            else
            {

            }
            disableSort();
        }
        #endregion
        #region 新建工程按钮
        private void newProject_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "新建工程";
            sfd.Filter = "Project File(*.xml)|*.xml";
            sfd.FilterIndex = 1;//设置默认文件类型显示顺序 
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录 
            sfd.FileName = "NewProject";//设置默认的文件名
            if (sfd.ShowDialog() == DialogResult.OK)//点击保存按钮进入 
            {
                ProjectData.Path = sfd.FileName.ToString();
                ProjectData.LocalName = ProjectData.Path.Substring(ProjectData.Path.LastIndexOf("\\") + 1); //获取文件名，不带路径
                ProjectData.FileName = "NewFile";
                ProjectData.ModelName = "NewModel";

                textBox1.Text = ProjectData.FileName;
                textBox2.Text = ProjectData.ModelName;

                RowCount = 0;
                MainTbl.Rows.Clear();
            }
        }
        #endregion
        #region 打开工程按钮
        private void openProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Title = "打开工程";
            sfd.Filter = "Project File(*.xml)|*.xml";
            sfd.FilterIndex = 1;//设置默认文件类型显示顺序 
            sfd.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录 
            if (sfd.ShowDialog() == DialogResult.OK)//点击保存按钮进入 
            {
                string path = sfd.FileName.ToString();

                ProjectData.Path = path;
                ProjectData.LocalName = ProjectData.Path.Substring(ProjectData.Path.LastIndexOf("\\") + 1); //获取文件名，不带路径

                byte[] RFB = ReadFileToByte(path);
                string xmlString = System.Text.Encoding.Default.GetString(RFB);

                // 创建XmlDocument对象
                XmlDocument doc = new XmlDocument();

                try
                {
                    // 加载XML数据到XmlDocument对象
                    doc.Load(new StringReader(xmlString));

                    // 选择要访问的节点（这里选择根元素）
                    XmlNode rootElement = doc.SelectSingleNode("//Key");

                    if (rootElement != null)
                    {
                        RowCount = 0;
                        MainTbl.Rows.Clear();
                        // 遍历子节点
                        foreach (XmlNode child in rootElement.ChildNodes)
                        {
                            if (child.Name == "Setting")
                            {
                                ProjectData.FileName = child.FirstChild.InnerText;
                                ProjectData.ModelName = child.FirstChild.NextSibling.InnerText;

                                textBox1.Text = ProjectData.FileName;
                                textBox2.Text = ProjectData.ModelName;
                            }
                            else if (child.Name == "Item")
                            {
                                MainTbl.Rows.Add();
                                for (int i = 0; i < RowCount + 1; i++)
                                {
                                    MainTbl.Rows[i].HeaderCell.Value = (i + 1).ToString();
                                }
                                SetCell(0, RowCount, child.FirstChild.InnerText);
                                SetCell(1, RowCount, child.FirstChild.NextSibling.InnerText);
                                SetCell(2, RowCount, child.FirstChild.NextSibling.NextSibling.InnerText);
                                SetCell(3, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.InnerText);
                                SetCell(4, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                                SetCell(5, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                                SetCell(6, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                                SetCell(7, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                                SetCell(8, RowCount, child.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText);
                                RowCount++;
                                //child.FirstChild.InnerText
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        #endregion
        #region 输出用户H文件
        private void genUserH()
        {
            string tmp = "/********************************************************************************************/\r\n" +
                         "/*  \\file           user model file\r\n" +
                         " *  \\date           2020/01/01\r\n" +
                         " *  \\author         Apply.Liu\r\n" +
                         " *  \\model          user model\r\n" +
                         " *  \\description    User-defined files\r\n" +
                         " *********************************************************************************************\r\n" +
                         " *  \\par    Revision History:\r\n" +
                         " *  <!----- No.     Date        Revised by      Details	------------------------------------->\r\n" +
                         " *          01      2020/01/01  Apply.Liu       new\r\n" +
                         " ********************************************************************************************/\r\n";
            tmp += "#ifndef " + ProjectData.FileName.ToUpper() + "_H\r\n";
            tmp += "#define " + ProjectData.FileName.ToUpper() + "_H\r\n";
            tmp += "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Include File Section                                            */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Macro Definition Section                                        */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "#ifndef STD_TRUE\r\n" +
                   "#define STD_TRUE  1\r\n" +
                   "#endif\r\n" +
                   "\r\n" +
                   "#ifndef STD_FALSE\r\n" +
                   "#define STD_FALSE 0\r\n" +
                   "#endif\r\n" +
                   "\r\n" +
                   "#ifndef NULL\r\n" +
                   "#define NULL     ((void *)0)\r\n" +
                   "#endif\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Type Definition Section                                         */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Enumeration Type Definition Section                             */\r\n" +
                   "/********************************************************************************************/\r\n";
            tmp += "enum " + ProjectData.ModelName.ToUpper() + "_Index_Type_e\r\n";
            tmp += "{\r\n";
            string z = " = 0";
            for (int i = 0; i < RowCount; i++)
            {
                tmp += "    " + ProjectData.ModelName.ToUpper() + "_" + GetCell(0, i).ToUpper() + z + ",\r\n";
                z = "";
            }
            tmp += "};\r\n";
            tmp += "\r\n";
            progressBar1.Value = 30;

            tmp += "enum KEY_Press_Type_e\r\n";
            tmp += "{\r\n";
            tmp += "    KEY_NO_PRESS = 0,\r\n";
            tmp += "    KEY_SHORT_PRESSED,\r\n";
            tmp += "    KEY_LONG_PRESS,\r\n";
            tmp += "    KEY_STUCK,\r\n";
            tmp += "};\r\n";
            tmp += "\r\n"+
            "/********************************************************************************************/\r\n" +
            "/*                          Structure/Union Type Definition Section                         */\r\n" +
            "/********************************************************************************************/\r\n" +
            "typedef struct\r\n" +
            "{\r\n" +
            "    unsigned int KeyIndex;\r\n" +
            "    unsigned int KeyCnt;\r\n" +
            "    unsigned int ShortThreshold;\r\n" +
            "    unsigned int LongThreshold;\r\n" +
            "    unsigned int UnReleaseThreshold;\r\n" +
            "    unsigned char(*KeyValue)(unsigned int KeyIndex);\r\n" +
            "    void(*ShortPressFun)(unsigned int KeyIndex);\r\n" +
            "    void(*LongPressFun)(unsigned int KeyIndex);\r\n" +
            "    void(*ReleaseFun)(unsigned int KeyIndex);\r\n" +
            "    void(*UnReleaseFun)(unsigned int KeyIndex);\r\n" +
            "    unsigned char KeyValBkp;\r\n" +
            "}KeyTbl_ts;\r\n" +
            "\r\n" +
            "/********************************************************************************************/\r\n" +
            "/*                          Extern Declaration                                              */\r\n" +
            "/********************************************************************************************/\r\n" +
            "\r\n" +
            "/********************************************************************************************/\r\n" +
            "/*                          Global Function Prototype Declaration                           */\r\n" +
            "/********************************************************************************************/\r\n" +
            "extern void wvd" + ProjectData.ModelName + "Cyc(unsigned short auhDiffTime);\r\n" +
            "\r\n";
            tmp += "#endif /* " + ProjectData.FileName.ToUpper() + "_H" + " */\r\n";
            tmp += "/* End of File */\r\n";

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(tmp);
            WriteByteToFile(byteArray, System.IO.Path.GetDirectoryName(ProjectData.Path) + "\\" + ProjectData.FileName + ".h");
            progressBar1.Value = 40;
        }
        #endregion
        #region 输出用户C文件
        private void genUserC()
        {
            string tmp = "/********************************************************************************************/\r\n" +
                         "/*  \\file           user model file\r\n" +
                         " *  \\date           2020/01/01\r\n" +
                         " *  \\author         Apply.Liu\r\n" +
                         " *  \\model          user model\r\n" +
                         " *  \\description    User-defined files\r\n" +
                         " *********************************************************************************************\r\n" +
                         " *  \\par    Revision History:\r\n" +
                         " *  <!----- No.     Date        Revised by      Details	------------------------------------->\r\n" +
                         " *          01      2020/01/01  Apply.Liu       new\r\n" +
                         " ********************************************************************************************/\r\n" +
                         "\r\n" +
                         "/********************************************************************************************/\r\n" +
                         "/*                          Include File Section                                            */\r\n" +
                         "/********************************************************************************************/\r\n";
            tmp += "#include \"" + ProjectData.FileName + ".h" + "\"\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Macro Definition Section                                        */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Type Definition Section                                         */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Enumeration Type Definition Section                             */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Structure/Union Type Definition Section                         */\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Static Prototype Declaration Section                            */\r\n" +
                   "/********************************************************************************************/\r\n";

            string ft = "";
            for (int i = 0; i < RowCount; i++)
            {
                string str = "";
                str = GetCell(4, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "static unsigned char " + str + "(unsigned int KeyIndex);\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(5, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "static void " + str + "(unsigned int KeyIndex);\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(6, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "static void " + str + "(unsigned int KeyIndex);\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(7, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "static void " + str + "(unsigned int KeyIndex);\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(8, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "static void " + str + "(unsigned int KeyIndex);\r\n";
                        ft += str + " ";
                    }
                }
            }
            progressBar1.Value = 50;

            tmp += "\r\n" +
                   "/********************************************************************************************/\r\n" +
                   "/*                          Global Variable Definition Section                              */\r\n" +
                   "/********************************************************************************************/\r\n";
            tmp += "static KeyTbl_ts " + ProjectData.ModelName + "_Tbl[]=\r\n";
            tmp += "{\r\n";

            for (int i = 0; i < RowCount; i++)
            {
                string str = "";
                str = GetCell(0, i);
                if (str != "NULL" && str != "")
                {
                    tmp += "    {";
                    tmp += ProjectData.ModelName.ToUpper() + "_" + str + ",0,";
                    str = GetCell(1, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        MessageBox.Show("Row：" + (i + 1).ToString() + " 短按阈值时间未设置！");
                        return;
                    }
                    str = GetCell(2, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        MessageBox.Show("Row：" + (i + 1).ToString() + " 长按阈值时间未设置！");
                        return;
                    }
                    str = GetCell(3, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        MessageBox.Show("Row：" + (i + 1).ToString() + " 按键无效阈值时间未设置！");
                        return;
                    }
                    str = GetCell(4, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        tmp += "NULL,";
                    }
                    str = GetCell(5, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        tmp += "NULL,";
                    }
                    str = GetCell(6, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        tmp += "NULL,";
                    }
                    str = GetCell(7, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str + ",";
                    }
                    else
                    {
                        tmp += "NULL,";
                    }
                    str = GetCell(8, i);
                    if (str != "NULL" && str != "")
                    {
                        tmp += str;
                    }
                    else
                    {
                        tmp += "NULL";
                    }
                    tmp += ",KEY_NO_PRESS},\r\n";
                }
                else
                {
                    MessageBox.Show("Row：" + (i + 1).ToString() + " 按键index未设置！");
                    return;
                }
            }

            tmp += "};\r\n";

            progressBar1.Value = 60;

            ft = "";
            for (int i = 0; i < RowCount; i++)
            {
                string keyIndex = "";
                string str = "";
                keyIndex = GetCell(0, i);
                str = GetCell(4, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "\r\nstatic unsigned char " + str + "(unsigned int KeyIndex)\r\n{\r\n    //Determine the key value of a key or combination key，When pressed return STD_TRUE，else return STD_FALSE\r\n    //Index: " + keyIndex + "\r\n    return STD_FALSE;\r\n}\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(5, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "\r\nstatic void " + str + "(unsigned int KeyIndex)\r\n{\r\n    //Short time callback of key or combination key\r\n    //Index: " + keyIndex + "\r\n}\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(6, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "\r\nstatic void " + str + "(unsigned int KeyIndex)\r\n{\r\n    //Long time callback of key or combination key\r\n    //Index: " + keyIndex + "\r\n}\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(7, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "\r\nstatic void " + str + "(unsigned int KeyIndex)\r\n{\r\n    //Callback when the key or combination key is release\r\n    //Index: " + keyIndex + "\r\n}\r\n";
                        ft += str + " ";
                    }
                }
                str = GetCell(8, i);
                if (str != "NULL" && str != "")
                {
                    if (ft.Contains(str + " ") != true)
                    {
                        tmp += "\r\nstatic void " + str + "(unsigned int KeyIndex)\r\n{\r\n    //Callback when the key or combination key is short circuited\r\n    //Index: " + keyIndex + "\r\n}\r\n";
                        ft += str + " ";
                    }
                }
            }

            progressBar1.Value = 70;

            string tblName = ProjectData.ModelName + "_Tbl";
            tmp +=  "void wvd" + ProjectData.ModelName + "Cyc(unsigned short auhDiffTime)\r\n" +
                    "{\r\n" +
                    "    int i;\r\n" +
                    "    for (i = 0; i < sizeof(" + tblName + ") / sizeof(" + tblName + "[0]); i++)\r\n" +
                    "    {\r\n" +
                    "        if (" + tblName + "[i].KeyValue(" + tblName + "[i].KeyIndex) == STD_TRUE)\r\n" +
                    "        {\r\n" +
                    "            " + tblName + "[i].KeyCnt += auhDiffTime;\r\n" +
                    "            if (" + tblName + "[i].KeyCnt >= " + tblName + "[i].UnReleaseThreshold)\r\n" +
                    "            {\r\n" +
                    "                if (" + tblName + "[i].UnReleaseFun != NULL && " + tblName + "[i].KeyValBkp != KEY_STUCK)\r\n" +
                    "                {\r\n" +
                    "                    " + tblName + "[i].KeyValBkp = KEY_STUCK;\r\n" +
                    "                    " + tblName + "[i].UnReleaseFun(" + tblName + "[i].KeyIndex);\r\n" +
                    "                }\r\n" +
                    "            }\r\n" +
                    "            else if (" + tblName + "[i].KeyCnt >= " + tblName + "[i].LongThreshold)\r\n" +
                    "            {\r\n" +
                    "                if (" + tblName + "[i].LongPressFun != NULL && " + tblName + "[i].KeyValBkp != KEY_LONG_PRESS)\r\n" +
                    "                {\r\n" +
                    "                    " + tblName + "[i].KeyValBkp = KEY_LONG_PRESS;\r\n" +
                    "                    " + tblName + "[i].LongPressFun(" + tblName + "[i].KeyIndex);\r\n" +
                    "                }\r\n" +
                    "            }\r\n" +
                    "            else if (" + tblName + "[i].KeyCnt >= " + tblName + "[i].ShortThreshold)\r\n" +
                    "            {\r\n" +
                    "                if (" + tblName + "[i].ShortPressFun != NULL && " + tblName + "[i].KeyValBkp != KEY_SHORT_PRESSED)\r\n" +
                    "                {\r\n" +
                    "                    " + tblName + "[i].KeyValBkp = KEY_SHORT_PRESSED;\r\n" +
                    "                    " + tblName + "[i].ShortPressFun(" + tblName + "[i].KeyIndex);\r\n" +
                    "                }\r\n" +
                    "            }\r\n" +
                    "\r\n" +
                    "            if (" + tblName + "[i].KeyCnt > " + tblName + "[i].UnReleaseThreshold)\r\n" +
                    "            {\r\n" +
                    "                " + tblName + "[i].KeyCnt = " + tblName + "[i].UnReleaseThreshold + 1;\r\n" +
                    "            }\r\n" +
                    "        }\r\n" +
                    "        else\r\n" +
                    "        {\r\n" +
                    "            if (" + tblName + "[i].KeyCnt >= " + tblName + "[i].ShortThreshold)\r\n" +
                    "            {\r\n" +
                    "                if (" + tblName + "[i].ReleaseFun != NULL && " + tblName + "[i].KeyValBkp != KEY_NO_PRESS)\r\n" +
                    "                {\r\n" +
                    "                    " + tblName + "[i].ReleaseFun(" + tblName + "[i].KeyIndex);\r\n" +
                    "                }\r\n" +
                    "                " + tblName + "[i].KeyValBkp = KEY_NO_PRESS;\r\n" +
                    "            }\r\n" +
                    "            " + tblName + "[i].KeyCnt = 0;\r\n" +
                    "        }\r\n" +
                    "    }\r\n" +
                    "}\r\n";
            //tmp += "\r\nvoid wvd" + ProjectData.ModelName + "Cyc(void)\r\n" +
            //       "{\r\n" +
            //       "    for (int i = 0; i < sizeof(" + tblName + ") / sizeof(" + tblName + "[0]); i++)\r\n" +
            //       "    {\r\n" +
            //       "        if (" + tblName + "[i].KeyValue(" + tblName + "[i].KeyIndex) == true)\r\n" +
            //       "        {\r\n" +
            //       "            " + tblName + "[i].KeyCnt++;\r\n" +
            //       "            if (" + tblName + "[i].KeyCnt == " + tblName + "[i].ShortThreshold)\r\n" +
            //       "            {\r\n" +
            //       "                if (" + tblName + "[i].ShortPressFun != NULL)\r\n" +
            //       "                {\r\n" +
            //       "                    " + tblName + "[i].ShortPressFun(" + tblName + "[i].KeyIndex);\r\n" +
            //       "                }\r\n" +
            //       "            }\r\n" +
            //       "            else if (" + tblName + "[i].KeyCnt == " + tblName + "[i].LongThreshold)\r\n" +
            //       "            {\r\n" +
            //       "                if (" + tblName + "[i].LongPressFun != NULL)\r\n" +
            //       "                {\r\n" +
            //       "                    " + tblName + "[i].LongPressFun(" + tblName + "[i].KeyIndex);\r\n" +
            //       "                }\r\n" +
            //       "            }\r\n" +
            //       "            else if (" + tblName + "[i].KeyCnt == " + tblName + "[i].UnReleaseThreshold)\r\n" +
            //       "            {\r\n" +
            //       "                if (" + tblName + "[i].UnReleaseFun != NULL)\r\n" +
            //       "                {\r\n" +
            //       "                    " + tblName + "[i].UnReleaseFun(" + tblName + "[i].KeyIndex);\r\n" +
            //       "                }\r\n" +
            //       "            }\r\n" +
            //       "            if (" + tblName + "[i].KeyCnt > " + tblName + "[i].UnReleaseThreshold)\r\n" +
            //       "            {\r\n" +
            //       "                " + tblName + "[i].KeyCnt = " + tblName + "[i].UnReleaseThreshold + 1;\r\n" +
            //       "            }\r\n" +
            //       "        }\r\n" +
            //       "        else\r\n" +
            //       "        {\r\n" +
            //       "            if ((" + tblName + "[i].KeyCnt >= " + tblName + "[i].ShortThreshold)\r\n" +
            //       "                && (" + tblName + "[i].KeyCnt <= " + tblName + "[i].UnReleaseThreshold))\r\n" +
            //       "            {\r\n" +
            //       "                if (" + tblName + "[i].ReleaseFun != NULL)\r\n" +
            //       "                {\r\n" +
            //       "                    " + tblName + "[i].ReleaseFun(" + tblName + "[i].KeyIndex);\r\n" +
            //       "                }\r\n" +
            //       "            }\r\n" +
            //       "            " + tblName + "[i].KeyCnt = 0;\r\n" +
            //       "        }\r\n" +
            //       "    }\r\n" +
            //       "}\r\n";

            tmp += "/* End of File */\r\n";

            progressBar1.Value = 80;

            byte[] byteArray = System.Text.Encoding.Default.GetBytes(tmp);
            WriteByteToFile(byteArray, System.IO.Path.GetDirectoryName(ProjectData.Path) + "\\" + ProjectData.FileName + ".c");

            progressBar1.Value = 100;
        }
        #endregion
        #region 生成代码
        private void genCode()
        {
            if (ProjectData.LocalName != "" && ProjectData.Path != "")
            {
                genUserH();
                genUserC();
            }
        }
        #endregion
        #region 保存工程数据
        private void SaveProject()
        {
            if (ProjectData.LocalName != "" && ProjectData.Path != "")
            {
                if (Regex.IsMatch(textBox1.Text, "^[a-zA-Z_]+.*$"))
                {
                    Match mInfo = Regex.Match(textBox1.Text, "^[a-zA-Z0-9_]+$");
                    if (mInfo.Success == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("文件名输入非法字符！(输入范围：字母、数字、下划线)");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("文件名首字母输入非法字符！(输入范围：字母、下划线)");
                    return;
                }

                if (Regex.IsMatch(textBox2.Text, "^[a-zA-Z_]+.*$"))
                {
                    Match mInfo = Regex.Match(textBox2.Text, "^[a-zA-Z0-9_]+$");
                    if (mInfo.Success == true)
                    {

                    }
                    else
                    {
                        MessageBox.Show("模块名输入非法字符！(输入范围：字母、数字、下划线)");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("模块名首字母输入非法字符！(输入范围：字母、下划线)");
                    return;
                }

                ProjectData.FileName = textBox1.Text;
                ProjectData.ModelName = textBox2.Text;

                ProjectData.Data = "";

                ProjectData.Data += FILE_TITLE_S;
                ProjectData.Data += SETTING_S;
                ProjectData.Data += FILE_NAME_S;
                ProjectData.Data += ProjectData.FileName;
                ProjectData.Data += FILE_NAME_E;
                ProjectData.Data += MODEL_NAME_S;
                ProjectData.Data += ProjectData.ModelName;
                ProjectData.Data += MODEL_NAME_E;
                ProjectData.Data += SETTING_E;

                for (int i = 0; i < RowCount; i++)
                {
                    ProjectData.Data += LIST_ITEM_S;

                    ProjectData.Data += LIST_KEYINDEX_S;
                    ProjectData.Data += GetCell(0, i);
                    ProjectData.Data += LIST_KEYINDEX_E;
                    ProjectData.Data += LIST_SHORTTHRESHOLD_S;
                    ProjectData.Data += GetCell(1, i);
                    ProjectData.Data += LIST_SHORTTHRESHOLD_E;
                    ProjectData.Data += LIST_LONGTHRESHOLD_S;
                    ProjectData.Data += GetCell(2, i);
                    ProjectData.Data += LIST_LONGTHRESHOLD_E;
                    ProjectData.Data += LIST_UNRELEASETHRESHOLD_S;
                    ProjectData.Data += GetCell(3, i);
                    ProjectData.Data += LIST_UNRELEASETHRESHOLD_E;
                    ProjectData.Data += LIST_HARDKEYVALUE_S;
                    ProjectData.Data += GetCell(4, i);
                    ProjectData.Data += LIST_HARDKEYVALUE_E;
                    ProjectData.Data += LIST_SHORTPRESSFUN_S;
                    ProjectData.Data += GetCell(5, i);
                    ProjectData.Data += LIST_SHORTPRESSFUN_E;
                    ProjectData.Data += LIST_LONGPRESSFUN_S;
                    ProjectData.Data += GetCell(6, i);
                    ProjectData.Data += LIST_LONGPRESSFUN_E;
                    ProjectData.Data += LIST_RELEASEFUN_S;
                    ProjectData.Data += GetCell(7, i);
                    ProjectData.Data += LIST_RELEASEFUN_E;
                    ProjectData.Data += LIST_UNRELEASEFUN_S;
                    ProjectData.Data += GetCell(8, i);
                    ProjectData.Data += LIST_UNRELEASEFUN_E;

                    ProjectData.Data += LIST_ITEM_E;
                }
                ProjectData.Data += FILE_TITLE_E;

                byte[] byteArray = System.Text.Encoding.Default.GetBytes(ProjectData.Data);
                WriteByteToFile(byteArray, ProjectData.Path);
            }
        }
        #endregion
        #region 保存工程按钮
        private void saveProject_Click(object sender, EventArgs e)
        {
            SaveProject();
        }
        #endregion
        #region 关闭工程按钮
        private void closeProject_Click(object sender, EventArgs e)
        {
            ProjectData.LocalName = "";
            ProjectData.FileName = "";
            ProjectData.ModelName = "";
            ProjectData.Path = "";
            ProjectData.Data = "";

            textBox1.Text = "";
            textBox2.Text = "";

            RowCount = 0;

            MainTbl.Rows.Clear();
        }
        #endregion
        #region 退出按钮
        private void exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
        #endregion
        #region 构建工程按钮
        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (ProjectData.LocalName != "" && ProjectData.Path != "")
                {

                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("未设置文件名或模块名！");
                return;
            }
            progressBar1.Value = 10;

            SaveProject();
            
            if (Regex.IsMatch(textBox1.Text, "^[a-zA-Z_]+.*$"))
            {
                Match mInfo = Regex.Match(textBox1.Text, "^[a-zA-Z0-9_]+$");
                if (mInfo.Success == true)
                {

                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            if (Regex.IsMatch(textBox2.Text, "^[a-zA-Z_]+.*$"))
            {
                Match mInfo = Regex.Match(textBox2.Text, "^[a-zA-Z0-9_]+$");
                if (mInfo.Success == true)
                {

                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            progressBar1.Value = 20;

            genCode();
        }
        #endregion
        #region about
        private void 版本号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "按键代码生成工具\r\n\r\n"
                + "生成代码操作步骤：\r\n"
                + "1、新建工程（文件 -> 新建工程）\r\n"
                + "2、编辑按键信息（编辑界面可添加、修改和删除）\r\n"
                + "3、编辑按键参数\r\n（可编辑按键短按长按等时间参数和相应的回调函数）\r\n"
                + "4、生成代码（设定界面填入文件名和模块名后，点击生成代码按钮后开始生成代码）\r\n\r\n"
                + "注：1:时间参数是前后两次调用用户Cyc函数的时间差，单位ms\r\n"
                + "       2:每行信息可以是单个按键，也可以是组合按键，通过KeyValue函数中实现，如下：\r\n"
                + "unsigned char PowerResetKeyValue(uint32_t KeyIndex)\r\n{\r\n    if((Key1 == Press)&&(Key2 == Press))\r\n    {\r\n        return STD_TRUE;\r\n    }\r\n    else\r\n    {\r\n        return STD_FALSE;\r\n    }\r\n}\r\n"
                + "\r\n\r\n\r\nDesigned By Apply.Liu\r\n"
                + "邮箱：tellnetapply@163.com\r\n"
                + "微信：APP420",
                "About");
        }
#endregion
    }
}
