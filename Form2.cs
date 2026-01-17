using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Medication_Reminder
{
    public partial class Form2 : Form
    {
        private List<Reminder> reminders;

        public Form2(List<Reminder> reminderList)
        {
            InitializeComponent();
            reminders = reminderList ?? new List<Reminder>();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LoadAllMedicines();
        }

        private void LoadAllMedicines()
        {
            lstAllMedicines.Items.Clear();

            foreach (var r in reminders)
            {
                lstAllMedicines.Items.Add($"{r.Name} - {r.Dosage}");
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchMedicines();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchMedicines();
        }

        private void SearchMedicines()
        {
            string keyword = txtSearch.Text.Trim();

            lstAllMedicines.Items.Clear();

            // If search box is empty, show all medicines
            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadAllMedicines();
                return;
            }

            var results = reminders.Where(r =>
                !string.IsNullOrEmpty(r.Name) &&
                r.Name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
            ).ToList();

            if (results.Count == 0)
            {
                MessageBox.Show("No medicine found.");
                LoadAllMedicines();
                return;
            }

            foreach (var r in results)
            {
                lstAllMedicines.Items.Add($"{r.Name} - {r.Dosage}");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close(); // Return to Form1
        }
    }
}
