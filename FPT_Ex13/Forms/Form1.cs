using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPT_Ex13.Exceptions;
namespace FPT_Ex13
{
    public partial class Ex13 : Form
    {
        DataTable dataTable = new DataTable();
        DataTable dtIntern = new DataTable();
        DataTable dtFresher = new DataTable();
        DataTable dtExperience = new DataTable();
        DataTable dtCert = new DataTable();
        public Ex13()
        {
            InitializeComponent();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDtxt.Text);
                if(Manager.Employees.Any(x=>x.ID == id)) { throw new InfoException(); }
                CheckName(Nametxt.Text, out string name);
                CheckPhone(Phonetxt.Text, out string phone);
                CheckEmail(Emailtxt.Text, out string email);
                DateTime dateTime = dtPicker.Value;
                switch ((EmployeeType)comboBoxType.SelectedValue)
                {
                    case EmployeeType.Intern:
                        {
                            string major = InterMajortxtBox.Text;
                            string semester = InternSemestertxtBox.Text;
                            string uni = InternUnitxtBox.Text;
                            Intern intern = new Intern(id, name,  phone, email, dateTime, major, semester, uni);
                            Manager.Employees.Add(intern);
                            break;
                        }
                    case EmployeeType.Fresher:
                        {

                            DateTime dt = dtPickerFresher.Value;
                            Rank rank = (Rank) comboBoxRank.SelectedValue;
                            string edu = textBoxFresher.Text;
                            Fresher fresher = new Fresher(id, name, phone, email, dateTime, rank, edu, dt);
                            Manager.Employees.Add(fresher);
                            break;
                        }
                    case EmployeeType.Experience:
                        {
                            int exp  = (int)numericUpDownExp.Value;
                            string skill = textBoxExp.Text;
                            Experience experience = new Experience(id, name,  phone, email, dateTime, exp, skill);
                            Manager.Employees.Add(experience);
                            break;
                        }

                }
                LoadDataTable();

            }
            catch(PhoneException pe)
            {
                MessageBox.Show("Wrong phonenumber");

            }
            catch(FullNameException fe)
            {
                MessageBox.Show("Wrong name format");
            }
            catch(EmailException ee)
            {
                MessageBox.Show("Wrong email format");
            }
            catch(InfoException ie)
            {
                MessageBox.Show("Invalid info");
            }
            catch(NullReferenceException ne)
            {
                MessageBox.Show("Something is null here");
            }
            catch
            {
                MessageBox.Show("-_-");
            }
        }
        void CheckPhone(string phone, out string number)
        {
            if (phone.Length >= 9 && phone.All(char.IsDigit))
            {
                number = phone;
            }
            else
            {
                number = null;
                throw new PhoneException();
            }
        }
        void CheckName(string name, out string fullName)
        {
            if (name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                fullName = name;
            }
            else
            {
                fullName = null;
                throw new FullNameException();
            }


        }
        void CheckEmail(string mail, out string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);
            if (regex.IsMatch(mail))
            {
                email = mail;
            }
            else
            {
                email = null;
                throw new EmailException();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("DoB", typeof(DateTime));
            dataTable.Columns.Add("Type", typeof(EmployeeType));
            dataGridViewInfo.DataSource = dataTable;
            dataGridViewCert.DataSource = dtCert;

            dtCert.Columns.Add("ID", typeof(string));
            dtCert.Columns.Add("Name", typeof(string));
            dtCert.Columns.Add("Rank",typeof(string));
            dtCert.Columns.Add("Date",typeof(DateTime));

            comboBoxType.DataSource = Enum.GetValues(typeof(EmployeeType));
            comboBoxRank.DataSource = Enum.GetValues(typeof(Rank));
            dtIntern.Columns.Add("Majors", typeof(string));
            dtIntern.Columns.Add("Semester", typeof(string));
            dtIntern.Columns.Add("University", typeof(string));
            dtFresher.Columns.Add("Graduation Date", typeof(DateTime));
            dtFresher.Columns.Add("Graduation Rank", typeof(Rank));
            dtFresher.Columns.Add("Education", typeof(string));
            dtExperience.Columns.Add("Exp", typeof(int));
            dtExperience.Columns.Add("Skill", typeof(string));
            LoadDataTable();
        }
        void LoadDataTable()
        {
            dataTable.Clear();
            Manager.Employees.Sort((x, y) => (x.ID).CompareTo(y.ID));
            foreach (var employee in Manager.Employees)
            {
                AddRow(employee);
            }
            Reset();
        }
        private void Findbtn_Click(object sender, EventArgs e)
        {

            if (int.TryParse(IDtxt.Text, out int id))
            {
                Employee employee = Manager.Employees.Find(x => x.ID == id);
                if (employee != null)
                {
                    Reset();
                    //ShowInfo(employee);
                    dataTable.Clear();
                    AddRow(employee);
                    switch (employee.Type)
                    {
                        case EmployeeType.Intern:
                            {
                                dtIntern.Clear();
                                dataGridViewAddition.DataSource = dtIntern;
                                AddRowIntern(employee);
                                break;
                            }
                        case EmployeeType.Fresher:
                            {
                                dtFresher.Clear();
                                dataGridViewAddition.DataSource = dtFresher;
                                AddRowFresher((Fresher)employee);
                                break;
                            }
                        case EmployeeType.Experience:
                            {
                                dtExperience.Clear();
                                dataGridViewAddition.DataSource = dtExperience;
                                AddRowExperience((Experience)employee);
                                break;
                            }
                    }
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid number");
            }

        }
        void ShowInfo(Employee employee)
        {
            IDtxt.Text = employee.ID.ToString();
            Nametxt.Text = employee.Name;
            Phonetxt.Text = employee.Phone;
            Emailtxt.Text = employee.Email;
            dtPicker.Text = employee.DateOfBirth.ToString();
            comboBoxType.SelectedIndex = (int)employee.Type;
            List<Certificate> certs = employee.Certificates;
            dtCert.Clear();
            foreach(var c in certs)
            { 
                DataRow row = dtCert.NewRow();
                row["ID"] = c.ID;
                row["Name"] = c.Name;
                row["Rank"] = c.Rank;
                row["Date"] = c.Date;
                dtCert.Rows.Add(row);
            }
            ChangeBySelectedIndex();
            switch (employee.Type)
            {
                case EmployeeType.Intern:
                    {
                        Intern intern = (Intern)employee;
                        InternUnitxtBox.Text = intern.University;
                        InternSemestertxtBox.Text = intern.Semester;
                        InterMajortxtBox.Text = intern.Majors;
                        break;
                    }
                case EmployeeType.Fresher:
                    {
                        Fresher fresher = (Fresher)employee;
                        dtPickerFresher.Value = fresher.GraduationDate;
                        comboBoxRank.SelectedIndex = (int)fresher.GraduationRank;
                        textBoxFresher.Text = fresher.Education;
                        break;
                    }
                case EmployeeType.Experience:
                    {
                        Experience exp = (Experience)employee;
                        numericUpDownExp.Value = exp.ExpInYear;
                        textBoxExp.Text = exp.ProSkill;
                        break;
                    }


            }
        }
        void AddRowIntern(Employee employee)
        {
            string[] s = employee.ShowInfo().Split(',');
            DataRow row = dtIntern.NewRow();
            row["Majors"] = s?[0];
            row["Semester"] = s?[1];
            row["University"] = s?[2];
            dtIntern.Rows.Add(row);
        }
        void AddRowFresher(Fresher fresher)
        {
            DataRow row = dtFresher.NewRow();
            row["Graduation Date"] = fresher.GraduationDate;
            row["Graduation Rank"] = fresher.GraduationRank;
            row["Education"] = fresher.Education;
            dtFresher.Rows.Add(row);
        }
        void AddRowExperience(Experience experience)
        {
            DataRow row = dtExperience.NewRow();
            row["Exp"] = experience.ExpInYear;
            row["Skill"] = experience.ProSkill;
            dtExperience.Rows.Add(row);
        }
        private void comboBoxType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            groupBoxIntern.Enabled = false;
            groupBoxIntern.Visible = false;
            groupBoxFresher.Enabled = false;
            groupBoxFresher.Visible = false;
            groupBoxExp.Enabled = false;
            groupBoxExp.Visible = false;
            ChangeBySelectedIndex();

        }
        void ChangeBySelectedIndex()
        {
            switch ((EmployeeType)comboBoxType.SelectedIndex)
            {

                case EmployeeType.Intern:
                    {
                        groupBoxIntern.Enabled = true;
                        groupBoxIntern.Visible = true;
                        break;
                    }
                case EmployeeType.Fresher:
                    {
                        groupBoxFresher.Enabled = true;
                        groupBoxFresher.Visible = true;
                        break;
                    }
                case EmployeeType.Experience:
                    {
                        groupBoxExp.Enabled = true;
                        groupBoxExp.Visible = true;
                        break;
                    }

            }
        }
        private void Allbtn_Click(object sender, EventArgs e)
        {
            LoadDataTable();
        }
        private void dataGridViewInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)(dataGridViewInfo.CurrentRow.Cells[0].Value);
            Employee employee = Manager.Employees.Find(x => x.ID == id);
            ShowInfo(employee);
            switch (employee.Type)
            {
                case EmployeeType.Intern:
                    {
                        dtIntern.Clear();
                        dataGridViewAddition.DataSource = dtIntern;
                        AddRowIntern(employee);
                        break;
                    }
                case EmployeeType.Fresher:
                    {
                        dtFresher.Clear();
                        dataGridViewAddition.DataSource = dtFresher;
                        AddRowFresher((Fresher)employee);
                        break;
                    }
                case EmployeeType.Experience:
                    {
                        dtExperience.Clear();
                        dataGridViewAddition.DataSource = dtExperience;
                        AddRowExperience((Experience)employee);
                        break;
                    }


            }
        }
        private void Internbtn_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            Reset();
            dtIntern.Clear();

            dataGridViewAddition.DataSource = dtIntern;

            List<Employee> employees = Manager.Employees.FindAll(x => x.Type == EmployeeType.Intern);
            foreach (var employee in employees)
            {
                AddRow(employee);
                AddRowIntern(employee);
            }
        }
        private void Fresherbtn_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            Reset();
            dtFresher.Clear();

            dataGridViewAddition.DataSource = dtFresher;

            List<Employee> employees = Manager.Employees.FindAll(x => x.Type == EmployeeType.Fresher);
            foreach (var employee in employees)
            {
                AddRow(employee);
                AddRowFresher((Fresher)employee);
            }
        }
        private void Experiencebtn_Click(object sender, EventArgs e)
        {
            dataTable.Clear();
            Reset();
            dtExperience.Clear();
            dataGridViewAddition.DataSource = dtExperience;

            List<Employee> employees = Manager.Employees.FindAll(x => x.Type == EmployeeType.Experience);
            foreach (var employee in employees)
            {
                AddRow(employee);
                AddRowExperience((Experience)employee);
            }
        }
        void AddRow(Employee employee)
        {
            DataRow row = dataTable.NewRow();
            row["ID"] = employee.ID;
            row["Name"] = employee.Name;
            row["Phone"] = employee.Phone;
            row["Email"] = employee.Email;
            row["DoB"] = employee.DateOfBirth;
            row["Type"] = employee.Type;
            dataTable.Rows.Add(row);
        }
        void Reset()
        {
            IDtxt.Text = "";
            Nametxt.Text = "";
            Phonetxt.Text = "";
            Emailtxt.Text = "";
            dtPicker.Text = DateTime.Now.ToString();
            comboBoxType.SelectedIndex = 2;
            groupBoxExp.Enabled = false;
            groupBoxFresher.Enabled = false;
            groupBoxIntern.Enabled = false;
            groupBoxExp.Visible = false;
            groupBoxFresher.Visible = false;
            groupBoxIntern.Visible = false;


            InterMajortxtBox.Text = "";
            InternUnitxtBox.Text = "";
            InternSemestertxtBox.Text = "";

            textBoxFresher.Text = "";
            textBoxExp.Text = "";
            numericUpDownExp.Value = 0;
            dataGridViewAddition.DataSource = null;


        }
        private void Removebtn_Click(object sender, EventArgs e)
        {
            if(int.TryParse(IDtxt.Text,out int id))
            {
                Manager.Employees.Remove(Manager.Employees.Find(x => x.ID == id));
                LoadDataTable();
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }

        }
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(IDtxt.Text, out int id))
                {
                    Manager.Employees.Remove(Manager.Employees.Find(x => x.ID == id));
                }
                else
                {
                    MessageBox.Show("Invalid ID");
                }
                BtnAdd_Click(sender, e);
            }
            catch
            {

            }
        }
        private void CertUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDtxt.Text);
                Employee employee = Manager.Employees.Find(x => x.ID == id);
                Certificate cer = employee.Certificates.Find(x => x.ID == CertIDtxt.Text);
                if (cer==null)
                {
                    throw new Exception("Not found");
                }
                else
                {
                    employee.Certificates.Remove(cer);
                }
                Certificate cert = new Certificate(CertIDtxt.Text,CertNametxt.Text,Certranktxt.Text,CertdtPicker.Value);
                employee.Certificates.Add(cert);
                employee.Certificates.Sort((x,y)=>x.ID.CompareTo(y.ID));
                ShowInfo(employee);
            }
            catch
            {

            }
        }
        private void CertAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDtxt.Text);
                Employee employee = Manager.Employees.Find(x => x.ID == id);
                Certificate cert = employee.Certificates.Find(x => x.ID == CertIDtxt.Text);
                employee.Certificates.Remove(cert);
                ShowInfo(employee);
            }
            catch
            {

            }
        }
        private void CertRemove_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(IDtxt.Text);
                Employee employee = Manager.Employees.Find(x => x.ID == id);
                Certificate cert = employee.Certificates.Find(x => x.ID == CertIDtxt.Text);
                employee.Certificates.Remove(cert);
                ShowInfo(employee);
                CertIDtxt.Text = "";
                CertNametxt.Text = "";
                Certranktxt.Text = "";
                CertdtPicker.Value = DateTime.Now;
            }
            catch
            {

            }

        }
        private void dataGridViewCert_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse(IDtxt.Text);
                Employee employee = Manager.Employees.Find(x => x.ID == id);
                var certID = (string)(dataGridViewCert.CurrentRow.Cells[0].Value);
                Certificate cert = employee.Certificates.Find(x => x.ID == certID);
                CertIDtxt.Text = cert.ID;
                CertNametxt.Text = cert.Name;
                Certranktxt.Text = cert.Rank;
                CertdtPicker.Value = cert.Date;
            }
            catch
            {

            }
        }
    }
}
