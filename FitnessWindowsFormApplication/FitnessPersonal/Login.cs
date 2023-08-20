using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace FitnessPersonal
{
    public partial class Login : Form
    {
        private const string BaseUrl = "https://fitnessgatewayservice.azurewebsites.net/apigateway/userService";

        
        public Login()
        {
            InitializeComponent();
        }        

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            SignUp signUp = new SignUp();
            this.Hide();
            signUp.Show();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text != null && txtPassword.Text != "")
            {

                if (this.IsValidEmail(txtEmail.Text))
                {
                    String email = txtEmail.Text;
                    String password = txtPassword.Text;                    

                    UserLoginModel newUser = new UserLoginModel
                    {
                        Email = email,
                        Password = password
                    };

                    string jsonUser = JsonConvert.SerializeObject(newUser);

                    // Send the POST request to the API
                    using (HttpClient client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(BaseUrl);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        // Set the content type of the request to JSON
                        StringContent content = new StringContent(jsonUser, Encoding.UTF8, "application/json");

                        try
                        {
                            HttpResponseMessage response = client.PostAsync(BaseUrl+"/login", content).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                // The request was successful, handle the response
                                string responseBody = response.Content.ReadAsStringAsync().Result;
                                User LoggedUser = JsonConvert.DeserializeObject<User>(responseBody);

                                // Show the Home window and start the application message loop
                                Home home = new Home(LoggedUser);
                                home.Show();

                                // Close the SignIn window
                                this.Hide();

                            }
                            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                            {
                                MessageBox.Show("Username or password incorrect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("Enter valid mail", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {

                MessageBox.Show("Please fill all the required fileds", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        public bool IsValidEmail(string email)
        {
            // Regular expression pattern for email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

       
    }
}
