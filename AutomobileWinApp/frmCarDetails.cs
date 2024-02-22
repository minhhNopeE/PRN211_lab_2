﻿using AutomobileLibrary.BusinessObject;
using AutomobileLibrary.Repository;

namespace AutomobileWinApp
{
    public partial class frmCarDetails : Form
    {
        public frmCarDetails()
        {
            InitializeComponent();
        }

        public ICarRepository CarRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public Car CarInfo { get; set; }

        private void frmCarDetails_Load(object sender, EventArgs e)
        {
            cboManufacturer.SelectedIndex = 0;
            txtCarID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtCarID.Text = CarInfo.CarID.ToString();
                txtCarName.Text = CarInfo.CarName;
                txtPrice.Text = CarInfo.Price.ToString();
                txtReleaseYear.Text = CarInfo.ReleaseYear.ToString();
                cboManufacturer.Text = CarInfo.Manufacturer.Trim();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var car = new Car
                {
                    CarID = int.Parse(txtCarID.Text),
                    CarName = txtCarName.Text,
                    Manufacturer = cboManufacturer.Text,
                    Price = decimal.Parse(txtPrice.Text),
                    ReleaseYear = int.Parse(txtReleaseYear.Text)
                };

                if (InsertOrUpdate == false)
                {                  
                    if (CarRepository.CarIDExists(car.CarID))
                    {
                        MessageBox.Show("Car ID already exists", "Duplicate ID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    CarRepository.InsertCar(car);
                    MessageBox.Show("Car added successfully!", "Add a new car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    CarRepository.UpdateCar(car);
                    MessageBox.Show("Car updated successfully!", "Update a car", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new car" : "Update a car");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
