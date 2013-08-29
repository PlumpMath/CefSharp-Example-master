using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MyJSBindObj
{
    class MyJSBindObj
    {
        public void test()
        {
            //new OpenFileDialog().ShowDialog();
        }

        public string sign(string str)
        {
            string sig = String.Empty;
            sig = "signed: <i>Bobby Bluebland </i>";

            return str + "<br/>" + sig;
        }

        public string strTest(string str)
        {
            string result = String.Empty;
            for (int i = 0; i < 10; i++)
            {
                result += str + " ";
            }
            return "from MyJSObject:strTest  " + result;
        }
        public void messsage(string str)
        {
            MessageBox.Show("MyJSObject:messsage " + str, "C# side");
        }

    }
}