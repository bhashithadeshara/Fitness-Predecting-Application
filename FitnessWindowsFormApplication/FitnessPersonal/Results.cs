using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static OfficeOpenXml.ExcelErrorValue;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using FitnessPersonal.Model;

namespace FitnessPersonal
{
    public partial class Results : Form
    {
        User loggedUser;

        private const string BaseAnalyseDetailUrl = "https://localhost:44393/apigateway/analysefitnessdetailService";

        public Results(User LoggedUser)
        {
            InitializeComponent();
            this.loggedUser = LoggedUser;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.ClientSize = new Size(600, 530);

        }              

        private void Results_Load(object sender, EventArgs e)
        {

            // Send the GET request to the API
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAnalyseDetailUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    string email = loggedUser.Email;
                    // Append the email parameter to the URL
                    HttpResponseMessage response = client.GetAsync($"{BaseAnalyseDetailUrl}/email/{email}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // The request was successful, handle the response
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        AnalyseData analyseData = JsonConvert.DeserializeObject<AnalyseData>(responseBody);

                        lblCheatMeal.Text = analyseData.RoundedavgCheatMealCount.ToString() + "%";
                        lblAvgWorkOut.Text = analyseData.RoundedavgWorkoutCount.ToString() + "%";
                        lblBMI.Text = analyseData.BmiStatus;
                        lblFitness.Text = analyseData.Fitness;
                        lblpredictedWeight.Text = analyseData.RoundedPredictedWeight.ToString();

                        //populating vlues for cheat meal progress bar
                        progressBarCheatMeal.Minimum = 0;
                        progressBarCheatMeal.Maximum = analyseData.TotalDaysCount;
                        progressBarCheatMeal.Value = analyseData.TotalCheatMealCount;

                        //populating vlues for cheat meal progress bar
                        progressBarWorkOut.Minimum = 0;
                        progressBarWorkOut.Maximum = analyseData.TotalDaysCount;
                        progressBarWorkOut.Value = analyseData.TotalWorkOutCount;

                        List<WorkOutDetail> workOutList = analyseData.WorkOutDetailList;


                        //populating values to chart
                        Series series = new Series("Data Series");

                        foreach (var item in workOutList)
                        {
                            series.Points.AddXY(item.WorkOutDate, item.Weight);
                        }

                        chart1.ChartAreas[0].AxisX.Title = "Date";

                        // Set the Y-axis title
                        chart1.ChartAreas[0].AxisY.Title = "Weight";

                        // Add the series to the chart's SeriesCollection
                        chart1.Series.Add(series);

                    }
                    else 
                    {
                        Invoke((MethodInvoker)delegate
                        {
                            MessageBox.Show("Error getting Analyse Data. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        });
                    }
                  
                }
                catch (HttpRequestException ex)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    });
                }
            }        
        }

        
    }
}
