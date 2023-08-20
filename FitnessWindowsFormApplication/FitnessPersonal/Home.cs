using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Windows.Forms.DataVisualization.Charting;
using FitnessPersonal.Model;

namespace FitnessPersonal
{
    public partial class Home : Form
    {        
        private const string BaseWorkOutDetailUrl = "https://fitnessgatewayservice.azurewebsites.net/apigateway/workoutDetailService";
        

        public User loggedUser;

        public Home(User loggedUser)
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.FixedSingle;           
            this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ClientSize = new Size(1155, 500);
            
            this.loggedUser = loggedUser;            

            List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(loggedUser.Email);

            lblLoggedUserName.Text = "Welcome " +loggedUser.FirstName;

            if (userWorkedOutDetailList != null)
            {
                workOutDataGrid.DataSource = userWorkedOutDetailList;
                // Get the default cell style for the header cells
                DataGridViewCellStyle headerCellStyle = workOutDataGrid.ColumnHeadersDefaultCellStyle;

                // Create a new font with the desired size
                Font newFont = new Font(headerCellStyle.Font.FontFamily, 8, FontStyle.Bold);

                // Set the new font to the header cell style
                headerCellStyle.Font = newFont;

                // Refresh the DataGridView to apply the changes
                workOutDataGrid.Refresh();
                
            }           

        }       

