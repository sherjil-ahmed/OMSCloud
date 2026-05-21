using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Windows.Forms;
using OMSCloud.Contracts.Common;

namespace OMSCloud.Contracts.CryptoTool
{
    public partial class CryptoForm : Form
    {
        public CryptoForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {

            //string provider = "RSAProtectedConfigurationProvider";
            //string section = "connectionStrings";
            ////var xx = ;
            //Configuration confg = WebConfigurationManager.OpenWebConfiguration(@"D:\TFS\AB\AvantureBytes\Zvonr\Contracts\Common\OMSCloud.Contracts.CryptoTool\bin\Debug\web.config");
            //ConfigurationSection confStrSect = confg.GetSection(section);
            //if (confStrSect != null)
            //{
            //    confStrSect.SectionInformation.ProtectSection(provider);
            //    confg.Save();
            //}


            if (string.IsNullOrEmpty(txtEncStringValue.Text))
            {
                MessageBox.Show("Enter String Value");
                return;
            }

            txtEncEncValue.Text = CommonUtilities.Encrypt(txtEncStringValue.Text);
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDecDecValue.Text))
            {
                MessageBox.Show("Enter Decrypted Value");
                return;
            }

            txtDecStringValue.Text = CommonUtilities.Decrypt(txtDecDecValue.Text);
        }
    }
}
