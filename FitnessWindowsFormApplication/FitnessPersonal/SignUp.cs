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
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace FitnessPersonal
{
    public partial class SignUp : Form
    {
        private const string BaseUrl = "https://localhost:44393/apigateway/userService";
        public SignUp()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {

            if (txtEmail.Text != null && txtPassword.Text != "" && txtFirstName.Text != "" && txtLastName.Text !="")
            {

                if (this.IsValidEmail(txtEmail.Text))
                {
                    String email = txtEmail.Text;
                    String password = txtPassword.Text;
                    String firstName = txtFirstName.Text;
                    String lastName = txtLastName.Text;

                    User newUser = new User
                    {
                        FirstName = firstName,
                        LastName = lastName,
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
                            HttpResponseMessage response = client.PostAsync(BaseUrl, content).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                // The request was successful, handle the response
                                string responseBody = response.Content.ReadAsStringAsync().Result;
                                User createdUser = JsonConvert.DeserializeObject<User>(responseBody);

                                // Perform UI-related tasks on the UI thread using Invoke
                                Invoke((MethodInvoker)delegate
                                {
                                    // Do something with the createdUser, e.g., show a message or update the UI                            
                                    MessageBox.Show("Sucessfully Sign UP", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txtEmail.Text = txtPassword.Text = txtFirstName.Text = txtLastName.Text = null;
                                });
                            }
                            else
                            {
                                // The request failed, handle the error
                                Invoke((MethodInvoker)delegate
                                {
                                    MessageBox.Show($"Error creating user. Status Code: {response.StatusCode}");
                                    MessageBox.Show("Error creating user. Status Code: {response.StatusCode}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            // This pattern is a basic validation and may not cover all possible valid email addresses
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }

    
}
