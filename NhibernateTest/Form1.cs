using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NhibernateTest
{
    public partial class Form1 : Form
    {
        private Configuration myconfig;
        private ISessionFactory mySessionFactory;
        private ISession mySession;


        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //ISession session = NHibertnateSession.OpenSession();

            //Employee emp = new Employee();
            //emp.FirstName = txtName.Text;
            //emp.LastName = txtLastName.Text;
            //emp.Designation = txtDes.Text;
            //session.Save(emp);
            //session.Close();

            myconfig = new Configuration();
            myconfig.Configure();
            mySessionFactory = myconfig.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (mySession.BeginTransaction())
            {
                Users u = new Users();
                u.UserName = txtUserName.Text;
                u.Password = txtPassword.Text;
                u.FirstName = txtFirstName.Text;
                u.LastName = txtLastName.Text;
                mySession.Save(u);
                mySession.Transaction.Commit();
                //mySession.Close();
                lblStatus.Text = "İşlem Tamam...";
            }
                

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            myconfig = new Configuration();
            myconfig.Configure();
            mySessionFactory = myconfig.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();

            using (mySession.BeginTransaction())
            {
                ICriteria myCriter = mySession.CreateCriteria<Users>();
                IList<Users> mylist = myCriter.List<Users>();
                dataGridView1.DataSource = mylist;

                mySession.Transaction.Commit();


            }

        }
    }
}