        public Home()
        {
            InitializeComponent();
           
        }

        
        private void Home_Load(object sender, EventArgs e)
        {
            // Call a method to fetch data from the database 
            List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(loggedUser.Email);

            lblLoggedUserName.Text = loggedUser.FirstName;

            if (userWorkedOutDetailList.Count > 0)
            {
                workOutDataGrid.DataSource = null;
                workOutDataGrid.DataSource = userWorkedOutDetailList;

            }
            else
            {
                MessageBox.Show("User or workout details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (dtpWorkoutDate.Value != null && cmbWorkOut.Text != "" && cmbCheatMeal.Text != "" && txtWeight.Text != "" && txtHeight.Text != "" && txtWorkOutDuration != null && txtWorkOutType != null)
            {

                if ((cmbCheatMeal.Text == "Yes" || cmbCheatMeal.Text == "No") && (cmbWorkOut.Text == "Yes" || cmbWorkOut.Text == "No"))
                {
                    //check work out detail saved for the day                   
                    Boolean hasWorkoutForDay = false;

                    String email = loggedUser.Email;
                    DateTime workoutDate = dtpWorkoutDate.Value.Date;

                    WorkoutDayRequest workoutDayRequest = new WorkoutDayRequest
                    {
                        Email = email,
                        WorkOutDate = workoutDate
                    };

                    string jsonUser = JsonConvert.SerializeObject(workoutDayRequest);

                    // Send the POST request to the API
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Set the content type of the request to JSON
                        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                        try
                        {
                            HttpResponseMessage response = client.PostAsync(BaseWorkOutDetailUrl + "/checkWorkOutForDay", content).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                // The request was successful, handle the response
                                string responseBody = response.Content.ReadAsStringAsync().Result;
                                hasWorkoutForDay = JsonConvert.DeserializeObject<Boolean>(responseBody);
                                                              

                            }
                            else
                            {
                                // The request failed, handle the error
                                Invoke((MethodInvoker)delegate
                                {

                                    MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                });
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            // Handle any potential network or API related exceptions
                            Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            });
                        }
                    }

                    
                    if (hasWorkoutForDay == false)
                    {
                        //saved work out detail                      
                        string workout = cmbWorkOut.Text;
                        double weight = double.Parse(txtWeight.Text);
                        string cheatMeal = cmbCheatMeal.Text;
                        double height = double.Parse(txtHeight.Text);
                        string WorkOutType = txtWorkOutType.Text;
                        double WorkOutDuration = double.Parse(txtWorkOutDuration.Text);

                        WorkOutDetail workOutDetail = new WorkOutDetail
                        {
                            WorkOutDate = workoutDate,
                            WorkOutDuration = WorkOutDuration,
                            WorkOutType = WorkOutType,
                            WorkOut = workout,
                            CheatMeal= cheatMeal,
                            Height = height,
                            Weight = weight,
                            UserId = loggedUser.Id
                        };


                        string jsonWorkOutDetail = JsonConvert.SerializeObject(workOutDetail);

                        // Send the POST request to the API
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            // Set the content type of the request to JSON
                            StringContent content = new StringContent(jsonWorkOutDetail, Encoding.UTF8, "application/json");

                            try
                            {
                                HttpResponseMessage response = client.PostAsync(BaseWorkOutDetailUrl, content).Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    // The request was successful, handle the response
                                    string responseBody = response.Content.ReadAsStringAsync().Result;
                                    WorkOutDetail savedWorkedOutDetail = JsonConvert.DeserializeObject<WorkOutDetail>(responseBody);

                                    MessageBox.Show("Inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(email);

                                    if (userWorkedOutDetailList.Count > 0)
                                    {
                                        workOutDataGrid.DataSource = null;
                                        workOutDataGrid.DataSource = userWorkedOutDetailList;
                                       
                                    }
                                    else 
                                    {
                                        MessageBox.Show("User or workout details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }                 

                                }
                                else
                                {
                                    // The request failed, handle the error
                                    Invoke((MethodInvoker)delegate
                                    {

                                        MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    });
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                // Handle any potential network or API related exceptions
                                Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show($"Error: {ex.Message}");
                                });
                            }                           

                           
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Date is already inserted.Can not insert duplicate date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                        
                     
                }
                else 
                {
                    MessageBox.Show("work out or cheat meal values are incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            else 
            {
                MessageBox.Show("Please fill all the required fileds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void workOutDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridView dataGridView = (DataGridView)sender;

                // Check if the clicked column is the update button column
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dataGridView.Columns[e.ColumnIndex].HeaderText == "Update")
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dataGridView.Rows[e.RowIndex];

                    if ((selectedRow.Cells[2].Value.ToString() == "Yes" || selectedRow.Cells[2].Value.ToString() == "No") && (selectedRow.Cells[7].Value.ToString() == "Yes" || selectedRow.Cells[7].Value.ToString() == "No"))
                    {
                        // Define the expected date format
                        string expectedFormat = "dd/MM/yyyy";

                        // Perform the date validation
                        DateTime parsedDate;
                        bool isValidDate = DateTime.TryParseExact(selectedRow.Cells[1].Value.ToString(), expectedFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate);


                        Guid id = (Guid)selectedRow.Cells[0].Value;
                        DateTime workoutDate = Convert.ToDateTime(selectedRow.Cells[1].Value);
                        string workout = selectedRow.Cells[2].Value.ToString();
                        String WorkOutType = selectedRow.Cells[3].Value.ToString();
                        double WorkOutDuration = Convert.ToInt32(selectedRow.Cells[4].Value);
                        double weight = Convert.ToInt32(selectedRow.Cells[5].Value);
                        double height = Convert.ToInt32(selectedRow.Cells[6].Value);
                        string cheatMeal = selectedRow.Cells[7].Value.ToString();

                        WorkOutDetail UpdatedworkOutDetail = new WorkOutDetail
                        {
                            Id = id,
                            WorkOutDate = workoutDate,
                            WorkOutDuration = WorkOutDuration,
                            WorkOutType = WorkOutType,
                            WorkOut = workout,
                            CheatMeal = cheatMeal,
                            Height = height,
                            Weight = weight,
                            UserId = loggedUser.Id
                        };

                        string jsonWorkOutDetail = JsonConvert.SerializeObject(UpdatedworkOutDetail);

                        // Send the POST request to the API
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            // Set the content type of the request to JSON
                            StringContent content = new StringContent(jsonWorkOutDetail, Encoding.UTF8, "application/json");

                            try
                            {
                                HttpResponseMessage response = client.PutAsync(BaseWorkOutDetailUrl, content).Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    // The request was successful, handle the response
                                    string responseBody = response.Content.ReadAsStringAsync().Result;
                                    WorkOutDetail savedWorkedOutDetail = JsonConvert.DeserializeObject<WorkOutDetail>(responseBody);

                                    MessageBox.Show("Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(loggedUser.Email);

                                    if (userWorkedOutDetailList.Count > 0)
                                    {
                                        workOutDataGrid.DataSource = null;
                                        workOutDataGrid.DataSource = userWorkedOutDetailList;

                                    }
                                    else
                                    {
                                        MessageBox.Show("User or workout details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    // The request failed, handle the error
                                    Invoke((MethodInvoker)delegate
                                    {

                                        MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    });
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                // Handle any potential network or API related exceptions
                                Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show($"Error: {ex.Message}");
                                });
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("work out or cheat meal values are incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                // Check if the clicked column is the delete button column
                if (dataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn && dataGridView.Columns[e.ColumnIndex].HeaderText == "Delete")
                {
                    // Handle the delete button click
                    int selectedRowIndex = e.RowIndex;
                    WorkOutDetail selectedWorkOutData = dataGridView.Rows[selectedRowIndex].DataBoundItem as WorkOutDetail;

                    Guid workoutDetailId = selectedWorkOutData.Id;

                    // Remove the item from the data source
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        try
                        {
                            // Append the email parameter to the URL
                            HttpResponseMessage response = client.DeleteAsync($"{BaseWorkOutDetailUrl}/{workoutDetailId}").Result;

                            if (response.IsSuccessStatusCode)
                            {

                                MessageBox.Show("successfully delete the workout data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(loggedUser.Email);

                                if (userWorkedOutDetailList.Count > 0)
                                {
                                    workOutDataGrid.DataSource = null;
                                    workOutDataGrid.DataSource = userWorkedOutDetailList;
                                }
                                else
                                {
                                    MessageBox.Show("User or workout details not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                // Refresh the DataGridView to reflect the changes
                                dataGridView.DataSource = null;
                                dataGridView.DataSource = userWorkedOutDetailList;
                            }                           
                            else
                            {
                                Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                });
                            }
                        }
                        catch (HttpRequestException ex)
                        {
                            // Handle any potential network or API related exceptions
                            Invoke((MethodInvoker)delegate
                            {
                                MessageBox.Show($"Error: {ex.Message}");
                            });
                        }
                    }   

                }
            }
        }        

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            // Set the license context
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            DateRangeDialogForm dialog = new DateRangeDialogForm();

            List<WorkOutDetail> workOutDetailList = null;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DateTime startDate = dialog.SelectedStartDate;
                DateTime endDate = dialog.SelectedEndDate;

                if (startDate != null && endDate != null)
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {

                        WorkOutDetailsByEmailAndDateRange workOutDetailsByEmailAndDateRange = new WorkOutDetailsByEmailAndDateRange
                        {
                            Email = loggedUser.Email,
                            StartDate = startDate,
                            EndDate = endDate
                                                    
                        };

                        string jsonWorkOutDetail = JsonConvert.SerializeObject(workOutDetailsByEmailAndDateRange);

                        // Send the POST request to the API
                        using (HttpClient client = new HttpClient())
                        {
                            client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                            client.DefaultRequestHeaders.Accept.Clear();
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            // Set the content type of the request to JSON
                            StringContent content = new StringContent(jsonWorkOutDetail, Encoding.UTF8, "application/json");

                            try
                            {
                                HttpResponseMessage response = client.PostAsync(BaseWorkOutDetailUrl+ "/daterange", content).Result;

                                if (response.IsSuccessStatusCode)
                                {
                                    // The request was successful, handle the response
                                    string responseBody = response.Content.ReadAsStringAsync().Result;
                                    workOutDetailList = JsonConvert.DeserializeObject<List<WorkOutDetail>>(responseBody);                                

                                }
                                else
                                {
                                    // The request failed, handle the error
                                    Invoke((MethodInvoker)delegate
                                    {
                                        MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    });
                                }
                            }
                            catch (HttpRequestException ex)
                            {
                                // Handle any potential network or API related exceptions
                                Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show($"Error: {ex.Message}");
                                });
                            }
                        }

                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Workout Data");

                        // Set the column headers

                        worksheet.Cells[1, 1].Value = "Workout Date";
                        worksheet.Cells[1, 2].Value = "Workout";
                        worksheet.Cells[1, 3].Value = "Workout Type";
                        worksheet.Cells[1, 4].Value = "Workout Duration";
                        worksheet.Cells[1, 5].Value = "Weight";
                        worksheet.Cells[1, 6].Value = "Height";
                        worksheet.Cells[1, 7].Value = "Cheat Meal";                   

                        // Populate the data rows
                        int row = 2;
                        foreach (var workOutData in workOutDetailList)
                        {

                            worksheet.Cells[row, 1].Value = workOutData.WorkOutDate.ToString();
                            worksheet.Cells[row, 2].Value = workOutData.WorkOut;
                            worksheet.Cells[row, 3].Value = workOutData.WorkOutType;
                            worksheet.Cells[row, 4].Value = workOutData.WorkOutDuration;
                            worksheet.Cells[row, 5].Value = workOutData.Weight;
                            worksheet.Cells[row, 6].Value = workOutData.Height;
                            worksheet.Cells[row, 7].Value = workOutData.CheatMeal;
                            row++;
                        }

                        // Auto-fit columns for better readability
                        worksheet.Cells.AutoFitColumns();

                        // Save the Excel package to a stream
                        MemoryStream stream = new MemoryStream();
                        package.SaveAs(stream);


                        // Create a save file dialog for user to choose the download location
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "Excel Files|*.xlsx";
                        saveFileDialog.Title = "Save Excel File";
                        saveFileDialog.FileName = "WorkoutData.xlsx";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Save the Excel file at the selected location
                            string filePath = saveFileDialog.FileName;
                            File.WriteAllBytes(filePath, package.GetAsByteArray());

                            MessageBox.Show("Sucessfully downloaded the workout data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select start date and end date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    String email = loggedUser.Email;

                   
                    // Append the email parameter to the URL
                    HttpResponseMessage response = client.DeleteAsync($"{BaseWorkOutDetailUrl + "/delete"}/{email}").Result;

                    if (response.IsSuccessStatusCode)
                    {

                        MessageBox.Show("successfully delete the workout data", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        List<WorkOutDetail> userWorkedOutDetailList = getWorkOutdetailsByUsermail(loggedUser.Email);
                       
                    }
                    else
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Error getting user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                }
                catch (HttpRequestException ex)
                {
                    // Handle any potential network or API related exceptions
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    });
                }
            }
           
        }

        public List<WorkOutDetail> getWorkOutdetailsByUsermail(string email)
        {
            List<WorkOutDetail> workOutDetails = null;

            // Send the GET request to the API
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Append the email parameter to the URL
                    HttpResponseMessage response = client.GetAsync($"{BaseWorkOutDetailUrl}/email/{email}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // The request was successful, handle the response
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        workOutDetails = JsonConvert.DeserializeObject<List<WorkOutDetail>>(responseBody);

                        return workOutDetails;

                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Handle the case where the user or workout details are not found
                        // You can display an error message to the user if needed
                        return workOutDetails;
                    }
                    else
                    {
                        // The request failed, handle the error
                        return workOutDetails;
                    }
                }
                catch (HttpRequestException ex)
                {
                    return workOutDetails;
                }
            }
        }

        private void btnViewAnalizeData_Click(object sender, EventArgs e)
        {

            List<WorkOutDetail> workOutDetails =  getWorkOutdetailsByUsermail(loggedUser.Email);

            if (workOutDetails == null || workOutDetails.Count < 7)
            {

                MessageBox.Show("Insufficient amount of data.Please enter work out data at least for 7 days", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Results results = new Results(loggedUser);
                results.Show();
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
           
        }
    }
}
