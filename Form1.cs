using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medication_Reminder
{
    public partial class Form1 : Form
    {
        List<Reminder> reminders = new List<Reminder>();
        public Form1(string user)
        {
            InitializeComponent();
            this.Text = $"Medication Reminder - Welcome {user}";

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Prepopulate with 20 medicines
            reminders.Add(new Reminder { Name = "Paracetamol", Dosage = "500mg", Time = "08:00 AM" });
            reminders.Add(new Reminder { Name = "Ibuprofen", Dosage = "200mg", Time = "12:00 PM" });
            reminders.Add(new Reminder { Name = "Amoxicillin", Dosage = "250mg", Time = "09:00 AM" });
            reminders.Add(new Reminder { Name = "Cetirizine", Dosage = "10mg", Time = "07:00 AM" });
            reminders.Add(new Reminder { Name = "Metformin", Dosage = "500mg", Time = "08:30 AM" });
            reminders.Add(new Reminder { Name = "Aspirin", Dosage = "100mg", Time = "06:00 AM" });
            reminders.Add(new Reminder { Name = "Loratadine", Dosage = "10mg", Time = "09:30 AM" });
            reminders.Add(new Reminder { Name = "Omeprazole", Dosage = "20mg", Time = "07:30 AM" });
            reminders.Add(new Reminder { Name = "Vitamin C", Dosage = "500mg", Time = "10:00 AM" });
            reminders.Add(new Reminder { Name = "Vitamin D", Dosage = "1000 IU", Time = "11:00 AM" });
            reminders.Add(new Reminder { Name = "Azithromycin", Dosage = "500mg", Time = "01:00 PM" });
            reminders.Add(new Reminder { Name = "Hydrochlorothiazide", Dosage = "25mg", Time = "06:30 AM" });
            reminders.Add(new Reminder { Name = "Simvastatin", Dosage = "20mg", Time = "09:00 PM" });
            reminders.Add(new Reminder { Name = "Prednisone", Dosage = "10mg", Time = "08:00 AM" });
            reminders.Add(new Reminder { Name = "Ciprofloxacin", Dosage = "500mg", Time = "02:00 PM" });
            reminders.Add(new Reminder { Name = "Metoprolol", Dosage = "50mg", Time = "07:00 AM" });
            reminders.Add(new Reminder { Name = "Losartan", Dosage = "50mg", Time = "08:00 AM" });
            reminders.Add(new Reminder { Name = "Furosemide", Dosage = "40mg", Time = "06:00 AM" });
            reminders.Add(new Reminder { Name = "Clindamycin", Dosage = "300mg", Time = "01:30 PM" });
            reminders.Add(new Reminder { Name = "Alprazolam", Dosage = "0.5mg", Time = "10:00 PM" });

            // Optional: Add them to ListBox on load
            foreach (var r in reminders)
            {
                lstReminders.Items.Add(r);
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void timePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtMedName.Text == "" || txtDosage.Text == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            Reminder r = new Reminder
            {
                Name = txtMedName.Text,
                Dosage = txtDosage.Text,
                Time = timePicker.Value.ToShortTimeString()
            };

            reminders.Add(r);
            lstReminders.Items.Add(r);   // ADD TO LISTBOX

            MessageBox.Show("Reminder Added!");

            txtMedName.Clear();
            txtDosage.Clear();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToShortTimeString();

            foreach (var r in reminders)
            {
                if (r.Time == currentTime)
                {
                    MessageBox.Show(
                        $"Time to take {r.Name}\nDosage: {r.Dosage}",
                        "Medication Reminder"
                    );
                }
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(reminders);
            f2.Show();
        }
    }
     public class Reminder
    {
        public string Name { get; set; }
        public string Dosage { get; set; }
        public string Time { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Dosage} at {Time}";
        }
    }

}
